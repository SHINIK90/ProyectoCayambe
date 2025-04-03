using Photon.Pun;
using UnityEngine;

public class PlayerSetup : MonoBehaviourPun
{
    private Camera playerCamera;

    void Start()
    {
        if (photonView.IsMine)
        {
            // Buscar la cámara automáticamente
            playerCamera = GetComponentInChildren<Camera>();

            if (playerCamera != null)
            {
                playerCamera.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        else
        {
            if (playerCamera != null)
            {
                playerCamera.gameObject.SetActive(false);
            }
        }
    }
}
