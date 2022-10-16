using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAttack : MonoBehaviour
{
    public Enemy enemy;
    public Collider cld;
    public float attackCD;
    public float attackRange;

    public bool canAttack = true;

    private void Update()
    {
        {
            if (canAttack && enemy.distanceToTarget <= attackRange)
            {
                cld.enabled = true;
                print("attack update");
                StartCoroutine(AttackCD());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHP>() != null && canAttack)
        {
            canAttack = false;
            other.GetComponent<PlayerHP>().TakeDamage(2);
            StartCoroutine(ResetCollider());

            print("attack");
        }
    }
    IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(.01f);
        cld.enabled = false;
    }
    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(attackCD);
        canAttack = true;
    }
}