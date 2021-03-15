using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAi : MonoBehaviour
{
    [SerializeField]
    GameObject aiCharacter = default;
    [SerializeField]
    float createRate = 1;
    int whichSideCheck = 0;
    [SerializeField]
    float spawnLoopTime = 0f;
    float timeCounter = 0f;   
    float randomStartPos = 0;
    float x = 0;
    float y = 0;
    float z = 0;
    int aiCount = 0;
    [SerializeField]
    int aiMaxLimit = 0;

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;     
    }
    private void Update()
    {
        CreateAi();
        LoopControl();
    }
    void LoopControl()
    {
        if(aiCount == aiMaxLimit)
        {
            timeCounter += Time.deltaTime;            
            if (timeCounter >= spawnLoopTime)
            {
                timeCounter = 0f;
                aiCount = 0;
            }
        }
    }
    private void CreateAi()
    {
        if (aiCount < aiMaxLimit)
        {
            whichSideCheck = Random.Range(0, 2);
            if (whichSideCheck == 1)
            {
                randomStartPos = 10;
            }
            else
            {
                randomStartPos = 0;
            }

            Vector3 AiStartPos = new Vector3(x, y, z + randomStartPos);
            Instantiate(aiCharacter, AiStartPos, Quaternion.identity, gameObject.transform);
            aiCount++;
        }        
    }
}
