using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Changelanguage : MonoBehaviour {
    public Sprite[] _languageICon;
    private Image _languageImage;
    // Use this for initialization
    void Start () {
        _languageImage = GetComponent<Image>();
	}

    public void ChangeLanguageSprite()
    {
        VarStatic._language = (VarStatic._language == 0) ? 1 : 0;
        _languageImage.sprite = VarStatic._language == 0 ? _languageICon[0] : _languageICon[1];
    }
}
