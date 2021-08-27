using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    const string DEFENDER_LINE_UP = "Defender Line Up";

    private void Start()
    {
        CreateDefenderParent();
    }


    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
            defenderParent.transform.parent = GameObject.Find(DEFENDER_LINE_UP).transform;
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("Mouse is clicked. x:" + Input.mousePosition.x + " y:" + Input.mousePosition.y);
        if(defender != null)
            AttemptToSpawnDefender(GetClickedSquare());
        
    }

    private void AttemptToSpawnDefender(Vector2 spawnPos)
    {
        int starCost = defender.GetStarCost();
        var stars = FindObjectOfType<StarsDisplay>();
        if (stars.HaveEnoughStars(starCost))
        {
            SpawnDefender(spawnPos);
            stars.SpendStars(starCost);
        }
    }

    private void SpawnDefender(Vector2 spawnPos)
    {
        Defender defenderObject = Instantiate(defender, spawnPos, Quaternion.identity) as Defender;
        defenderObject.transform.parent = defenderParent.transform;
    }

    public void SetDefender(Defender pickedDefender)
    {
        defender = pickedDefender;
    }

    private Vector2 snapToGrid(Vector2 rawWorldPos)
    {
        int posX = Mathf.RoundToInt(rawWorldPos.x);
        int posY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(posX, posY);
    }

    private Vector2 GetClickedSquare()
    {
        Vector2 mouseClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mouseClickPos);
        //Debug.Log("World Position. x:" + worldPos.x + " y:" + worldPos.y);
        return snapToGrid(worldPos);
    }
}
