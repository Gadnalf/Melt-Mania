using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10;
    public float jumpSpeed = 150;

    private float horizontalInput;
    private float verticalInput;
    private bool jumpPressed;

    private void FixedUpdate()
    {
        Vector3 forwardMovement = verticalInput * Vector3.forward;
        Vector3 sideMovement = horizontalInput * Vector3.right;
        Vector3 movementVector = (forwardMovement + sideMovement).normalized * speed;
        if (jumpPressed)
        {
            movementVector += Vector3.up * jumpSpeed;
            jumpPressed = false;
        }
        rb.AddRelativeForce(movementVector);
    }

    // Update is called once per frame
    private void Update()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        bool grounded = Physics.Raycast(groundRay, out hit, 0.34f);

        if (grounded)
        {
            Debug.Log(hit.collider.tag);
            switch (hit.collider.tag)
            {
                case "path":
                    speed = 10;
                    break;
                case "grass":
                    speed = 7;
                    break;
                case "water":
                    speed = 5;
                    break;
                case "sand":
                    speed = 3;
                    break;
                default:
                    speed = 10;
                    break;
            }
        }

        // Keyboard inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumpPressed = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }
}
