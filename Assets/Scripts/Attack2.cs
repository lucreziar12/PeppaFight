using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(ResetCollider());
    }

    public Collider cld2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HPmanager>() != null)
        {
            other.GetComponent<HPmanager>().TakeDamage(4);
        }
    }
    IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(.1f);
        if(cld2.enabled != false)
        {
            cld2.enabled = false;
        }
    }
}
