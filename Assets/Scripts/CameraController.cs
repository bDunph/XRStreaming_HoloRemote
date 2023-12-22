/* Filename: CameraController.cs
 * Creator: Bryan Dunphy
 * Date: 22/12/23
 * Purpose: This class provides keyboard control for a first person view camera.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float speed = 2.5f;
    [Header("Mouse Look Settings")]
    public bool lockCursor = true;
    // Clamp the rotation of the camera
    public Vector2 clampInDegrees = new Vector2(360, 180);
    // Mouse sensitivity
    public Vector2 sensitivity = new Vector2(0.25f, 0.25f);
    // Smoothing factor
    public Vector2 smoothing = new Vector2(5, 5);
    // Target direction midway between max and min clamp values
    // so that the camera begins in center
    public Vector2 targetDirection = new Vector2(0.5f, 0.5f);

    // Stores the cumulative rotation values
    private Vector2 m_mouseAbsolute;
    // Stores interpolated mouse values
    private Vector2 m_smoothMouse;

    Keyboard keyboard;

    // Start is called before the first frame update
    void Start()
    {
        keyboard = new Keyboard();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            // Use the mouse to rotate camera
            MouseLook();
        }
        

        if (keyboard.dKey.IsPressed())
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (keyboard.aKey.IsPressed())
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (keyboard.sKey.IsPressed())
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        if (keyboard.wKey.IsPressed())
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }

    /// <summary>
    /// This method reads the delta values of the mouse and applies the 
    /// y axis to the vertical rotation of the camera and the 
    /// x axis to the horizontal rotation of the camera.
    /// </summary>
    private void MouseLook()
    {
        // Lock the cursor
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Set the initial target orientation of the camera
        var targetOrientation = Quaternion.Euler(targetDirection);

        // Get the delta values from the mouse
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        // Scale input against the sensitivity setting and multiply that against the smoothing value.
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

        // Interpolate mouse movement
        m_smoothMouse.x = Mathf.Lerp(m_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
        m_smoothMouse.y = Mathf.Lerp(m_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

        // Sum mouse values
        m_mouseAbsolute += m_smoothMouse;

        // Clamp and apply the x value
        if (clampInDegrees.x < 360)
            m_mouseAbsolute.x = Mathf.Clamp(m_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

        var xRotation = Quaternion.AngleAxis(-m_mouseAbsolute.y, targetOrientation * Vector3.right);
        gameObject.transform.localRotation = xRotation;

        // Then clamp and apply the y value.
        if (clampInDegrees.y < 360)
            m_mouseAbsolute.y = Mathf.Clamp(m_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);

        var yRotation = Quaternion.AngleAxis(m_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
        gameObject.transform.localRotation *= yRotation;
    }
}
