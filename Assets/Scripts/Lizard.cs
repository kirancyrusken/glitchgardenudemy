using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if(collidedObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(collidedObject);
        }
    }
}
