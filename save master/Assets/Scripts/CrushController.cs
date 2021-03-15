using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushController : MonoBehaviour
{
    AnimationController animationController;
    [SerializeField]
    float delay=3f;
    private Rigidbody rb;
    [HideInInspector]
    public bool shouldMove=true;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animationController = GetComponent<AnimationController>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("left")|| collision.gameObject.CompareTag("right"))
        {
            shouldMove = false;
            rb.isKinematic = true;
            gameObject.layer = 11;
            TurnRotation(collision.transform);
            animationController.SetDie(true);
            gameObject.tag = "DiePlayer";
            StartCoroutine(WaitForGetUp(delay));           
            gameObject.tag = "Player";
            Invoke("MakeKinematic", 3f);            
        }
    }
    void TurnRotation(Transform x)
    {
        gameObject.transform.LookAt(x.position);
        gameObject.transform.rotation = Quaternion.Euler(0f, gameObject.transform.rotation.y, 0f);
    }
    IEnumerator WaitForGetUp(float wait)
    {
        yield return new WaitForSeconds(wait);
        animationController.GetUp(true);
        yield return new WaitForSeconds(0.1f);
        animationController.GetUp(false);
        animationController.SetDie(false);
    }
    void MakeKinematic()
    {
        rb.isKinematic = false;
        gameObject.layer = 9;
        shouldMove = true;
    }
}
