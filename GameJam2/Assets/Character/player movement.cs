using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, j_height, ro_speed;
    public bool walking;
    public Transform playerTrans;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerTrans.position += transform.forward * w_speed * Time.deltaTime;
        }
       
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


        if (Input.GetKey(KeyCode.A))
            {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
    }
}
