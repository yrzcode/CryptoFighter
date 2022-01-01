using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter
{
    public static class Extension
    {
        public static float ToTargetAngle(this Vector3 startPos, Vector3 targetPos)
        {
            float dx = targetPos.x - startPos.x;
            float dy = targetPos.y - startPos.y;
            float rad = Mathf.Atan2(dy, dx);
            return rad * Mathf.Rad2Deg;
        }
    }

}



