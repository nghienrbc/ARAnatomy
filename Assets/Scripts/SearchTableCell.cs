using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SearchTableCell : UITableViewCell
{
    public Text nameText;
    private int _index;
    HumanController humanController;
    private void Start()
    {
        humanController = GameObject.Find("Controller").GetComponent<HumanController>();
    }


    public void UpdateData()
    {
        //	nameText.text = "index="+index;
        gameObject.name = "index=" + index;
        _index = index;
        if (VarStatic._language == 0)
            nameText.text = GroupManager._buttonIsClicking.GetComponent<FindGroupAndLoadJsonData>().DataJsonArray[index].VNname;
        else
            nameText.text = GroupManager._buttonIsClicking.GetComponent<FindGroupAndLoadJsonData>().DataJsonArray[index].ENname; ;

    }

    public void OnClickButton()
    {
        // _modeSelect.SearchClickButton(GroupManager.GroupModelListTemp[_index].modelName);
        humanController.SearchButtonCell(GroupManager._buttonIsClicking.DataJsonArray[_index].modelName);
    }

}
