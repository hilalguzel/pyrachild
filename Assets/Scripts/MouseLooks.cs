using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooks : MonoBehaviour
{
    public float Sensitivity = 150f;

    public Transform PlayerBody;

    float xRotation = 0f;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (PauseMenu.Instance.gameIsPaused == false && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (PauseMenu.Instance.gameIsPaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);

    }
}
