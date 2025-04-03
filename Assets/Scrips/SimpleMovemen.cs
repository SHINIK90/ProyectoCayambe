using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SimpleMovement : MonoBehaviourPunCallbacks
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public float gravedad = 9.8f;

    private CharacterController characterController;
    private Vector3 movimiento;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
        {
            Debug.LogError("No se encontró CharacterController en " + gameObject.name);
        }
    }

    void Update()
    {
        if (photonView.IsMine && characterController != null)
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            // Movimiento relativo a la orientación del jugador
            Vector3 direccion = (transform.forward * movimientoVertical + transform.right * movimientoHorizontal).normalized;

            // Aplicar movimiento en el suelo
            movimiento.x = direccion.x * velocidad;
            movimiento.z = direccion.z * velocidad;

            // Aplicar gravedad
            if (characterController.isGrounded)
            {
                movimiento.y = -1f; // Mantiene al jugador pegado al suelo

                // Salto
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    movimiento.y = fuerzaSalto;
                }
            }
            else
            {
                movimiento.y -= gravedad * Time.deltaTime;
            }

            // Aplicar movimiento con CharacterController
            characterController.Move(movimiento * Time.deltaTime);
        }
    }
}
