using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{

    public float ammoToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<JohnMovement>().ammo += ammoToGive;
            Destroy(gameObject);
        }
    }
}
