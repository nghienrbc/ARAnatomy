using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SearchBar : MonoBehaviour
{
    // string[] strArray = { "the ABCDEFG", "t HIJKLMNOP","JKLE","JKL A", "the sun" };
    string findThisString = "JKL";
    int strNumber;
    int strIndex = 0;
    Search _Search;
    private void Start()
    {
        _Search = GameObject.Find("UI/UI003/RightTool/Search").GetComponent<Search>(); // Đường dẫn của Search Button
    }

    public void OnChangeValue()
    {
        findThisString = GetComponent<InputField>().text.ToString();
        //Debug.Log(GetComponent<InputField>().text);
        // int index = Array.IndexOf(names, GetComponent<InputField>().text.ToString());
        //Debug.Log(index);

        // Search Array lưu thông tin đã tìm kiếm được
        // DatajsonArray chứa thông tin all search để hiển thị
        GroupManager._SearchArray.Clear();
        int count = 0;
        for (int i = 0; i < GroupManager._buttonIsClicking.DataJsonArray.Count; i++)
        {

            strIndex = GroupManager._buttonIsClicking.DataJsonArray[i].VNname.IndexOf(findThisString);

            if (strIndex >= 0)
            {
                GroupManager._SearchArray.Add(GroupManager._buttonIsClicking.DataJsonArray[i]);
                count++;
            }

        }
        Debug.Log("count ===" + count.ToString());
        Debug.Log(GroupManager._SearchArray.Count);
        _Search.EnableSearch();
    }

}
