using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : ProjetctileController
{
    [SerializeField] ProjectileConfig laserConfig;

    public ProjectileConfig GetPrejectileConfig() => laserConfig;
}
