using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{


    [Header("Volume")]
    [Range(0, 1)]

    public float musicVolume = 1;
    [Range(0, 1)]

    public float sfxVolume = 1;
    [Range(0, 1)]

    public Bus musicBus;

    public Bus sfxBus;


    private EventInstance musicEventInstance;

    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> studioEventEmitters;

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

        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
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

    public void Reload(EventReference sound, Vector3 vector3)
    {
        RuntimeManager.PlayOneShot(sound, vector3);
    }

    public void Danger(EventReference sound, Vector3 vector3)
    {
        RuntimeManager.PlayOneShot(sound, vector3);
    }

    public void BombExploding(EventReference sound, Vector3 vector3)
    {
        RuntimeManager.PlayOneShot(sound, vector3);
    }

    public void Healing(EventReference sound, Vector3 vector3)
    {
        RuntimeManager.PlayOneShot(sound, vector3);
    }


    private void Start()
    {
        InitializeMusic(FMODEvents.Instance.Music);
    }

    private void Update()
    {
        musicBus.setVolume(musicVolume);
        sfxBus.setVolume(sfxVolume);
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        //eventInstances.Add(eventInstance);
        return eventInstance;
    }
}

