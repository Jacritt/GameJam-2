using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed;
    public float rotate_speed;
    public float jump_speed;
    public float jumpButtonGracePeeriod;

    private CharacterController charaterController;
    private float yspeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    // Start is called before the first frame update
    void Start()
    {
        charaterController = GetComponent<CharacterController>();
        originalStepOffset = charaterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        yspeed += Physics.gravity.y * Time.deltaTime;

        if (charaterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }
        if (Time.time - lastGroundedTime <= jumpButtonGracePeeriod)
        {

            charaterController.stepOffset = originalStepOffset;
            yspeed = -0.5f;

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeeriod)
            {
                yspeed = jump_speed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            charaterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = yspeed;

        charaterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotate_speed * Time.deltaTime);
        }
    }
}