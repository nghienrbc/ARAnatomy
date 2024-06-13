using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointer : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerUpHandler,IPointerDownHandler, IDragHandler
{
    void Update()
    {
        if(Input.touchCount == 0) CameraMove._OnPointerUI = false;
    }

 public void OnPointerEnter(PointerEventData eventData)
    {
     //   Debug.Log("Enter");
        CameraMove._OnPointerUI = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit");
        CameraMove._OnPointerUI = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      //  Debug.Log("Up");
        CameraMove._OnPointerUI = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        CameraMove._OnPointerUI = true;
       //Debug.Log("Click");
    }

    public void OnDrag(PointerEventData data)
    {
        CameraMove._OnPointerUI = true;
    }

}
