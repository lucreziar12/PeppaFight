using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sci : MonoBehaviour
{
    [SerializeField] Collider cld;

    Vector3 CubeScale;
    // Start is called before the first frame update
    void Start()
    {
        CubeScale = new Vector3(cld.transform.localScale.x / 10, 1, cld.transform.localScale.z / 10);
        transform.localScale = CubeScale;
    }
}
