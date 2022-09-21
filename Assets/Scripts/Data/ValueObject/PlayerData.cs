using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public PlayerMovementData playerMovementData;
}

[Serializable]
public class PlayerMovementData
{
    public float MoveSpeed = 8f;
}