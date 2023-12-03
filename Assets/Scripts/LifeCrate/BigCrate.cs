using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigCrate : MonoBehaviour
{

    private float crateHealth = 4;

    private bool hasExploded = false;

    private float healthToGive;


    public GameObject John;
    private JohnMovement john;

    private void Start()
    {
        john = John.GetComponent<JohnMovement>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<JohnMovement>().Health += healthToGive;
            AudioManager.Instance.Reload(FMODEvents.Instance.Reload, this.transform.position);
            Destroy(gameObject);
        }
    }

    public void Hit()
    {
        if (!hasExploded)
        {
            crateHealth = crateHealth - 1;

            if (crateHealth == 0 && john != null)
            {
                john.Health += 4;

                if (john.Health > john.maxHealth)
                {
                    float excess = john.Health - john.maxHealth;
                    john.Health = john.Health - excess;

                    john.healthImg.fillAmount = john.Health / john.maxHealth;
                }

                AudioManager.Instance.Healing(FMODEvents.Instance.Health, this.transform.position);
                hasExploded = true;
                Destroy(gameObject);
                //animator.SetBool("hasToExplode", hasToExplode);
            }
        }
    }





}
