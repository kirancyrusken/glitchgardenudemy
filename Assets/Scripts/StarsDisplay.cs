using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField]Text starsText;
    [SerializeField] int stars = 100;

    private void Start()
    {
        starsText = GetComponent<Text>();
    }

    private void UpdateDisplay()
    {
        starsText.text = stars.ToString();
    }

    public void AddStars(int stars)
    {
        this.stars += stars;
        UpdateDisplay();
    }

    public void SpendStars(int starsToSpend)
    {
        if(starsToSpend <= this.stars)
        {
            this.stars -= starsToSpend;
            UpdateDisplay();
        }

    }

    public bool HaveEnoughStars(int starsToSpend)
    {
        return stars >= starsToSpend;
    }
}
