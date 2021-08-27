using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weapon;
    Animator animator;

    EnemySpawner spawnerOnLane;

    private void Start()
    {
        SetLawnSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("IsAttacking", IsAttackerOnLane());        
    }

    public void Fire()
    {
        GameObject shotProjectile = Instantiate(projectile, weapon.transform.position, Quaternion.identity);
        shotProjectile.transform.parent = transform;
    }
    

    private void SetLawnSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach(EnemySpawner enemy in spawners)
        {
            bool isSpawnerOnMyLane = false;
            //Debug.Log("Before floor : " + enemy.transform.position.y);
            double yPos = Math.Floor(enemy.transform.position.y);
            //Debug.Log("After floor : " + yPos);
            //Debug.Log("Spawner Defender yPos Diff : " + (yPos - transform.position.y));
            isSpawnerOnMyLane = Math.Abs(yPos - transform.position.y) <= Mathf.Epsilon;
            if(isSpawnerOnMyLane)
                spawnerOnLane = enemy;

            Debug.Log(isSpawnerOnMyLane + " : " + enemy.name + " : " +  yPos + " : " + transform.position.y);
        }
    }

    private bool IsAttackerOnLane()
    {
        if(spawnerOnLane != null && spawnerOnLane.transform.childCount > 0)
        {
            return true;
        }
        return false;
    }
}
