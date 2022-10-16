using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject HitVFX;
    public Transform HitPoint;
    [SerializeField] int MaxHealt = 10;
    public float currenthealth;
    public int compteur = 0;

    public GameObject Vizuals;

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

    public void TakeDamage(float damage)
    {
        currenthealth = currenthealth - damage;
        Object.Instantiate(HitVFX, HitPoint.position, HitPoint.rotation);
        Die();
    }

    private void Die()
    {
        if (currenthealth <= 0)
        {
            Vizuals.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) TakeDamage(1);    // DEBUG
    }

    IEnumerator oui(int numberOfTick, int tickDamageAmount)
    {
        yield return new WaitForSeconds(1);
        StopAllCoroutines();
        TakeDamage(tickDamageAmount);
        FireDOT(numberOfTick, tickDamageAmount);
        compteur++;
    }
}
