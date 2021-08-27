using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnInterval = 1f;
    [SerializeField] float maxSpawnInterval = 10f;

    [SerializeField] Attacker[] attackerPrefabs;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
            //Debug.Log("Spawning");
            if(spawn)
                SpawnEnemy();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnEnemy()
    {
        float yPos = Mathf.Floor(transform.position.y);
        Vector3 enemyPos = new Vector3(transform.position.x, yPos, transform.position.z);
        Attacker newAttacker = Instantiate(Spawn(), enemyPos, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private Attacker Spawn()
    {
        int enemyIndex = Random.Range(0, attackerPrefabs.Length);
        return attackerPrefabs[enemyIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
