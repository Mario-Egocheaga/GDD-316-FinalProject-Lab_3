using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPack : MonoBehaviour
{
    private bool enteredTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if (enteredTrigger)
        {
            OnPickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enteredTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        enteredTrigger = false;
    }

    public void OnPickUp()
    {
        if (HealthController.currentHealth < 100)
        {
            HealthController.currentHealth = HealthController.currentHealth + 15;
        }
        Destroy(gameObject);
    }
}
