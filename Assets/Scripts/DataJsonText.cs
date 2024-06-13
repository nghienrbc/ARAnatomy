using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataJsonText
{
    public int id;
    public string VNname;
    public string modelName;
    public string ENname;

    public DataJsonText(int _id, string _vname, string _modelName, string _enname)
    {
        VNname = _vname;
        id = _id;
        modelName = _modelName;
        ENname = _enname;
    }
}

public class ARDataClass
{
    public string namecard;
    public List<DataJsonText> ListArrayObjectImageTarget;
     // Đây là list chứa từng đối tượng đã load sẵn tương ứng mỗi list là mỗi ImageTarget

    public  ARDataClass (string _namecard,List<DataJsonText> _ListArrayObjectImageTarget)
    {
        namecard = _namecard;
       
       // ListArrayObjectImageTarget = _ListArrayObjectImageTarget;
        
    }
}
