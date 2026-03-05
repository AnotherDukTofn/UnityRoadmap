using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private int bulletCount;
    private float fireCooldown;

    [SerializeField] private List<Enemy> enemiesInRange;

    public void Fire(Vector3 targetPosition)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            SpawnBullet(targetPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);
                Debug.Log("Enemy entered range: " + enemy.name);
            }
        }
    }

    private Vector3 FindNearestEnemyPosition()
    {
        if (enemiesInRange.Count == 0) return null;

        Vector3 enemyPosition;
        foreach (Enemy enemy in enemiesInRange)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, enemyPosition))
            {
                enemyPosition = enemy.transform.position;
            }
        }

        return enemyPosition;
    }

    private void SpawnBullet(Vector3 targetPosition)
    {
        // Implement bullet spawning logic here.
        Debug.Log("Bullet spawned.");
    }

    private void Update()
    {
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0) {
            Vector3 targetPosition = FindNearestEnemyPosition();
            if (targetPosition != null) {
                Fire(targetPosition);
                fireCooldown = fireRate;
            }
        }
    }
}
