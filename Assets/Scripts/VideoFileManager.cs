using UnityEngine;
using UnityEngine.Video;

public class VideoFileManager : MonoBehaviour
{
    public TMPro.TMP_InputField textField;

    string s_filepath;
    bool b_filepathRetrieved;

    void Start()
    {
        b_filepathRetrieved = false;
    }

    private void Update()
    {
        if(b_filepathRetrieved)
        {
            VideoPlayer videoPlayer = gameObject.GetComponent<VideoPlayer>();
            Debug.Log(s_filepath);
            videoPlayer.url = s_filepath;
            b_filepathRetrieved = false;
        }    
    }

    public void GetVideoFilePath()
    {
        s_filepath = textField.text;
        b_filepathRetrieved = true;
    }
}
