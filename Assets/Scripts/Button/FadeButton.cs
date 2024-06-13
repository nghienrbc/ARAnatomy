using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FadeButton : MonoBehaviour, IPointerClickHandler
{
    int tap;
    float interval = 0.3f;
    bool readyForDoubleTap;

    HumanController humanController;
    public void Start()
    {
        humanController = GameObject.FindGameObjectWithTag("GameController").GetComponent<HumanController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        tap++;

        if (tap == 1)
        {
            humanController.FadeObject();

            StartCoroutine(DoubleTapInterval());
        }

        else if (tap > 1 && readyForDoubleTap)
        {

            humanController.RestoreAllFade();

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