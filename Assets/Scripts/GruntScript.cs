using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;
    public AudioClip DeathSound;
    public AudioClip HitSound;

    private float lastShoot;
    private Animator Animator;  
    private int Health = 3;
    private bool isDeath = false;



    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (John == null) return;

        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time  > lastShoot + 0.5f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.Shot, this.transform.position);
    }

    public void Hit()
    {
        if (!isDeath)
        {
            Health = Health - 1;
            AudioManager.Instance.PlayOneHit(FMODEvents.Instance.Hit, this.transform.position);
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(HitSound);

            if (Health <= 0)
            {
                isDeath = true;
                Animator.SetBool("isDeath", true);
                AudioManager.Instance.GruntDeath(FMODEvents.Instance.Death, this.transform.position);
                //Camera.main.GetComponent<AudioSource>().PlayOneShot(DeathSound);



            }
        }
    }

    public void DestroyGrunt()
    {
        Destroy(gameObject);
    }
}
