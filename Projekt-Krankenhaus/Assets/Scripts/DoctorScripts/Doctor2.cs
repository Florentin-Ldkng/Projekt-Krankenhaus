using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Despawn());
    }


    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(16f);
        Destroy(this.gameObject);
    }
}
