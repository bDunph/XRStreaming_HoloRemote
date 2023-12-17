using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelControlPanelManager : MonoBehaviour
{
    public GameObject modelControlPanel;
    public GameObject openButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenControls()
    {
        modelControlPanel.SetActive(true);
        openButton.SetActive(false);
    }

    public void CloseControls()
    {
        modelControlPanel.SetActive(false);
        openButton.SetActive(true);
    }
}
