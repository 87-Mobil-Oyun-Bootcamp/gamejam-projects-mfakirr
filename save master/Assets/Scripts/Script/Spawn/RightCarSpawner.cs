using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCarSpawner : MonoBehaviour
{

    public GameObject[] carprefabright;
    public Transform spawnpos;
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
