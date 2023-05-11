using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public GameObject gm;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        gm.SetActive(false);

    }
    public void RestartLevelCommand() //Restarts the level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.levelNum = 0;
        GameManager.enemiesSpawned = 2;
        GameManager.wallsSpawned = 1;
        GameManager.lightsSpawned = 5;
        TimerUI.timeRemaining = 45;
    }
}
