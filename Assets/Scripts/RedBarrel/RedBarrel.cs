using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarrel : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;

    //[Header("Animacion")]
    private Animator animator;

    private int Health = 3;
    private bool hasToExplode = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Explosion()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D collider in objetos)
        {
            Rigidbody2D rb2D = collider.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direccion = collider.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rb2D.AddForce(direccion * fuerzaFinal);
            }
            JohnMovement john = collider.GetComponent<JohnMovement>();
            GruntScript grunt = collider.GetComponent<GruntScript>();

            if (john != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    john.Hit();
                }
            }

            if (grunt != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    grunt.Hit();
                }
                    
            }
        }
        AudioManager.Instance.BombExploding(FMODEvents.Instance.Bomb, this.transform.position);
        Destroy(gameObject);
    }

    public void Hit()
    {
        if (!hasToExplode)
        {
            Health = Health - 1;

            if (Health == 0)
            {
                Explosion();
                hasToExplode = true;
                animator.SetBool("hasToExplode", true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }



    public void Destruir()
    {
        //Instantiate(barrilExplotado, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
