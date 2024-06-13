using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeselectButton : MonoBehaviour, IPointerClickHandler
{

    private HumanController humanController;

    // Use this for initialization
    void Start()
    {
        humanController = GameObject.FindGameObjectWithTag("GameController").GetComponent<HumanController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        humanController.Deselect();

    }

}
