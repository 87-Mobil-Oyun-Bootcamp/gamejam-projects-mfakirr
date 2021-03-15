using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusController : MonoBehaviour
{
    public int accrossedChild = 0;
    public Text text;
    public bool levelCompleted = false;
    // Start is called before the first frame update

    private void Start()
    {
        text.text = "0/40";
    }
    private void Update()
    {
        LevelControl();
    }
    private void LevelControl()
    {
        if (accrossedChild == 40)
        {
            levelCompleted = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Child"))
        {
            accrossedChild++;
            text.text = accrossedChild + "/40";           
        }
    }
}

