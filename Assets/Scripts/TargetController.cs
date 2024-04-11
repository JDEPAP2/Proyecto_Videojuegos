using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] float minVerticalAngle, maxVerticalAngle;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector2 framingOffset;
    [SerializeField] Transform followChar;

    [SerializeField] bool invertX, invertY;

    float rotationX, rotationY, invertXVal, invertYVal, distance;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertXVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotationSpeed * 2;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPosition = followChar.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);
}
