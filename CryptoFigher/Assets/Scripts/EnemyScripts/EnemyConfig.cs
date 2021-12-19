using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create EnemyConfig", fileName ="new EnemyConfig")]

public class EnemyConfig : ScriptableObject
{

    [SerializeField] private float enemybaseMoveSpeed;

    public float GetEnemyMoveSpeed() => enemybaseMoveSpeed;


}
