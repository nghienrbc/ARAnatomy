using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using UnityEngine.UI;

public class ReadJson : MonoBehaviour {
    public static JsonData Information; // chứa thông tin id và tên của model
    public static JsonData Location; // Chứa thông tin group

    public static JsonData ImaTargetDatabase;
    void Awake()
    {
        TextAsset file = Resources.Load("information") as TextAsset;
        string jsonString = file.ToString();

        Information = JsonMapper.ToObject(jsonString);

        file = Resources.Load("location") as TextAsset;
        jsonString = file.ToString();

        Location = JsonMapper.ToObject(jsonString);

        print("Location = " + Location["location"].Count);

        file = Resources.Load("ImageTargetDatabase") as TextAsset;
        jsonString = file.ToString();

        ImaTargetDatabase = JsonMapper.ToObject(jsonString);
        print("Image Database = " + ImaTargetDatabase["ImageTargetDatabase"].Count);


    }

    void Start()
    {
        

    }
}
