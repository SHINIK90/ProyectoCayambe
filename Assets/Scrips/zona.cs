using Photon.Pun;
using UnityEngine;

public class CambioDeEscena : MonoBehaviourPunCallbacks
{
    public string Historia;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(Historia); 
        }
    }
}

