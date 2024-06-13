using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.EventSystems; 
public class HumanController : MonoBehaviour {

    private float time;
    private int countDetect; // Phát hiện giữa các lần nhấn
    private int id; // id tìm kiếm trong json đc trả về
    private RaycastHit hit;
    private Vector2 posBeginZero; 
    private CameraMove camMove; // chiuj trach nhiệm cho việc di chuyển camera
    private Vector3 pivot, centerPivot;
    private HashSet<MethodOfObject> _ObjectClickArray = new HashSet<MethodOfObject>(); // Toanf booj object click sẽ được lưu vào . cũng là những đối tượng để Show
    private HashSet<MethodOfObject> _ObjectShowArray = new HashSet<MethodOfObject>(); // Mảng chứa Toàn bộ đối tượng để Show
    private HashSet<MethodOfObject> _HideArray = new HashSet<MethodOfObject>(); // Mảng chứa Toàn bộ đối tượng để Hide
    private HashSet<MethodOfObject> _FadeArray = new HashSet<MethodOfObject>(); // Mảng chứa Toàn bộ đối tượng để Fade
    private MethodOfObject inv;// Object is selected
    
    private string namePrevDetect;
    private bool dubNameDect;
    private bool _doubleClick;// Nhận biết double click giữa 2 lần touch
    private bool _oneSelect = true; // Switch between multi select and One Select 
    private bool _showMode,_showOtherMode;
    private GroupManager groupManager;

    private UI3Manager UI3;

    public Vector3 offsetTarget= new Vector3 (0,-25,0);

    // Sự kiện active (Tối ưu hóa)
    public delegate void ActiveAction(bool val);
    public static event ActiveAction OnInactive;
    public static int _idNow; // id now of selected Object

    public bool isTurnoffCam = true;
     
    // Use this for initialization
    void Start () {
        GameObject cam = GameObject.Find("Cam/MainCamera");
        if(isTurnoffCam)
        camMove = cam.GetComponent<CameraMove>();
        UI3 = GameObject.FindGameObjectWithTag("UI3").GetComponent<UI3Manager>();
        groupManager = GetComponent<GroupManager>();

         
    }
	
	// Update is called once per frame
	void Update () {

        time += Time.fixedDeltaTime;
        if (!(Input.touchCount > 0)) return;
        if (EventSystem.current.IsPointerOverGameObject(0) || EventSystem.current.IsPointerOverGameObject(1))
        {
       
            countDetect = 2;
        }
        if (Input.touchCount > 0 && (!EventSystem.current.IsPointerOverGameObject(0) || !EventSystem.current.IsPointerOverGameObject(1)))
        {
            countDetect--;



            if (countDetect < 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    // Record initial touch position. // Mai làm tiếp chỗ này. Nhận diện 2 lần touch trong khoảng thời gian x giây
                    case TouchPhase.Began:
                        {

                           // _Once = true;
                            posBeginZero = touch.position; //
                            break;
                        }

                    case TouchPhase.Moved:

                        break;
                    case TouchPhase.Ended:
                        {

                            Vector3 deltaPos = touch.position - posBeginZero;
                            float deltaMag = Vector3.Magnitude(deltaPos);

                            if (deltaMag < 15f) // nếu touch di chuyển thì sẽ ko chọn select
                            {
                                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                                if (Physics.Raycast(ray, out hit))
                                {
                                    // nếu bắt trúng đối tượng trước đó thì ko làm gì
                                    if (hit.transform.tag == "Player")
                                    {
                                        
                                        // Check Double
                                        if (time > 0.5f)
                                        {
                                            _doubleClick = false;
                                        }
                                        else
                                        {
                                            _doubleClick = true;
                                            //Debug.Log("Double Click");
                                        }

                                        SelectFunc();

                                        // fade();
                                    }
                                    time = 0;
                                }
                            }
                            break;
                        }
                }

            }
        }
    }




    public void OnDisableAllMesh()
    {
        OnInactive(false);
    }

    public void ClearShowAndFadeArray()
    {
        
        RestoreAllFade();
        // Clear 2 mảng này để lúc nhấn chuyển sang group khác nút ẩn hiện hoặc fade sẽ ko hiện lên object đó gây ra lỗ
        _ObjectShowArray.Clear();
        _FadeArray.Clear();
        _HideArray.Clear();
        
        // 
    }

    //*****************************************************************************************************
    // Mode này để show object // Thuaatj toan hơi tốn kém tí :))
    public void ShowMode()
    {
        if (_ObjectClickArray.Count == 0 &&!_showMode) return;
        _showMode = !_showMode;
      //  if (!_oneSelect) MultiSelectFunc();
      if(_showMode)
        {
            CopyAToB(_ObjectClickArray, _ObjectShowArray);
            RestoreMaterial(); // Restore laji vaatj lieu hien co. đồng thời cũng xóa đi những object đã click trước đó
            OnInactive(false);
            // Active những object đã chọn trong show Array
            ActiveComponent(_ObjectShowArray,true);

        }
      else
        {
            GroupManager._buttonIsClicking.LoadGroup();
           // OnInactive(true);
            _ObjectClickArray.Clear();
            
        }

    }


    //***************FADE OBJECT ********************

    public void FadeObject()
    {

        if (_oneSelect)
        {
            foreach (MethodOfObject meo in _ObjectClickArray)
            {
                if (meo.fade)
                {
                    meo.SetFadeMat(); // Set Fade Object 
                    _FadeArray.Add(meo); // Add vào mảng Fade 

                }
                else
                {
                    meo.RestoreFade();  // Trả về trạng thái ban đầu
                    _FadeArray.Remove(meo); //  remove element vừa thực hiện
                }

                meo.fade = !meo.fade;
            }

        }

        else
        {
            foreach (MethodOfObject meo in _ObjectClickArray)
            {
                if (meo.fade)
                {
                    meo.SetFadeMat(); // Set Fade Object 
                    _FadeArray.Add(meo); // Add vào mảng Fade 

                }
            }
        }
    }

    // *******************RESTORE ALL FADE***********************************************

    public void RestoreAllFade()
    {
        foreach (MethodOfObject meo in _FadeArray)
        {
            meo.RestoreFade(); // Restore 
        }
        _FadeArray.Clear();
    }


   //*******************HIDE OBJECT ******************************************************
   public void HideObject()
    {
        if(_ObjectClickArray !=null)
        {
            foreach(MethodOfObject meo in _ObjectClickArray)
            {
                meo.SetActiveObjectInv(false);
                _HideArray.Add(meo);
            }
        }
    }

    // *******************VISIBLE OBJECT ******************************************************

   public void VisibleObject()
    {
         foreach(MethodOfObject meo in _HideArray)
        {
            meo.SetActiveObjectInv(true);
        }
        _HideArray.Clear();
       
    }

    public void Deselect()
    {
        RestoreMaterial();  
    }
    /*
    //*****************************************************************************************************
    // Mode Show Other
    public void ShowOtherMode()
    {
        if (_ObjectClickArray.Count == 0 && !_showOtherMode) return;
        _showOtherMode = !_showOtherMode;
        if (_showOtherMode)
        {
            CopyAToB(_ObjectClickArray, _ObjectShowArray);
            RestoreMaterial(); // Restore laji vaatj lieu hien co. đồng thời cũng xóa đi những object đã click trước đó
            groupManager._buttonIsClicking.LoadGroup();
            // Active những object đã chọn trong show Array
            ActiveComponent(_ObjectShowArray, false);

        }
        else
        {
            groupManager._buttonIsClicking.LoadGroup();
            // OnInactive(true);
            _ObjectClickArray.Clear();

        }
    }
    */
    //*****************************************************************************************************


    public void ActiveComponent(HashSet<MethodOfObject> MeOArray,bool status)
    {
        Vector3 _pivotObjectSelect = Vector3.zero;
        if(MeOArray!=null)
        {
            // Duyệt các phần tử trong mảng đã chọn ( đã click vào) 
            // Tính toán Pivot và active từng component của nó
            foreach(MethodOfObject Obr in MeOArray)
            {

                Obr.SetActiveObjectInv(status);
                // Tính toán tọa độ trung tâm của nhóm này
                _pivotObjectSelect += Obr.transform.GetComponent<Renderer>().bounds.center;
            }
            int _count = MeOArray.Count;
            Vector3 _centerPivotObjectSelect = new Vector3(_pivotObjectSelect.x / _count, _pivotObjectSelect.y / _count, _pivotObjectSelect.z / _count);
            camMove.SetTargetPos(_centerPivotObjectSelect, 0, true);
        }
    }

    // Find id of Name Object in Json data of Information File
    public int FindInformationInJson(string name, string jsonCompare)
    {
        for (int i = 0; i < ReadJson.Information["information"].Count; i++)
        {
            if (ReadJson.Information["information"][i][jsonCompare].ToString() == name)
            {
                id = i;
                break;
            }
            else id = -1;
        }

        if (id == -1)
            return -1; // trả về  - 1 nếu ko có model trong database
        else
            return id; // trả về giá trị mong muốn
    }

    // Switch between 2 status OneSelect and Multiselect
    public void MultiSelectFunc()
    {
        RestoreMaterial();
        _oneSelect = !_oneSelect;

    }

    public void RestoreMaterial()
    {
        foreach (MethodOfObject obj in _ObjectClickArray)
        {
            obj.Restore();
        }
        _ObjectClickArray.Clear();
    }

    // Restore Array
    public void RestoreArrayAndMat(HashSet<MethodOfObject> a)
    {
        if(a!=null)
        {
            foreach(MethodOfObject h in a)
            {
                h.Restore();

            }

            a.Clear();
        }
    }


    public void RandomSelect()
    {
        // Trar hết giá trị về trangjthais ban đầu
        RestoreALL();
        // random một phần tử trong mảng chứa nhóm đang hiển thị
        int ran = UnityEngine.Random.Range(0, GroupManager._buttonIsClicking.DataJsonArray.Count);
        string _name = GroupManager._buttonIsClicking.DataJsonArray[ran].modelName;
        SelectObjectRandom(_name);

    }


    public void SearchButtonCell(string _name)
    {
        ResetAll();
        SelectObjectRandom(_name);

    }

    // *********************************************************************

        public void SelectObjectRandom(string _name)
    {
        GameObject go = GameObject.Find("Root/Bone/" + _name);
        if(go!=null)
        {
            MethodOfObject meo = go.GetComponent<MethodOfObject>();
            meo.setColorMat();
            inv = meo;
            namePrevDetect = _name;
            //Add list click
            _ObjectClickArray.Add(meo);
            camMove.SetTargetPos(meo.GetComponent<Renderer>().bounds.center, 9, true);
            // Tìm id của Object
            int id = FindInformationInJson(_name, "Name");
            if (id == -1) return;
            _idNow = id;
            UI3.ChangeLanguage();
        }

    }




    // **************RESET ALL *********************************************
    // reset camera and all value 
    public void ResetAll()
    {
        RestoreALL();
        GroupManager._buttonIsClicking.LoadGroup();

    }


    // Trả hết giá trị về mặc định
    public void RestoreALL()
    {
        RestoreMaterial();
        RestoreArrayAndMat(_FadeArray);
        RestoreArrayAndMat(_ObjectShowArray);
        RestoreArrayAndMat(_HideArray);
    }

    public void SelectFunc()
    {
        // One Select
        if (_oneSelect)
        {
            if (namePrevDetect == hit.transform.name && !_doubleClick)
            {
                inv.Restore();
                // Clear Object Array when object prev was clicked
                _ObjectClickArray.Clear();

                // set Name Prev Detect is "" to compare next time
                namePrevDetect = "";
                return;
            }
            else if (namePrevDetect == hit.transform.name && _doubleClick)
            {
                // set camera to center view of Object
                camMove.SetTargetPos(hit.transform.GetComponent<Renderer>().bounds.center + offsetTarget , 0,false);
                return;
            }
            // Remove If when click other Object

            if (inv != null)
                inv.Restore();
            _ObjectClickArray.Clear();
            // Set Color for Object is Selected
            hit.transform.GetComponent<MethodOfObject>().setColorMat();
            // 
            inv = hit.transform.GetComponent<MethodOfObject>();
            // the selected object is object  click
            namePrevDetect = hit.transform.name;
            // Add object selected to Object Selected Array
            _ObjectClickArray.Add(inv);
            // ******************** Test show object tại đây để tránh tình trạng copy mất thời gian khi nhấn show

            // Find id Of Object in Information Json File
            int id = FindInformationInJson(inv.name, "Name");
            if (id == -1) return;
            _idNow = id;
            UI3.ChangeLanguage();
        }

        else
        {
            foreach (MethodOfObject obj in _ObjectClickArray)
            {
                if (hit.transform.name == obj.name && !_doubleClick)
                {
                    dubNameDect = true;
                    _ObjectClickArray.Remove(obj);

                    obj.GetComponent<MethodOfObject>().Restore();
                    break;
                }
                else if (hit.transform.name == obj.name && _doubleClick)
                {
                    StartCoroutine(GetPivot());
                    break;
                }
                //     
            }
            if (dubNameDect)
            {
                dubNameDect = false;
                return;
            }
            else
            {
                inv = hit.transform.GetComponent<MethodOfObject>();
                inv.setColorMat();
                //   rend = hit.transform.GetComponent<Renderer>();
                //   rend.sharedMaterial = materials;
                //  Model3D model = new Model3D(hit.transform.gameObject);
                _ObjectClickArray.Add(inv);

                int id = FindInformationInJson(inv.name, "Name");
                if (id == -1) return;
                _idNow = id;
                UI3.ChangeLanguage();
            }
        }
     
    }

    IEnumerator GetPivot()
    {

        centerPivot = Vector3.zero;
        pivot = Vector3.zero;
        foreach (MethodOfObject obj in _ObjectClickArray)
        {
            pivot += obj.transform.GetComponent<Renderer>().bounds.center;
        }
        int _cont = _ObjectClickArray.Count;
        centerPivot = new Vector3(pivot.x / _cont, pivot.y / _cont, pivot.z / _cont);
        pivot = Vector3.zero;
        camMove.SetTargetPos(centerPivot+offsetTarget, 0,false);
        yield return null;
    }


  // Copy Hashset B 
    public static void CopyAToB<T>(HashSet<T> a, HashSet<T> b)
    {
        if (a.Count > 0)
        { 
            // Clear Object
            b.Clear();
            foreach (T obj in a)
            {
                b.Add(obj);
            }
        }
    }

    public static void CopyListAToB<T>(List<T> a, List<T> b)
    {
        if (a.Count > 0)
        {
            // Clear Object
            b.Clear();
            foreach (T obj in a)
            {
                b.Add(obj);
            }
        }
    }

}
