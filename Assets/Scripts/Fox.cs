using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        Defender defender = collidedObject.GetComponent<Defender>();
        Attacker attacker = GetComponent<Attacker>();
        if (defender)
        {
            if (defender.IsBlocker())
                attacker.Jump();
            else
                attacker.Attack(collidedObject);
        }
    }
}
