using System.Collections;
using UnityEngine;

public class FaceBookShare : MonoBehaviour {

    public string AppID = "707999266071853";


    public string Link = "";



    public string Picture = "http://xmasjazzy.com/Pic/HumanBody/icon.png";


    public string Name = "Phần mềm giải phẩu";


    public string Caption = "Phần mềm Giải phẩu Human Anatomy";


    public string Description = "Mô tả phần mềm";



    public void ShareScoreOnFB()
    {

        Application.OpenURL("https://www.facebook.com/dialog/feed?" + "app_id=" + AppID + "&link=" + Link + "&picture=" + Picture + "&name=" + ReplaceSpace(Name) + "&caption=" + ReplaceSpace(Caption) + "&description=" + ReplaceSpace(Description) + "&redirect_uri=https://facebook.com/");

    }


    string ReplaceSpace(string val)
    {

        return val.Replace(" ", "%20");

    }

}
