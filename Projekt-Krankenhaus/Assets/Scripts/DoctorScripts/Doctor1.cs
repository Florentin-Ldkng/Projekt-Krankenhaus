using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Despawn());
    }


    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(2.3f);
        Destroy(this.gameObject);
    }
}
