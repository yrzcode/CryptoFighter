using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create EnemyConfig", fileName ="new EnemyConfig")]

public class EnemyConfig : ScriptableObject
{

    [SerializeField] int collsionDamge;
    [SerializeField] private GameObject destroyEffcet;
    [SerializeField] GameObject wallDestroyEffect;

    public int CollsionDamge { get => collsionDamge; set => collsionDamge = value; }
    public GameObject WallDestroyEffect { get => wallDestroyEffect; set => wallDestroyEffect = value; }

    public GameObject GetDestroyEffcet() => destroyEffcet;



}
