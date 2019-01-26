using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]private float moveSpeed = 8.0f;
        [SerializeField]private float jumpSpeed = 8.0f;
        [SerializeField]private float gravity = 40.0f;
        private float yVelocity = 0;
        private bool isGrounded = false;
        private CharacterController chController;
        private Vector3 input;
        private void Awake() 
        {
            chController = GetComponentInChildren<CharacterController>();
        }

        private void Update() 
        {


            if(chController.isGrounded)
            {
                yVelocity = 0;
                input = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
                if (Input.GetButtonDown("Jump"))
                {
                    yVelocity = jumpSpeed;
                }
            }
            yVelocity -= gravity * Time.deltaTime;
            chController.Move(transform.TransformDirection(input * moveSpeed * Time.deltaTime + yVelocity * Vector3.up * Time.deltaTime));
        }
    }
}
