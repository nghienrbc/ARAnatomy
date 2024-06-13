using UnityEngine;
using System.Collections;

public class SearchTableView : MonoBehaviour, UITableViewDelegate, UITableViewDataSource
{
    public GameObject cellPrefab;
    public bool Search;
  //  public bool Group;

    //private uint Row;
    public float heightForIndex = 84;
    void Awake()
    {
        UITableView tableview = GetComponent<UITableView>();
        tableview.Delegate = this;
        tableview.Datasource = this;

    }

    void OnEnable()
    {
        /*if (Search) //.....................
            Row = (uint)GroupManager._rowCount;
            */
    }
    void UITableViewDelegate.OnScrollChanged(Vector2 pos)
    {

    }

    float UITableViewDelegate.HeightForIndex(UITableView tableview, int index)
    {
        return heightForIndex;
    }

    uint UITableViewDataSource.NumberOfCells(UITableView tableview)
    {
        if (Search)
            return (uint)GroupManager._rowCount;
        else return (uint)80;
    }

    UITableViewCell UITableViewDataSource.CellForIndex(UITableView tableview, int index)
    {
        UITableViewCell cell = tableview.DequeueReusableCell();
        if (null == cell)
        {
            GameObject obj = (GameObject)Instantiate(cellPrefab);
            cell = obj.GetComponent<UITableViewCell>();
        }

        cell.index = index; //only required for testing
      if (Search)
        {
            SearchTableCell testCell = (SearchTableCell)cell;
            testCell.UpdateData();
        }

      /*  if (Group)
        {
            GroupTableViewCell testCell = (GroupTableViewCell)cell;
            testCell.UpdateData();
        }
        */
        
        return cell;
    }

}
