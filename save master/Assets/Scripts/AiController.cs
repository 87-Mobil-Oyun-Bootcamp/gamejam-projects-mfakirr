using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class AiController : MonoBehaviour
{
    Rigidbody aiRb = default;

    Vector3 aiVelocityDirection = Vector3.zero;
    [SerializeField]
    float zAngleHandler = 0f;
    [SerializeField]
    float xSpeedHandler = 0f;
    
    AnimationController animationController;
    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
        aiRb = GetComponent<Rigidbody>();       
    }

    void Start()
    {
        if (transform.localPosition.z == 0)
        {
            zAngleHandler = Random.Range(0f, -xSpeedHandler * 0.5f);
        }
        else
        {
            zAngleHandler = Random.Range(0f, xSpeedHandler * 0.5f);
        }

        aiVelocityDirection = new Vector3(-xSpeedHandler, 0, zAngleHandler);
        animationController.SetSpeed(xSpeedHandler);
        aiRb.velocity = aiVelocityDirection;      
        transform.LookAt((transform.position + aiVelocityDirection.normalized));      
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("left") || other.gameObject.CompareTag("right"))
        {
            gameObject.tag = "DeadChild";
            animationController.SetDie(true);
            aiRb.isKinematic = true;
            Destroy(gameObject,5f);
        }
        if (other.gameObject.CompareTag("bus"))
        {
            Destroy(gameObject);
        }
    }

}
