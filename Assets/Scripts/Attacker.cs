using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(1f,5f)]float currentSpeed = 1f;
    private int damage = 100;
    private GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AddAttacker();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void OnDestroy()
    {
        //Debug.LogError("LevelController :" + FindObjectOfType<LevelController>().name);
        FindObjectOfType<LevelController>().ReduceAttacker();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        this.currentSpeed = speed * Preferences.GetDifficulty();
    }

    public void AdaptDifficulty()
    {
        GetComponent<Animator>().speed = Preferences.GetDifficulty();
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        this.currentTarget = target;
    }

    public void Jump()
    {
        GetComponent<Animator>().SetTrigger("JumpTrigger");
    }

    public void StrikeTarget(float Damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }

    }
}
