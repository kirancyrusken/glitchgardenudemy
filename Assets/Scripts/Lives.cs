using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    Text livesText;
    [SerializeField] int lives;

    private void Start()
    {
        livesText = GetComponent<Text>();
        Debug.Log("LivesText: " + livesText.text);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives--;
        UpdateDisplay();
        if (lives < 1)
        {
            FindObjectOfType<LevelController>().ShowLoseMenu();
        }
            
    }

}
