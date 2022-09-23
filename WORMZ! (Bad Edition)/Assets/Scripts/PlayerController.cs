using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private float speed = 4f;
     Rigidbody rb;
     private float jumpForce = 400f;
     public float hp = 10f;
    [SerializeField] public int playerTurnNumber;
   

   
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerTurnNumber))
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
