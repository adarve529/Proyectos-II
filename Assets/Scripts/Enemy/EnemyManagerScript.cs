using System.Collections;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    [SerializeField] private Transform[] portals;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float timeEnemies;
    private float timeNextEnemy;

    public GameObject john;

    // Update is called once per frame
    void Update()
    {
        timeNextEnemy += Time.deltaTime;
        if (timeNextEnemy >= timeEnemies)
        {
            timeNextEnemy = 0;
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        if (portals.Length == 0)
        {
            Debug.LogError("No hay portales configurados en el EnemyManager.");
            return;
        }

        foreach (Transform portal in portals)
        {
            InstantiateRandomEnemy(portal.position);
        }
    }

    void InstantiateRandomEnemy(Vector3 position)
    {
        if (enemies.Length == 0)
        {
            Debug.LogError("No hay enemigos configurados en el EnemyManager.");
            return;
        }

        int randomEnemyIndex = Random.Range(0, enemies.Length);
        GameObject newEnemy = Instantiate(enemies[randomEnemyIndex], position, Quaternion.identity);

        // Verifica si el objeto John está configurado
        if (john != null)
        {
            // Asigna el objeto John al componente EnemyScript (o al componente correspondiente) del nuevo enemigo
            GruntScript grunt = newEnemy.GetComponent<GruntScript>(); // Ajusta EnemyScript al nombre real del script del enemigo
            if (grunt != null)
            {
                grunt.John = john;
            }
            else
            {
                Debug.LogWarning("El componente EnemyScript no fue encontrado en el nuevo enemigo.");
            }
        }
    }
}

