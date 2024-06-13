using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameObject UI001;
    public GameObject UI002;


    public void Start()
    {
        if(VarStatic.Back)
        {
            ActiveLv002();
        }
    }
    public void ActiveLv002()
    {
        UI001.SetActive(false);
        UI002.SetActive(true);
    }

    public void BackLv001()
    {
        UI002.SetActive(false);
        UI001.SetActive(true);
    }

    public void LoadleveAR()
    {

    }
}
