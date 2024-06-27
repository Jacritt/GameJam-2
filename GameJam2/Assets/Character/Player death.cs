using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerdeath : MonoBehaviour
{
    public float threshold;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(-32.533f, 3.101f, -15.987f);
        }
    }
   
}
