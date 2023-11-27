using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JohnMovement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public GameObject BulletPrefab;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float lastShoot;
    private int Health = 17;
    private bool isJumping = false;



    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        
        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
            Animator.SetBool("jumping", false);
        }
        else Grounded = false;              

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
 
        }
  
        if (Input.GetKey(KeyCode.Space) && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if(transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;
    
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.Shot, this.transform.position);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        isJumping = true;
        Animator.SetBool("jumping", true);
        AudioManager.Instance.PlayJump(FMODEvents.Instance.Jump, this.transform.position);

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);

    }

    public void Hit()
    {
        Health = Health - 1;
        AudioManager.Instance.PlayOneHit(FMODEvents.Instance.Hit, this.transform.position);
        if (Health == 0) { Destroy(gameObject); }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallingCollider")
        {
            GameManager.ChangeScene(3);
        }
    }
}
