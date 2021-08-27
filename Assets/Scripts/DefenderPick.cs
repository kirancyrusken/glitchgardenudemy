using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderPick : MonoBehaviour
{
    [SerializeField] Defender pickedDefender;


    private void Start()
    {
        SetCostText();
    }
    private void OnMouseDown()
    {
        var defenders = FindObjectsOfType<DefenderPick>();
        foreach(DefenderPick defender in defenders){
            defender.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetDefender(pickedDefender);
    }

    private void SetCostText()
    {
        Text costText = GetComponentInChildren<Text>();

        if (costText)
        {
            costText.text = pickedDefender.GetStarCost().ToString();
        }
    }
}
