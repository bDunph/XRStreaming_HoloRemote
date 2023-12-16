using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject assetLoadCollapsedUI;
    public GameObject assetLoadExpandedUI;
    public GameObject appRemotingUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAssetLoadPressed()
    {
        assetLoadCollapsedUI.SetActive(false);
        assetLoadExpandedUI.SetActive(true);
        appRemotingUI.SetActive(false);
    }
}
