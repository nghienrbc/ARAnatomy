using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockMovement : MonoBehaviour,IPointerDownHandler,IPointerExitHandler,IPointerUpHandler {


    public void OnPointerDown(PointerEventData eventData)
    {
            CameraMove._OnPointerUI = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CameraMove._OnPointerUI = false;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        CameraMove._OnPointerUI = false;
    }
}
