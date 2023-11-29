using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{

    [field: Header("Shot SFX")]
    [field: SerializeField] public EventReference Shot { get; private set; }

    [field: Header("Hit SFX")]
    [field: SerializeField] public EventReference Hit { get; private set; }

    [field: Header("Jump SFX")]
    [field: SerializeField] public EventReference Jump { get; private set; }

    [field: Header("Death SFX")]
    [field: SerializeField] public EventReference Death { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference Music { get; private set; }

    [field: Header("Reload")]
    [field: SerializeField] public EventReference Reload { get; private set; }

    [field: Header("Danger")]
    [field: SerializeField] public EventReference Danger { get; private set; }


    public static FMODEvents Instance;


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
}
