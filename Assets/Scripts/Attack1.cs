using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    public Collider cld;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HPmanager>() != null)
        {
            other.GetComponent<HPmanager>().TakeDamage(2);
            StartCoroutine(ResetCollider());
        }
    }
    IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(.01f);
        cld.enabled = false;
    }
}