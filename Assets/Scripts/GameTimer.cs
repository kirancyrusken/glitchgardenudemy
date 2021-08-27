using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds")]
    [SerializeField] float levelTimer = 100;
    bool timeCompleted;

    private void Start()
    {
        timeCompleted = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (timeCompleted) return;
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer;

        if(Time.timeSinceLevelLoad >= levelTimer)
        {
            timeCompleted = true;
            FindObjectOfType<LevelController>().SetLevelTimerAsCompleted();
        }

    }
}
