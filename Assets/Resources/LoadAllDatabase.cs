using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
 
public class LoadAllDatabase : MonoBehaviour {
    // Dữ liệu được load từ id now
    // Idnow cos dudowcj bằng click vào object và search ngược trở lại
    GroupManager _groupmanager;

    public List<ARDataClass> ARclassData = new List<ARDataClass>();
    HumanController humanController;
//   List<DataJsonText> toDeclare = new List<DataJsonText>();
    List<DataJsonText> DataJsonArray = new List<DataJsonText>();
    //ARDataClass arTemp = new ARDataClass("a",new List<DataJsonText>()); 

    private void Start()
    {
        
        GameObject gam = GameObject.FindGameObjectWithTag("GameController");
        if (gam != null)
        {
            _groupmanager = gam.GetComponent<GroupManager>();
            humanController = gam.GetComponent<HumanController>();
        }
        GetAndAddToARclassList();
    }

    /// <summary>
    /// 
    /// </summary>
    private void GetAndAddToARclassList()
    {
       
      //  Debug.Log("Image Data Count = " + ReadJson.ImaTargetDatabase["ImageTargetDatabase"].Count);
        for(int i = 0; i<ReadJson.ImaTargetDatabase["ImageTargetDatabase"].Count;i++)
        {
            ARDataClass arTemp = new ARDataClass("a", new List<DataJsonText>());
            arTemp.namecard = ReadJson.ImaTargetDatabase["ImageTargetDatabase"][i]["namecard"].ToString();
           
            DataJsonArray.Clear();
            FindNSaveObjectFromIDtoArray(ReadJson.ImaTargetDatabase["ImageTargetDatabase"][i]["GID"].ToString());
           
            if (i >= 1)
                print("before Add to list = " +  ARclassData[i - 1].ListArrayObjectImageTarget.Count);
          
            // arTemp.ListArrayObjectImageTarget.Clear();
            arTemp.ListArrayObjectImageTarget = DataJsonArray.ToList();
            

            ARclassData.Add(arTemp);

       
        }

      
   
        
    }

    private void FindNSaveObjectFromIDtoArray(string ID)
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

    public void FindListDatabaseAndLoadModel(string idname)
    {
        int count = ARclassData.Count;
        for(int i = 0; i<count; i++)
        {
            if(idname == ARclassData[i].namecard)
            {
                _groupmanager.LoadGroupAR(ARclassData[i].ListArrayObjectImageTarget);
            }
        }
    }
   

} 
