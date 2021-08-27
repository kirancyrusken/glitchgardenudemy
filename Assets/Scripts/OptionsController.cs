using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    MusicPlayer player;
    float defaultVolume = 0.7f;
    int defaultDifficulty = 2;
    int difficulty;

    private void Start()
    {
        player = FindObjectOfType<MusicPlayer>();
        //difficultySlider = GameObject.Find("Difficulty Slider") as Slider;
        //volumeSlider = FindObjectOfType<Slider>();
        volumeSlider.value = Preferences.GetMasterVolume();
        difficultySlider.value = Preferences.GetDifficulty();
    }

    private void Update()
    {
        player.SetVolume(volumeSlider.value);
        difficulty = Mathf.RoundToInt(difficultySlider.value);
    }

    public void SaveOptions()
    {
        Preferences.SetMasterVolume(volumeSlider.value);
        Preferences.SetDifficulty(Mathf.RoundToInt(difficultySlider.value));
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }
}
