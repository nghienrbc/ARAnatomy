using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SetPositionEnable : MonoBehaviour{

    private void OnEnable()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
