using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : MonoBehaviour
{

    private GameObject SearchPanel;
    private Vector3 des = new Vector3(1, 1, 1); // Hiệu ứng scale nhỏ đến lớn và ngược lại
    public bool Value = false;
    // Use this for initialization



    void Start()
    {
        SearchPanel = GameObject.Find("UI/Panel/Panel1");
        SearchPanel.SetActive(false);

    }




    public void ScaleOverTime()
    {
        Value = !Value;
        if (Value)
        {
            SearchPanel.SetActive(true);
            SearchPanel.GetComponentInChildren<UITableView>().enabled = true;
        }

        else
        {
            SearchPanel.SetActive(false);
            SearchPanel.GetComponentInChildren<UITableView>().enabled = false;
        }

        /* StartCoroutine(_ScaleOverTime(0.6f,SearchPanel.transform.localScale, des));
         else
          StartCoroutine(_ScaleOverTime(0.6f, SearchPanel.transform.localScale, Vector3.zero));
          */
    }

    // Tắt Search bar

    public void DisableSearch()
    {
        Value = false;
        SearchPanel.SetActive(false);
        SearchPanel.GetComponentInChildren<UITableView>().enabled = false;
        StartCoroutine(CDEndFrame());
    }


    // Kích hoạt Search Bar
    public void EnableSearch()
    {
        SearchPanel.GetComponentInChildren<UITableView>().enabled = false;
        SearchPanel.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        StartCoroutine(CDEndFrame());

    }


    // Scale OverTime
    IEnumerator _ScaleOverTime(float time, Vector3 orgScale, Vector3 desScale)
    {
        float currentTime = 0f;

        do
        {
            SearchPanel.transform.localScale = Vector3.Lerp(orgScale, desScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
        while ((currentTime <= time));
    }

    IEnumerator CDEndFrame()
    {
        yield return new WaitForSeconds(0.1f);
        SearchPanel.GetComponentInChildren<UITableView>().enabled = true;
        SearchPanel.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
    }
}
