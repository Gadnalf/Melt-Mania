using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    //Variables
    public float rotationOnX; 
    public float rotationOnY;
    
    public float mouseSensitivity = 90f;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        rotationOnY -= mouseY;
        rotationOnY = Mathf.Clamp(rotationOnY, -90f, 90f);
        
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        rotationOnX -= mouseX;
        transform.localEulerAngles = new Vector3(rotationOnY, rotationOnX, 0f);
    }
}
