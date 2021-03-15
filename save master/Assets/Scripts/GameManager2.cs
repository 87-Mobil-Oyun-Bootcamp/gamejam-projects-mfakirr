using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public GameObject startingPanel;
    public GameObject closePanel;
    private bool levelCheck;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        levelCheck = GameObject.FindGameObjectWithTag("bus").GetComponent<BusController>().levelCompleted;
        LevelController();
    }
    

    public void ClosePanel()
    {
        startingPanel.SetActive(false);

        Time.timeScale = 1;
    }
    public void LevelController()
    {
        if (levelCheck)
        {
            closePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
