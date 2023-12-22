using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransformManager : MonoBehaviour
{
    public TMP_InputField posX;
    public TMP_InputField posY;
    public TMP_InputField posZ;
    public TMP_InputField rotX;
    public TMP_InputField rotY;
    public TMP_InputField rotZ;
    public TMP_InputField scaleX;
    public TMP_InputField scaleY;
    public TMP_InputField scaleZ;

    public GameObject placementPanel;

    private string s_posX;
    private string s_posY;
    private string s_posZ;
    private string s_rotX;
    private string s_rotY;
    private string s_rotZ;
    private string s_scaleX;
    private string s_scaleY;
    private string s_scaleZ;

    // Start is called before the first frame update
    void Start()
    {
        /*Vector3 pos = new Vector3(-1.45f, -1.1f, 0.739f);
        gameObject.transform.localPosition = pos;
        Vector3 rot = new Vector3(0, -115, 0);
        gameObject.transform.eulerAngles = rot;*/
        //Vector3 scale = new Vector3(1, 1, 1);
        //gameObject.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (placementPanel.activeSelf)
        {
            s_posX = posX.text;
            double x = double.Parse(s_posX);
            s_posY = posY.text;
            double y = double.Parse(s_posY);
            s_posZ = posZ.text;
            double z = double.Parse(s_posZ);
            s_rotX = rotX.text;
            double rX = double.Parse(s_rotX);
            s_rotY = rotY.text;
            double rY = double.Parse(s_rotY);
            s_rotZ = rotZ.text;
            double rZ = double.Parse(s_rotZ);
            s_scaleX = scaleX.text;
            double sX = double.Parse(s_scaleX);
            s_scaleY = scaleY.text;
            double sY = double.Parse(s_scaleY);
            s_scaleZ = scaleZ.text;
            double sZ = double.Parse(s_scaleZ);

            Vector3 updatedPos = new Vector3((float)x, (float)y, (float)z);
            Vector3 updatedRot = new Vector3((float)rX, (float)rY, (float)rZ);
            Vector3 updatedScale = new Vector3((float)sX, (float)sY, (float)sZ);

            gameObject.transform.localPosition = updatedPos;
            gameObject.transform.eulerAngles = updatedRot;
            gameObject.transform.localScale = updatedScale;
        }
        
    }
}
