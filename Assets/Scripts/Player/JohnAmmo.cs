using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JohnAmmo : MonoBehaviour
{

    private JohnMovement john;
    private TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        john = GetComponent<JohnMovement>();
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        john.ammo += Time.deltaTime;
        textMesh.text = john.ammo.ToString("0");
    }
}
