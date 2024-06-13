using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;


    public class FindGroupAndLoadJsonData : MonoBehaviour
    {

        [Tooltip("Giá trị để Camera có thể view đẹp nhất Group đó")]
        public float _cameraZoom;
        [Tooltip("Offset Cho phù hợp với góc view")]
        public Vector3 OffsetCamTarget;

        public string ID;
        [Tooltip("Mặc định cái này load đầu tiên khi chuyển scene")]
        public bool StartLoading;
        private int id;
        JsonData datajson;
        HumanController humanController;
        public List<DataJsonText> DataJsonArray = new List<DataJsonText>(); // Đây là list chứa thông tin của từng nhóm
                                                                            // Tương ứng mỗi nhóm lúc cần truy xuất sẽ truy xuất vào list này để liệt kê giá trị
                                                                            // không cần tìm kiếm lại để đỡ mất việc xử lý của CPU
                                                                            // Cần có một biến tạm để hiển thị lúc search
                                                                            // lúc gõ phím so sánh với giá trị này. Các giá trị xuất hiện sẽ được trả lại vào list tạm và hiển thị ở search table

        private Button _button;
        private GroupManager _groupmanager;
        void Awake()
        {


        }

        void Start()
        {

            _button = GetComponent<Button>();
            GameObject gam = GameObject.FindGameObjectWithTag("GameController");
            if (gam != null)
            {
                _groupmanager = gam.GetComponent<GroupManager>();
                humanController = gam.GetComponent<HumanController>();
            }

            FindNSaveObjectFromIDtoArray(ID);

            _button.onClick.AddListener(delegate { LoadGroup(); });


            if (StartLoading) LoadGroup();
            //StartCoroutine(DelayLoading(2f));
        }



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
                        // Gán dữ liệu json 
                        DataJsonText jsondataobject = new DataJsonText(temp, ReadJson.Information["information"][temp]["VNName"].ToString(),
                           ReadJson.Information["information"][temp]["Name"].ToString(), ReadJson.Information["information"][temp]["ENName"].ToString());

                        DataJsonArray.Add(jsondataobject);
                    }
                    //  datajson = JsonMapper.ToJson(DataJsonArray);
                    // ************************************* Thay tên của Json cần tạo ở đây 
                    //  File.WriteAllText(Application.dataPath + "/BoneFull.json", datajson.ToString());
                }
            }
        }

        private void OnDisable()
        {
            DataJsonArray.Clear();
        }


        // 



        public void LoadGroup()
        {

            _groupmanager.LoadGroup(DataJsonArray, _cameraZoom, OffsetCamTarget, this);

        }

        IEnumerator DelayLoading(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            LoadGroup();
        }
    }