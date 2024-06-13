using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    private bool allowScene;
    public GameObject Fade;
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        allowScene = false;
    }

    public void ButtonClick()
    {
        Fade.SetActive(true);
        StartCoroutine(LoadNextAsyncScene("MainMenu"));      
        StartCoroutine(TimeDelay(0.8f));
    }


    IEnumerator LoadNextAsyncScene(string _lvname)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_lvname, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.progress < 0.9f || !allowScene)
        {
            yield return null;
            //  print(!);
        }
        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator TimeDelay(float _timedelay)
    {
        yield return new WaitForSeconds(_timedelay);
        allowScene = true;
    }

    public void LoadMenu()
    {
        Fade.SetActive(true);
        StartCoroutine(LoadNextAsyncScene("MainMenu"));
        //VarStatic.Back = true;
     
        StartCoroutine(TimeDelay(1.2f));
    }

    public void LoadAR()
    {
        Fade.SetActive(true);
        StartCoroutine(LoadNextAsyncScene("levelAR"));
        //VarStatic.Back = true;
        
        StartCoroutine(TimeDelay(1.5f));
    }
}