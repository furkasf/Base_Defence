using Enums;
using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    public void Activate() => PoolSignals.onGetObjectFormPool(PoolAbleType.Money.ToString());
}
