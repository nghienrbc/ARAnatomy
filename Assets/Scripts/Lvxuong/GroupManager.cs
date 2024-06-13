using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// tạo cái này để thuận tiện cho việc tìm kiếm
/*
public class InforGroupModel
{
    public string VNname;
    public int ID;
    public string modelName;
    public string ENname;
    public InforGroupModel(string _vname, string _modelName, int _id, string _enname)
    {
        VNname = _vname;
        ID = _id;
        modelName = _modelName;
        ENname = _enname;
    }
}
*/
    public class GroupManager : MonoBehaviour {


    
        private HumanController humanController;
        private CameraMove camMove;
    [HideInInspector]
    public static FindGroupAndLoadJsonData _buttonIsClicking; // dùng để nhận biết là button group nào đang được chọn
    public static List<DataJsonText> _SearchArray = new List<DataJsonText>(); //  Đây là biến để lưu trữ array để hiển thị
    public Search _searchGameObject;// Mục đích để update dữ liệu lúc nhấn vào mỗi hệ
                                        // khi nhấn vào dữ liệu sẽ load
    public static int _rowCount; // Biến này là thông tin hàng của search table 
                                  // Giá trị của nó là số phần tử trong list được chọn

    private Vector3 _pivotElement,CenterPivot;
    
        // Use this for initialization
        void Start() {
            humanController = GetComponent<HumanController>();
        camMove = Camera.main.GetComponent<CameraMove>();
        
        }

        // Update is called once per frame
        void Update() {

        }

    public void LoadGroup(List<DataJsonText> list,float _cameraZoom,Vector3 offsetCamTarget,FindGroupAndLoadJsonData btclicking) // list DataJsonText này chứa thông tin của mỗi nhóm                                                 
    {

        _searchGameObject.DisableSearch();
        humanController.ClearShowAndFadeArray();// chúng ta cần load nó lên mỗi lần khi ấn vào nút nhấn
        _buttonIsClicking = btclicking;
        humanController.OnDisableAllMesh();
        int count = 0;
        CenterPivot = Vector3.zero;
        _pivotElement = Vector3.zero;
        foreach (DataJsonText data in list)
        {
            GameObject go = GameObject.Find("Root/Bone/" + data.modelName);
            if(go!=null)
            {
                go.GetComponent<MeshRenderer>().enabled = true;
                go.GetComponent<MeshCollider>().enabled = true;
                go.GetComponent<MethodOfObject>().enabled = true;
                _pivotElement += go.transform.GetComponent<Renderer>().bounds.center;
                count++;
            }
        }
        CenterPivot = new Vector3(_pivotElement.x / count, _pivotElement.y / count, _pivotElement.z / count) + offsetCamTarget;
        //Setting Camera  Lookat All Object
        camMove.SetTargetPos(CenterPivot, _cameraZoom,true);
        _rowCount = list.Count;
       // camMove.camera.fieldOfView = _cameraZoom;
       // camMove.zoomDefault = _cameraZoom;
    }

    public void LoadGroupAR(List<DataJsonText> list) // list DataJsonText này chứa thông tin của mỗi nhóm                                                 
    {

        _searchGameObject.DisableSearch();
        humanController.ClearShowAndFadeArray();// chúng ta cần load nó lên mỗi lần khi ấn vào nút nhấn
        
        humanController.OnDisableAllMesh();
        int count = 0;
        CenterPivot = Vector3.zero;
        _pivotElement = Vector3.zero;
        foreach (DataJsonText data in list)
        {
            GameObject go = GameObject.Find("Root/Bone/" + data.modelName);
            if (go != null)
            {
                go.GetComponent<MeshRenderer>().enabled = true;
                go.GetComponent<MeshCollider>().enabled = true;
                go.GetComponent<MethodOfObject>().enabled = true;
                _pivotElement += go.transform.GetComponent<Renderer>().bounds.center;
                count++;
            }
        }
        _rowCount = list.Count;
        // camMove.camera.fieldOfView = _cameraZoom;
        // camMove.zoomDefault = _cameraZoom;
    }


    /*
        public void FindNSaveObjectFromIDtoArray(string ID)
        {

            for (int i = 0; i < ReadJson.Location["location"].Count; i++)
            {
                if (ReadJson.Location["location"][i]["GID"].ToString() == ID)
                {

                    string meshId = ReadJson.Location["location"][i]["MID"].ToString();
                    // liệt kê toàn bộ giá trj trong information 
                    //sau đó đối chiếu với mesh id () 
                    int temp = humanController.FindInformationInJson(meshId, "IID");
                    if (temp != -1)
                    {

                    }
                }
            }
        }

    */


}
