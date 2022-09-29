using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private float speed = 07f;
     private Rigidbody rb;
    private float jumpForce = 400f;
    [SerializeField] public int playerTurnNumber;
    private float rotationSpeed = 100f;




    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerTurnNumber) && TurnManager.GetInstance().isNotTurn == false)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                Vector3 direction = Vector3.right * Input.GetAxis("Horizontal");

                transform.Translate(direction * speed * Time.deltaTime);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                Vector3 direction = Vector3.forward * Input.GetAxis("Vertical");

                transform.Translate(direction * speed * Time.deltaTime);
            }


            if (Input.GetKeyDown("space") && IsGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce);
            }

            if (Input.GetKey("q"))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey("e"))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            }



        }

        bool IsGrounded()
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.9f))
                return true;
            else
                return false;
        }





    }
}
