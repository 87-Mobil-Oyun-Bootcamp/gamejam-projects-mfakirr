using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCarSpawner : MonoBehaviour
{

    public GameObject[] carprefabright;
    public Transform spawnpos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(carWave());
    }
    private void spawnCar()
    {
        GameObject a = Instantiate(carprefabright[(Random.Range(0, 6))]) as GameObject;
        a.transform.position = transform.position;        
    }

    IEnumerator carWave()
    {
        while (true)
        {
            spawnCar();
            yield return new WaitForSeconds(Random.Range(15, 20));
        }
    }
}
