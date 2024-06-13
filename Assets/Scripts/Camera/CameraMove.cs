using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/3dsMax Camera Style")]
public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;
    public float distance = 5.0f;
    public float maxDistance = 20;
    public float minDistance = .6f;
    public float xSpeed = 200.0f;
    public float ySpeed = 200.0f;
    public int yMinLimit = -80;
    public int yMaxLimit = 80;
    public int zoomRate = 40;
    public float zoomDampening = 5.0f;
    private float orthoZoomSpeed = 0.15f ;
    public float perspectiveZoomSpeed = 0.15f;
    public float smoothTime = 0.05f;
    public float speed = 0.01f;
    public static bool _OnPointerUI;
    public static Vector3 _centerPivot; // Pivot tĩnh được chọn trước
    
    public float zoomDampen = 10f;
    [HideInInspector]
    public float zoomDefault;
    private bool _rot;
    [SerializeField]
    public bool _moving;
    private Vector3 desVector = Vector3.zero;
    private bool move;
    private Vector3 velocity = Vector3.zero;
    private  Vector2 touchzeroPosbegin = new Vector2(0, 0);
    private  Vector2 touchOnePosbegin = new Vector2(0, 0);
    private IEnumerator couroutine;
    private float xDeg = 0.0f;
    private float yDeg = 0.0f;
    private float currentDistance;
    private float desiredDistance;
    private Vector3 lastPlanePoint;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;
    private Quaternion rotation;
    private Vector3 position;
    private int direct = 1;
    private int _detectChangeStatus;
    private Vector3 tempDes;
    [HideInInspector]
    public Camera camera;

    void Start() { Init(); }
    void OnEnable() { Init(); }

    

    public void Init()
    {
        desVector = target.position;
       tempDes = target.position;
        camera = GetComponent<Camera>();
        zoomDefault = camera.fieldOfView;
        //If there is no target, create a temporary target at 'distance' from the cameras current viewpoint
        if (!target)
        {
            GameObject go = new GameObject("Cam Target");
            go.transform.position = transform.position + (transform.forward * distance);
            target = go.transform;
        
        }

        distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
        desiredDistance = distance;

        //be sure to grab the current rotations as starting points.
        position = transform.position;
        rotation = transform.rotation;
        currentRotation = transform.rotation;
        desiredRotation = transform.rotation;

        xDeg = Vector3.Angle(Vector3.right, transform.right);
        yDeg = Vector3.Angle(Vector3.up, transform.up);
    }

    /*
     * Camera logic on LateUpdate to only update after all character movement logic has been handled. 
     */
    void LateUpdate()
    {
        if (_OnPointerUI) return;
        Rotate();
        Zoom();
        Move();
    }

    void Rotate()
    {
        //if the screen is touching just one fi`nger and it is moving on the screen perform rotation of the camera
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved)
        {
            float swipeSpeed = Input.touches[0].deltaPosition.magnitude / Input.touches[0].deltaTime;
            // Debug.Log("Ydeg = "+yDeg);
            // int round = (int)(Mathf.Abs(yDeg) / 90);
         
             xDeg += Input.touches[0].deltaPosition.x * xSpeed * Time.deltaTime * swipeSpeed * 0.00001f * direct;
            yDeg -= Input.touches[0].deltaPosition.y * ySpeed * Time.deltaTime * swipeSpeed * 0.00001f;// direct;
            
            ////////OrbitAngle

            //Clamp the vertical axis for the orbit
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
            // set camera rotation 
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = transform.rotation;

            rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
            transform.rotation = rotation;
        }
        //stop rotation if you click on the screen
        else if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            desiredRotation = transform.rotation;
            _rot = true;
        }

        //continue rotation even after releasing the finger fro the screen
        if (transform.rotation != desiredRotation &&_rot)
        {
            rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * zoomDampening);
            transform.rotation = rotation;

            // Kiemer tra khac dau
           /* Debug.Log(transform.localEulerAngles.x);
         int round = (int)(Mathf.Abs(transform.localEulerAngles.x) / 90);
            Debug.Log(round);
            int _tempStatus = round % 2;

            direct = _detectChangeStatus == _tempStatus ? direct : -direct;
            _detectChangeStatus = _tempStatus;
            */
        }
    }

    void Zoom()
    {

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Moved)
                touchzeroPosbegin = touchZero.position;
            if (touchOne.phase == TouchPhase.Began)
                touchOnePosbegin = touchOne.position;

            // Move
            Vector3 CamToTarget = Vector3.Normalize(Camera.main.transform.position - target.transform.position);

            Plane targetPlane = new Plane(CamToTarget, target.position);
            Ray ray = Camera.main.ScreenPointToRay(touchOne.position);

            float dist = 0.0f;
            targetPlane.Raycast(ray, out dist);
            Vector3 planePoint = ray.GetPoint(dist);


            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float des = Vector2.Dot(touchZero.deltaPosition, touchOne.deltaPosition);

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (des < 0)
            {
                if (camera.orthographic)
                {
                    // ... change the orthographic size based on the change in distance between the touches.
                    camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                    // Make sure the orthographic size never drops below zero.
                    camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
                }
                else
                {
                    // Otherwise change the field of view based on the change in distance between the touches.
                    camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                    // Clamp the field of view to make sure it's between 0 and 180.
                    camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
                }
                lastPlanePoint = Vector3.zero;
                move = false;
            }
            else
            {
                if (lastPlanePoint != Vector3.zero)
                {
                    
                    desVector = target.position + (lastPlanePoint - planePoint) * 160f;

                    //print(Vector3.Distance(desVector,tempDes).ToString());
                   //  if (Vector3.Distance(desVector,tempDes)> 800f)desVector = tempDes;
                    if (Mathf.Abs(desVector.x) > 5000f || Mathf.Abs(desVector.y) >5000f || Mathf.Abs(desVector.z) > 5000f) desVector = tempDes;
                    tempDes = desVector;
                    print(desVector);
                    move = true;
                      couroutine = MoveObject(target.position, desVector, 6f);
                      StartCoroutine(couroutine);
                }

                if (touchOne.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Ended)
                {
                    lastPlanePoint = Vector3.zero;
                    move = false;

                }
                else
                {
                    lastPlanePoint = planePoint;
                }
            }
        }
    }



    public void SetTargetPos(Vector3 TargetPosition,float FOV,bool _rotation)
    {
        if(_rotation)
        {
            xDeg = 0;
            yDeg = 0;
            currentRotation = Quaternion.identity;
            desiredRotation = Quaternion.identity;
        }
        target.position = TargetPosition;
        if(camera.orthographic)
        {
            if(FOV !=0)
            {
                StartCoroutine(lerpCamera(camera.orthographicSize, FOV, 0.65f));
            }
        }
        else
        {
            if (FOV != 0)
                StartCoroutine(lerpCamera(camera.fieldOfView, FOV, 0.65f));
        }
        
        
        MoveTarget();
     
    }

    public void SetTargetPosAndRotation(Vector3 TargetPosition)
    {

        //Init();
        // Rotate();
        //  Zoom();
        xDeg = 0;
        yDeg = 0;
        currentRotation = Quaternion.identity;
        desiredRotation = Quaternion.identity;
        target.position = TargetPosition;
        if(camera.orthographic)
            StartCoroutine(lerpCamera(camera.orthographicSize, zoomDefault, 1f));
        else
        {
            StartCoroutine(lerpCamera(camera.fieldOfView, zoomDefault, 1f));
        }
        
        MoveTarget();
    }

    IEnumerator CDLimitRot(float time) // Giới hạn sự di chuyển
    {
        time = 1;
        yield return null;

    }

    IEnumerator lerpCamera(float source, float des,float overTime)
    {
        float startTime = Time.time;
        if (camera.orthographic)
        {
            while (Time.time < startTime + overTime)
            {
                camera.orthographicSize = Mathf.Lerp(source, des, (Time.time - startTime) / overTime);
                yield return null;
            }
        }
        else
        {
            while (Time.time < startTime + overTime)
            {
                camera.fieldOfView = Mathf.Lerp(source, des, (Time.time - startTime) / overTime);
                yield return null;
            }
        }


    }
    IEnumerator MoveObject(Vector3 source, Vector3 targetDes, float overTime)
    {
        float startTime = Time.time;
        while (move&&(Time.time < startTime + overTime))
        {
            target.position = Vector3.Lerp(source, targetDes, (Time.time - startTime) / overTime);

            Move();
            yield return null;

        }
        //transform.position = target;
    }


 
    /// <summary>
    ///  Update cho việc di chuyển 2 touch
    /// </summary>
    private void FixedUpdate()
    {
       // if(move)

     //  transform.position = Vector3.Lerp(transform.position, desVector, 0.1f);
    }

    void Move()
    {
        if(!_moving)
        {
            position = target.position - (rotation * Vector3.forward * currentDistance + targetOffset);
            transform.position = position;
        }
        // calculate position based on the new currentDistance 
       
    }
    // Cái này dùng smooth di chuyển của camera lúc mà click dup đối chọn vào đối tượng
    void MoveTarget()
    {
        _rot = false;
        position = target.position - (rotation * Vector3.forward * currentDistance + targetOffset);
        Vector3 source = transform.position;
        
        IEnumerator smoothCoroutine = Smoothcam(source,position,0.3f);
        StartCoroutine(smoothCoroutine);
        Debug.Log("thuc thi");
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    IEnumerator Smoothcam(Vector3 source, Vector3 targetDes, float overTime)
    {
        _moving = true;
        float startTime = Time.time;
        while ((Time.time < startTime + overTime))
        {
           // float step = speed * Time.deltaTime;
            transform.position = Vector3.Lerp(source, targetDes, (Time.time - startTime) / overTime);
            yield return null;
        }


        _moving = false;
        _rot = true;
        Debug.Log("lai thuc thi");
   
    //transform.position = target;
}



    public void RefreshCam()
    {
        
        SetTargetPosAndRotation(_centerPivot );
    }

   

}