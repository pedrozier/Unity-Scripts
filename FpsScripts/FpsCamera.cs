using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    float sensibilityX = 2;
    float sensibilityY = 2;

    float rotationX = 0;
    float rotationY = 0;

    float angleYMin = -90;
    float angleYMax = 90;

    float smootCoefX = 0.5f;
    float smootCoefY = 0.5f;

    float smootRotX = 0;
    float smootRotY = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }


    void Update()
    {
        float verticalDelta   = Input.GetAxisRaw("Mouse Y") * sensibilityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensibilityX;

        smootRotX = Mathf.Lerp(smootRotX, horizontalDelta, smootCoefX);
        smootRotY = Mathf.Lerp(smootRotY, verticalDelta,   smootCoefY);

        rotationX += smootRotX;
        rotationY += smootRotY;

        rotationY = Mathf.Clamp(rotationY, angleYMin, angleYMax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }
}
