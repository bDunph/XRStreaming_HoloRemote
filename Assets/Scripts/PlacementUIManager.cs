using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementUIManager : MonoBehaviour
{
    public GameObject videoPlacementPanel;
    public GameObject modelPlacementPanel;
    public GameObject openVideoPlacementButton;
    public GameObject openModelPlacementButton;
    public GameObject appRemotingButton;
    public GameObject loadAssetButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenVideoControls()
    {
        videoPlacementPanel.SetActive(true);
        openVideoPlacementButton.SetActive(false);
        appRemotingButton.SetActive(false);
        loadAssetButton.SetActive(false);
    }

    public void CloseVideoControls()
    {
        videoPlacementPanel.SetActive(false);
        openVideoPlacementButton.SetActive(true);
        appRemotingButton.SetActive(true);
        loadAssetButton.SetActive(true);
    }

    public void OpenModelControls()
    {
        modelPlacementPanel.SetActive(true);
        openModelPlacementButton.SetActive(false);
        appRemotingButton.SetActive(false);
        loadAssetButton.SetActive(true);
    }

    public void CloseModelControls()
    {
        modelPlacementPanel.SetActive(false);
        openModelPlacementButton.SetActive(true);
        appRemotingButton.SetActive(true);
        loadAssetButton.SetActive(true);
    }
}
