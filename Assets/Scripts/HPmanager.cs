using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPmanager : MonoBehaviour
{
    [SerializeField] int MaxHealt = 10;
    //[HideInInspector]
    public GameObject vizuals;
    public float currenthealth;

    public int compteur = 0; // DOT compteur

    private void Start()
    {
        currenthealth = MaxHealt;
    }

    public void FireDOT(int numberOfTick, int tickDamageAmount)
    {
        if( (compteur + 1) < numberOfTick )
        {
            StartCoroutine(oui(numberOfTick, tickDamageAmount));
        }
    }

    public void TakeDamage(int damage)
    {
        print("Took damage");
        currenthealth = currenthealth - damage;
        Die();          
    }

    private void Die()
    {
        if (currenthealth <= 0)
        {
            vizuals.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) TakeDamage(10);    // DEBUG
    }

    IEnumerator oui(int numberOfTick, int tickDamageAmount)
    {
        yield return new WaitForSeconds(1);
        StopAllCoroutines();
        TakeDamage(tickDamageAmount);
        FireDOT( numberOfTick, tickDamageAmount);
        compteur++;
    }
}