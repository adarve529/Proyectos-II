using System.Collections;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    [SerializeField] private Transform[] portals;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float timeEnemies;
    private float timeNextEnemy;

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
        Instantiate(enemies[randomEnemyIndex], position, Quaternion.identity);
    }
}

