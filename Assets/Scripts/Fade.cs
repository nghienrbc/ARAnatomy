using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    Image _image;
    private Color _sourceColor;
    private bool active;
    private float _startTime;
    public float speed=2f;
    private void Start()
    {
        _image = GetComponent<Image>();
        _sourceColor = new Color(1, 1, 1, 0);
        
    }

    private void OnEnable()
    {
        active = true;
        _startTime = 0;
    }
    private void OnDisable()
    {
        active = false;
    }
    // Update is called once per frame
    void Update () {

        if(active)
        {
            _startTime += Time.deltaTime;
            _image.color = Color.Lerp(_sourceColor, Color.white, _startTime*speed);
        }
       
	}
}
