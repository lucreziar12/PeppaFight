using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Collider _attackCollider;
    public float damageAmount;
    public void EnableCollider()
    {
        _attackCollider.enabled = true;
        Invoke("DiseableCollider", .02f);
    }

    // output damage when mob is in attack state 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLayer"))
        {
            other.GetComponent<PlayerHP>().TakeDamage(damageAmount);

            DiseableCollider();
        }
    }
    private void DiseableCollider() { _attackCollider.enabled = false; }
}