using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;

    const float Y_ANGLE_MIN = -20f;
    const float Y_ANGLE_MAX = 50f;

    Camera cam;

    float distance = 7f;
    float currentX = 0f;
    float currentY = 0f;
    float sensitivityX = 1f;
    float sensitivityY = 0.5f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("CameraX") * sensitivityX;
        currentY += Input.GetAxis("CameraY") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        //newPosition.x = Mathf.Lerp(newPosition.x, lookAt.position.x, 0.1f);
        //newPosition.x = Mathf.Lerp(newPosition.y, lookAt.position.y, 0.1f);

        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
