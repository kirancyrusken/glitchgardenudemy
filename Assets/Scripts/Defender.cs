using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starPoints;
    [SerializeField] bool isBlocker;

    public void AddStars(int stars)
    {
        FindObjectOfType<StarsDisplay>().AddStars(stars);
    }

    public int GetStarCost()
    {
        return starPoints;
    }

    public bool IsBlocker()
    {
        return isBlocker;
    }
}
