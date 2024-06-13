using System.Collections;
using UnityEngine;

public class MethodOfObject : MonoBehaviour {
    // Material originalMat;
    MeshRenderer meshrender;
    MeshCollider meshcolider;
    //   Renderer rend;
    Material originalMat;

    public bool Muslce;
    [HideInInspector]
    public bool fade = true;
    void Start()
    {
        originalMat = GetComponent<Renderer>().sharedMaterial;
        //  rend = GetComponent<Renderer>();
        meshrender = GetComponent<MeshRenderer>();
        meshcolider = GetComponent<MeshCollider>();
        if(Muslce)
        {
            meshrender.sharedMaterial.shader = Shader.Find("ShaderForge/Muscle");
        }else
        {
            meshrender.sharedMaterial.shader = Shader.Find("Shader Forge/xuong");
        }
        
    }

   void OnEnable()
    {
        //  Debug.Log("Active");
        HumanController.OnInactive += ObjectActiveRender;
    }

    void OnDisable()
    {
        HumanController.OnInactive -= ObjectActiveRender;
        //Debug.Log("Inactive");
    }

    public void Restore()
    {
        if (meshrender.sharedMaterial.GetFloat("_On_Off") == 1)
            GetComponent<Renderer>().sharedMaterial = originalMat;

        meshrender.sharedMaterial.SetFloat("_On_Off", 1f);

        //
    }

    public void RestoreFade()
    {
        meshrender.sharedMaterial.SetFloat("_Opacity", 1f);
        // rend.material.SetFloat("_Opacity", 1f);
    }
    public void ObjectActiveRender(bool val)
    {
        if (meshrender.enabled != val)
        {
            meshrender.enabled = val;
            meshcolider.enabled = val;
        }
    }


    public void SetActiveObjectInv(bool status)
    {
        meshrender.enabled = status;
        meshcolider.enabled = status;
    }

    public void setColorMat()
    {
        meshrender.material.SetFloat("_On_Off", 0f);
        // rend.material.SetFloat("_On_Off", 0f);
    }

    public void SetFadeMat()
    {
        meshrender.material.SetFloat("_Opacity", 0.4f);
        //  rend.material.SetFloat("_Opacity", 0.22f);
    }

    public void SetInVisible()
    {
        meshrender.enabled = false;
        meshcolider.enabled = false;
    }

}
