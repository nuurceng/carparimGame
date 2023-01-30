using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiManager : MonoBehaviour
{
    float mermiHizi = 15f;

    void Start()
    {
        if(this.gameObject!=null)
        {
            Destroy(this.gameObject, 3f);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * mermiHizi);
    }
}
