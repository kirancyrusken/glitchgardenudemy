using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers;
    bool levelTimerCompleted;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseOptions;
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        winLabel.SetActive(false);
        Debug.Log("Win Screen status :" + winLabel.activeInHierarchy, gameObject);
        loseOptions.SetActive(false);
        Debug.Log("Lose Screen status :" + loseOptions.activeInHierarchy, gameObject);
        numberOfAttackers = 0;
        levelTimerCompleted = false;
    }

    public void AddAttacker()
    {
        Debug.Log("Level Timer Completed : " + levelTimerCompleted);
        Debug.Log("Attacker Spawned");
        numberOfAttackers++;
    }

    public void ReduceAttacker()
    {
        numberOfAttackers--;
        Debug.Log("Number Of Attckers :" + numberOfAttackers);
        if (levelTimerCompleted && numberOfAttackers <= 0)
        {
            StartCoroutine(EndLevel());
        }
    }

    public void SetLevelTimerAsCompleted()
    {
        levelTimerCompleted = true;
        StopSpawning();
    }

    public void StopSpawning()
    {
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

        foreach(EnemySpawner spawner in enemySpawners)
        {
            spawner.StopSpawning();
        }
    }
    
    IEnumerator EndLevel()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5);
        levelLoader.LoadNextScene();
    }

    public void ShowLoseMenu()
    {
        loseOptions.SetActive(true);
        Time.timeScale = 0;
    }
}
