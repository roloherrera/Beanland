using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGemController : MonoBehaviour
{
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0F, Time.time * 100f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameController gameController = FindObjectOfType<GameController>();

            if (gameController != null)
            {
                gameController.GameWon();
            }
        }
    }

}
