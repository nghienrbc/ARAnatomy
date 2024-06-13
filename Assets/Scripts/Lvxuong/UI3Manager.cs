using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI3Manager : MonoBehaviour {

    public Text DescriptionText;
    public Text TitleText;
    public Text Latintext;




    // Change Language
    public void ChangeLanguage()
    {
       // 
        if (VarStatic._language == 0)
        {
            TitleText.text = ReadJson.Information["information"][HumanController._idNow]["VNName"].ToString();
            DescriptionText.text = ReadJson.Information["information"][HumanController._idNow]["Descript"].ToString();
            Latintext.text = ReadJson.Information["information"][HumanController._idNow]["SName"].ToString();
        }
        else if (VarStatic._language ==1)
        {
            Debug.Log(HumanController._idNow);
            Latintext.text = ReadJson.Information["information"][HumanController._idNow]["SName"].ToString();
            TitleText.text = ReadJson.Information["information"][HumanController._idNow]["ENName"].ToString();
            DescriptionText.text = ReadJson.Information["information"][HumanController._idNow]["EDescript"].ToString();
        }
    }
}
