using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    private Vector2 screenbounds;
    private int destroypoint = 95;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "left")
        {
            rb.velocity = new Vector3(0, 0, -speed);
            
        }
        if (gameObject.tag == "right")
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        if (Mathf.Abs(transform.position.z)> destroypoint )
        {
            Destroy(this.gameObject);
        }
       
    }
}
