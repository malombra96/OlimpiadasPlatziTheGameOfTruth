using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir_sangre : MonoBehaviour
{
    public float tiempo;
    void Start()
    {
        StartCoroutine(morir());
    }

    IEnumerator morir()
    {
        yield return new WaitForSeconds(tiempo);
        Destroy(gameObject);
    }
}
