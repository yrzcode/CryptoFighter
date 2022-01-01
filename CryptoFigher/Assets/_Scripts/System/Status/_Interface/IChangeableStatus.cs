using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Status
{
    public interface IChangeableStatus
    {
        void Increase(float amount);
        void Decrease(float amount);
    }

}





