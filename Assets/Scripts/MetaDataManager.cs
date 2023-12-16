using Depthkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaDataManager : MonoBehaviour
{
    public TextLoader textLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendMetadataToClip()
    {
        string metadataJson = textLoader.metaDataJson;
        Depthkit.Clip clip = gameObject.GetComponent<Clip>();
        bool metadataLoaded = clip.LoadMetadata(metadataJson);
        Debug.Log("Metadata is loaded: " + metadataLoaded);
    }

    private void OnEnable()
    {
        textLoader.OnTextLoaded += SendMetadataToClip;
    }

    private void OnDisable()
    {
        textLoader.OnTextLoaded -= SendMetadataToClip;
    }
}
