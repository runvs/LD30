using UnityEngine;
using System.Collections;

public static class GameProperties 
{

    public static float UnitMaxVelocity { get { return 1.4f; } }
    public static float UnitMoveVelocityFactor { get { return 1.85f;} }

    public static float UnitAttackTimerMax { get { return 0.9f; } }

    public static float AttackPushBackForceFactor { get { return 20.0f ;} }

    public static float BulletSpeedFactor { get { return 12.0f; } }

    public static float EnemyMoveFactor { get { return 7.0f  ; } }
    public static float EnemyMaxVelocity { get { return 1.4f; } }
    public static float EnemyAttackTimerMax { get { return 1.1f; } }

   // public static float UnitAltarDefusionTime { get { return 10.0f;} }    // is now saved in AltarAction

    public static int EnemyKillMoneyReward { get { return 60; } }

    public static int UnitLostMoneyFine { get { return 500; } }
}
