using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject testPrefab;
    [SerializeField] private float interval;
    [SerializeField] private int maxSpawnAmount;
    private BoxCollider2D enemySensorBoxCollider2D;
    private bool hasSpawnEnemy;

    private void Start()
    {
        enemySensorBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        if (CanSpawnEnemy() && !hasSpawnEnemy)
        {
            StartCoroutine(SwapnEnemyInterval(interval));
            hasSpawnEnemy = true;
        }
    }

    private bool CanSpawnEnemy()
    {
        return
        !enemySensorBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("BombEnemy"));
    }


    private IEnumerator SwapnEnemyInterval(float waitTime)
    {
        for (int i = 0; i < maxSpawnAmount; i++)
        {
            Instantiate(testPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
        hasSpawnEnemy = false;
    }


}
