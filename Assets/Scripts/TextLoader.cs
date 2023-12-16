using System.IO;
using UnityEngine;

public class TextLoader : MonoBehaviour
{
    public delegate void TextLoaded();
    public event TextLoaded OnTextLoaded;

    public TMPro.TMP_InputField textField;
    string s_path;
    StreamReader m_streamReader;
    bool b_getStream;

    public string metaDataJson { get; private set; }

    private void Start()
    {
        b_getStream = false;
    }

    void Update()
    {
        if (b_getStream)
        {
            m_streamReader = new StreamReader(s_path);
            metaDataJson = m_streamReader.ReadToEnd();
            //Debug.Log(m_streamReader.ReadToEnd());
            m_streamReader.Close();
            b_getStream = false;
            if(OnTextLoaded != null && metaDataJson != null)
            {
                OnTextLoaded();
            }
        }
    }

    public void GetTextPath()
    {
        s_path = textField.text;
        if (s_path != null) b_getStream = true;
    }
}

