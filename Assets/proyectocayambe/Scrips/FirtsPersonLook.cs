using Photon.Pun;
using UnityEngine;

public class FirstPersonLook : MonoBehaviourPun
{
    public float sensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;

    void Update()
    {
        if (!photonView.IsMine) return;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
