using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0F, Time.time * 100f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Secret");

            foreach (GameObject obj in objectsToDestroy)
            {
                Destroy(obj);
            }
            Destroy(gameObject);
        }
    }
}
