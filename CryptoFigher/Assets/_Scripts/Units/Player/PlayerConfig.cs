using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Create PlayerConfig", fileName = "new playerConfig")]

public class PlayerConfig : ScriptableObject
{


    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float playerJumpSpeed;
    [SerializeField] private int playerMaxJumpCount;
    [SerializeField] private float playerHitRecoverTime;



    public float GetPlayerMoveSpeed() => playerMoveSpeed;
    public float GetPlayerJumpSpeed() => playerJumpSpeed;
    public float GetPlayerMaxJumpCount() => playerMaxJumpCount;
    public float GetplayerHitRecoverTime() => playerHitRecoverTime;



}
