using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameID : MonoBehaviour {

   // public PlayVideo _video;
    public Text _TitleTex;
    public int _nameID;
    public string VnName;
    public string EnName;
    public string LevelLoading;
    
  //  public UnityEngine.Video.VideoPlayer _video;
    //public UnityEngine.Video.VideoClip _clip;

    public string _title
    {
        get
        {
            if (VarStatic._language == 0)
                return VnName;
            else 
                return EnName;

        }

        set
        {
           
        }
    }

    private Button systembutton; // this button used for each human system 
    public Animator anim;
    private void Start()
    {
       
        
        systembutton = GetComponent<Button>();
        if (systembutton != null) systembutton.onClick.AddListener(delegate { SwitchButtonHandler("Hệ Xương"); });
        if (VarStatic._IsSystemSave == EnName)
        {
            SwitchButtonHandler("");
        }

    }

    private void OnEnable()
    {
       
    }
    void SwitchButtonHandler(string _tex)
    {
        /* 
        if(_video.isPlaying)
        {
            _video.Stop();
          
            _video.enabled = false;
        }
        _video.clip = _clip;
        if (_clip != null)
        {
            _video.enabled = true;
            _video.Stop();
            _video.Play();
        }
 */
        SetAnim();
        VarStatic._IsSystemSave = EnName;
        _TitleTex.text = _title;
        VarStatic._levelSelect = LevelLoading;
    }


    public void SetAnim()
    {
        switch (_nameID)
        {
            case 1:
                
                anim.SetBool("tieuhoa", false);
                anim.SetBool("sinhduc", false);
                anim.SetBool("baitiet", false);
                anim.SetBool("hohap", false);
                anim.SetBool("tuanhoan", false);
                anim.SetBool("co", false);
                anim.SetBool("xuong", false);
                anim.SetBool("thankinh", true);
                break;
            case 2:
                anim.SetBool("thankinh", false);
                anim.SetBool("tieuhoa", false);
                anim.SetBool("sinhduc", false);
                anim.SetBool("baitiet", false);
                anim.SetBool("hohap", false);
                anim.SetBool("tuanhoan", false);
                anim.SetBool("co", false);
                anim.SetBool("xuong", true);
                break;
            case 3:
                anim.SetBool("thankinh", false);
                anim.SetBool("xuong", false);
                anim.SetBool("tieuhoa", false);
                anim.SetBool("sinhduc", false);
                anim.SetBool("baitiet", false);
                anim.SetBool("hohap", false);
                anim.SetBool("tuanhoan", false);
                anim.SetBool("co", true);
                break;
            case 4:
                anim.SetBool("thankinh", false);
                anim.SetBool("xuong", false);
                anim.SetBool("co", false);
                anim.SetBool("tieuhoa", false);
                anim.SetBool("sinhduc", false);
                anim.SetBool("baitiet", false);
                anim.SetBool("hohap", false);
                anim.SetBool("tuanhoan", true);
                break;
            case 5:
                anim.SetBool("thankinh", false);
                anim.SetBool("xuong", false);
                anim.SetBool("co", false);
                anim.SetBool("tuanhoan", false);
                anim.SetBool("tieuhoa", false);
                anim.SetBool("sinhduc", false);
                anim.SetBool("baitiet", false);
                anim.SetBool("hohap", true);
                break;
            case 6:
                anim.SetBool("thankinh", false);
                anim.SetBool("xuong", false);
                anim.SetBool("co", false);
                anim.SetBool("tuanhoan", false);
                anim.SetBool("hohap", false);
                anim.SetBool("tieuhoa", false);
                anim.SetBool("sinhduc", true);
                anim.SetBool("baitiet", true);
                break;
            case 7:
                anim.SetBool("thankinh", false);
                anim.SetBool("xuong", false);
                anim.SetBool("co", false);
                anim.SetBool("tuanhoan", false);
                anim.SetBool("hohap", false);
                anim.SetBool("baitiet", false);
                anim.SetBool("tieuhoa", false);
                anim.SetBool("sinhduc", true);
                break;
            case 8:
                anim.SetBool("thankinh", false);
                anim.SetBool("xuong", false);
                anim.SetBool("co", false);
                anim.SetBool("tuanhoan", false);
                anim.SetBool("hohap", false);
                anim.SetBool("baitiet", false);
                anim.SetBool("sinhduc", false);
                anim.SetBool("tieuhoa", true);
                break;

        }
    }
}
