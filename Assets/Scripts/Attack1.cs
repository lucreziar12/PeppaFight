using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    private void Awake()
    {
            StartCoroutine(ResetCollider());
    }

    public Collider cld;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HPmanager>() != null)
        {
            other.GetComponent<HPmanager>().TakeDamage(4);
        }
    }
    IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(.1f);
        cld.enabled = false;
    }
}