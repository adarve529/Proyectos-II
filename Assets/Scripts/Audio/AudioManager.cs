using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayOneShot(EventReference sound, Vector3 vector3)
    {
        RuntimeManager.PlayOneShot(sound, vector3);
    }

    public void PlayOneHit(EventReference sound, Vector3 vector3)
    {
        RuntimeManager.PlayOneShot(sound, vector3);
    }

    public void PlayJump(EventReference sound, Vector3 vector3)
    {
        RuntimeManager.PlayOneShot(sound, vector3);
    }

    public void GruntDeath(EventReference sound, Vector3 vector3)
    {
        RuntimeManager.PlayOneShot(sound, vector3);
    }
}
