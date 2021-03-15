using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childControl : MonoBehaviour
{
    private Transform head;
    Rigidbody rb;

    [SerializeField]
    float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        head = GameObject.FindGameObjectWithTag("FollowPoint").gameObject.transform;
    }
    private Vector3 movementVelocity;

    [Range(0.0f, 1.0f)]
    public float overTime = 0.5f;
    void FixedUpdate()
    {
    }
    private void Update()
    {
        Mover();
        Input.GetAxis("Vertical");
    }
    void Mover()
    {
        transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, overTime);

        rb.velocity = (head.position - transform.position) * speed;
        transform.LookAt(head.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("left") || collision.gameObject.CompareTag("right"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bus"))
        {
            Destroy(gameObject);
        }
    }
}
