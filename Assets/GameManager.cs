using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string levelName;
    public static int levelNum = 0;
    public static int enemiesSpawned = 2;
    public static int wallsSpawned = 1;
    public static int lightsSpawned = 5;
    public static int healthSpawned;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(nextLevel(TimerUI.timeRemaining));
    }

    IEnumerator nextLevel(float timer)
    {
        yield return new WaitForSeconds(timer);
        levelNum++;
        if (levelNum % 5 == 0)
        {
            enemiesSpawned++;
            wallsSpawned++;
            lightsSpawned++;
            TimerUI.timeRemaining = TimerUI.timeRemaining + 15;
            healthSpawned++;
        }
        SceneManager.LoadScene(levelName);
    }

}
