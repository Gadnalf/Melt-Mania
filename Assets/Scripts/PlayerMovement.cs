using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10;
    public float jumpSpeed = 150;

    private float horizontalInput;
    private float verticalInput;
    private bool jumpPressed;

    // Start is called before the first frame update
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
        // Keyboard inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }
}
