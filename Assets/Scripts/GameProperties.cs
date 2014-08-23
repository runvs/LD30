using UnityEngine;
using System.Collections;

public static class GameProperties 
{

    public static float UnitMaxVelocity { get { return 1.0f; } }

    public static float UnitMoveForceFactor { get { return 0.5f;} }
    public static float UnitAttackTimerMax { get { return 0.9f; } }

    public static float AttackPushBackForceFactor { get { return 20.0f ;} }
}
