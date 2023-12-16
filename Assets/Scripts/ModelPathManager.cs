using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPathManager : MonoBehaviour
{
    public TMPro.TMP_InputField modelPath;

    string s_modelPath;
    bool b_gotPath;

    // Start is called before the first frame update
    void Start()
    {
        b_gotPath = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_gotPath)
        {
            GLTFast.GltfAsset gltf = gameObject.GetComponent<GLTFast.GltfAsset>();
            gltf.Url = s_modelPath;
            gltf.Load(gltf.Url);
            b_gotPath = false;
        }
    }

    public void GetModelPath()
    {
        s_modelPath = modelPath.text;
        if(s_modelPath != null)
        {
            b_gotPath = true;
        } 
        else
        {
            Debug.Log("Path didn't load");
        }
    }
}
