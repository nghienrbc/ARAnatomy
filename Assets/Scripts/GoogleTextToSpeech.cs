using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

/// <summary>
/// <author>Jefferson Reis</author>
/// <explanation>Works only on Android, or platform that supports mp3 files. To test, change the platform to Android.</explanation>
/// </summary>

public class GoogleTextToSpeech : MonoBehaviour
{
    private HumanController humanController;
    private AudioSource _audio;
    private string words ="";
    //public InputField inputText;
    // Use this for initialization
    private string[] arrListStr;
    private List<AudioClip> _clipList = new List<AudioClip>();

    void Start()
    {

        humanController = GameObject.Find("Controller").GetComponent<HumanController>();
        _audio = GetComponent<AudioSource>();

    }
    // Update is called once per frame

    IEnumerator DownloadTheAudio()
    {

        _audio.Stop();
        string url="";
        if (VarStatic._language == 1)
        {
            words = ReadJson.Information["information"][HumanController._idNow]["ENName"].ToString();
            Regex rgx = new Regex("\\s+");
            string result = rgx.Replace(words, "%20");
             url = "http://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=" + result + ".&tl=En-gb";
        }
           
       else if(VarStatic._language == 0)
        {
            words = ReadJson.Information["information"][HumanController._idNow]["VNName"].ToString();
            Regex rgx = new Regex("\\s+");
            string result = rgx.Replace(words, "%20");
             url = "http://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=" + result + ".&tl=Vi-gb";
        }
       
        WWW www = new WWW(url);
        yield return www;
        _audio.clip = www.GetAudioClip(false, false, AudioType.MPEG);
        _audio.Play();
    }


    public void ButtonClick()
    {
        StartCoroutine(DownloadTheAudio());
    }
}
