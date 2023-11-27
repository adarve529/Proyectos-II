using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;
    public AudioClip DeathSound;
    public AudioClip HitSound;
    public float Speed;
    public float DesiredDistance;

    private float lastShoot;
    private Animator Animator;  
    private int Health = 3;
    private bool isDeath = false;
    private Rigidbody2D Rigidbody2D;

    [SerializeField] private EventReference shotSound;
    [SerializeField] private EventReference deathSound;
    [SerializeField] private EventReference hitSound;



    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath)
        {
            
            return;
        }

        if (John == null) return;

        Vector3 directionToPlayer = John.transform.position - transform.position;
        if (directionToPlayer.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distanceToPlayer = Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distanceToPlayer > DesiredDistance)
        {
            MoveTowardsPlayer();
        }

        if (distanceToPlayer < 1.0f && Time.time  > lastShoot + 0.5f)
        {
            Shoot();
            lastShoot = Time.time;
        }

       
    }
    public void MoveTowardsPlayer()
    {
        // Obtén la dirección hacia el jugador
        Vector3 directionToPlayer = (John.transform.position - transform.position).normalized;

        // Mueve al enemigo en la dirección hacia el jugador
        transform.Translate(directionToPlayer * Speed * Time.deltaTime);
    }
    
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

        AudioManager.Instance.PlayOneShot(shotSound, this.transform.position);
    }

    public void Hit()
    {
        if (!isDeath)
        {
            Health = Health - 1;
            AudioManager.Instance.PlayOneHit(hitSound, this.transform.position);
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(HitSound);

            if (Health <= 0)
            {
                isDeath = true;
                Animator.SetBool("isDeath", true);
                AudioManager.Instance.GruntDeath(deathSound, this.transform.position);
                //Camera.main.GetComponent<AudioSource>().PlayOneShot(DeathSound);



            }
        }
    }

    public void DestroyGrunt()
    {
        Destroy(gameObject);
    }
}
