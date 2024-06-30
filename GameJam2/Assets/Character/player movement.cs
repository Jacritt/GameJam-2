using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, j_speed, ro_speed;
    //private float y_speed;
    public bool walking;
    //public bool landed = true;
    public Transform playerTrans;
    // Start is called before the first frame update
    public float threshold;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerTrans.position += transform.forward * w_speed * Time.deltaTime;
        }
        /*if (Input.GetKey(KeyCode.C))
        {
            playerTrans.position += transform.forward * w_speed * Time.deltaTime;
        }*/
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;

        }
        /*
        y_speed += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            y_speed = j_speed;
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;

        }
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = y_speed;
        if (landed) {
            if (Input.GetKeyDown(KeyCode.C))
            {
                playerAnim.SetTrigger("jump");
                playerAnim.ResetTrigger("idle");
                landed = false;

            }
        }
        */

        if (Input.GetKey(KeyCode.A))
            {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
    }
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(-32.533f, 3.101f, -15.987f);
        }
    }
}
