using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Transform> bodyParts = new List<Transform>();
    public float mySpeed = 5.0f;
    [Range(0.0f, 1.0f)]
    public float smoothTime = 0.1f;
    public Transform bodyObject;
    float speed = 0f;
    [SerializeField]
    float joystickSpeed = 0;
    AnimationController animationController;   
    private bool myShouldMove = true;
    private CrushController crushController;

    private void Awake()
    {
        crushController = GetComponent<CrushController>();
        animationController = GetComponent<AnimationController>();
    }
    private void Update()
    {
        myShouldMove = crushController.shouldMove;
        MovingContwithJoystick();
        WalkControl();       
        animationController.SetSpeed(speed);
    }    
    void MovingContwithJoystick()
    {
        if (myShouldMove)
        {           
            transform.position += new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"))*joystickSpeed*Time.deltaTime;
            transform.LookAt(transform.position - new Vector3(-Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal")));
        }
    }
    void WalkControl()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ) 
        {
            speed = 2f;
        }
        else
        {
            speed = 0f;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Child"))
        {
            Vector3 currentPos = transform.position;
            Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;
            Destroy(other.gameObject);
        }
    }
}
