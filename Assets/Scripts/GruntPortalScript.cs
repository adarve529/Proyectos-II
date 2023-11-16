using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntPortalScript : MonoBehaviour
{
    public AudioClip DeathSound;
    public AudioClip HitSound;
    public GameObject BulletPrefab;

    private Animator Animator;
    private int Health = 3;
    private bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit()
    {
        if (!isDeath)
        {
            Health = Health - 1;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(HitSound);
            if (Health <= 0)
            {
                isDeath = true;
                //Animator.SetBool("isDeath", true);
                DestroyGruntPortal();
                Camera.main.GetComponent<AudioSource>().PlayOneShot(DeathSound);



            }
        }
    }

    public void DestroyGruntPortal()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("grunt_portal_broke");
    }
}
