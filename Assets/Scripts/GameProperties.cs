using UnityEngine;
using System.Collections;

public static class GameProperties 
{

    public static float UnitMaxVelocity { get { return 1.0f; } }

    public static float UnitMoveForceFactor { get { return 0.5f;} }
    public static float UnitAttackTimerMax { get { return 0.9f; } }

    public static float AttackPushBackForceFactor { get { return 20.0f ;} }

    public static float BulletSpeedFactor { get { return 12.0f; } }

    public static float EnemyMoveFactor { get { return 7.0f  ; } }
    public static float EnemyAttackTimerMax { get { return 1.1f; } }
}
