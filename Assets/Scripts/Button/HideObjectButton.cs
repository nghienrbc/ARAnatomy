using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideObjectButton : MonoBehaviour,IPointerClickHandler
{

   private HumanController humanController;
   int tap;
   float interval = 0.3f;
   bool readyForDoubleTap;

    // Use this for initialization
    void Start () {
        humanController = GameObject.FindGameObjectWithTag("GameController").GetComponent<HumanController>();
    }

public void OnPointerClick(PointerEventData eventData)
    {
        tap++;

        if (tap == 1)
        {
            humanController.HideObject();

            StartCoroutine(DoubleTapInterval());
        }

        else if (tap > 1 && readyForDoubleTap)
        {

            humanController.VisibleObject();

            tap = 0;
            readyForDoubleTap = false;
            //   Debug.Log("Co Fade ALl");
        }

    }


    IEnumerator DoubleTapInterval()
    {
        yield return new WaitForSeconds(interval);
        readyForDoubleTap = true;
        tap = 0;
    }
}
