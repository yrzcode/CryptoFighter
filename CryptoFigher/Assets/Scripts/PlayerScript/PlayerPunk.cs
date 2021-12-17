using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunk : Player
{
    [SerializeField] PlayerConfig punkConfig;

    public PlayerConfig GetPlayerConfig() => punkConfig;

}
