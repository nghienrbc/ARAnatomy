using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadingSystem : MonoBehaviour
{

    public GameObject Fade;
    public float test;
    public bool allowScene;

    private void OnEnable()
    {
        allowScene = false;
    }
    public void LoadAR()
    {
        StartCoroutine(LoadNextAsyncScene("levelAR"));
        //VarStatic.Back = true;
        Fade.SetActive(true);
       // StartCoroutine(TimeDelay(1.5f));
      
    }

 

    public void LoadingLevelName()
    {
        switch(VarStatic._levelSelect)
        {
            case "LvXuong":
                {
                    StartCoroutine(LoadNextAsyncScene(VarStatic._levelSelect));
                    VarStatic.Back = true;
                    Fade.SetActive(true);
                    StartCoroutine(TimeDelay(1.5f));
                    break;
                }
            case "lvco":
                {
                    StartCoroutine(LoadNextAsyncScene(VarStatic._levelSelect));
                    VarStatic.Back = true;
                    Fade.SetActive(true);
                    StartCoroutine(TimeDelay(3.5f));
                    break;
                }
            case "LvHeTieuHoa":
                {
                    StartCoroutine(LoadNextAsyncScene(VarStatic._levelSelect));
                    VarStatic.Back = true;
                    Fade.SetActive(true);
                    StartCoroutine(TimeDelay(1.5f));
                    break;
                }
            case "LvHeHoHap":
                 {
                    StartCoroutine(LoadNextAsyncScene(VarStatic._levelSelect));
                    VarStatic.Back = true;
                    Fade.SetActive(true);
                    StartCoroutine(TimeDelay(1.5f));
                    break;
                }
            case "LvNao":
                {
                    StartCoroutine(LoadNextAsyncScene(VarStatic._levelSelect));
                    VarStatic.Back = true;
                    Fade.SetActive(true);
                    StartCoroutine(TimeDelay(1.5f));
                    break;

                }
             default:
                {
                    break;
                }


        }

            


           // SceneManager.LoadScene(VarStatic._levelSelect, LoadSceneMode.Single);
    }

    IEnumerator LoadNextAsyncScene(string _lvname)
    {
       
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_lvname, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        print(!asyncLoad.isDone);
        while (asyncLoad.progress < 0.9f || !allowScene)
        {
            yield return null;
            test = asyncLoad.progress;
          
          //  print(!);
        }
        print(!asyncLoad.isDone);
        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator TimeDelay(float _timedelay)
    {
        yield return new WaitForSeconds(_timedelay);
        allowScene = true;
    }
}