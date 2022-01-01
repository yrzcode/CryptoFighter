using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IOnChangeAction
{
    public event Action OnIncrease;
    public event Action DeIncrease;

}
