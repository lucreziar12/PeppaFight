using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPmanager : MonoBehaviour
{
    public GameObject HitVFX;
    public Transform HitVFXPoint;

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
        if ((compteur + 1) < numberOfTick)
        {
            StartCoroutine(oui(numberOfTick, tickDamageAmount));
        }
    }

    public void TakeDamage(int damage)
    {
        print("Took damage");
        Object.Instantiate(HitVFX, HitVFXPoint.position, HitVFXPoint.rotation);
        currenthealth = currenthealth - damage;
        Die();
    }

    private void Die()
    {
        if (currenthealth <= 0)
        {
            vizuals.SetActive(false);
            StartCoroutine(WaitForDeath());
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
        FireDOT(numberOfTick, tickDamageAmount);
        compteur++;
    }
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}