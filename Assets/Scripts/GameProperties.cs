
public static class GameProperties
{

    public static float UnitMaxVelocity { get { return 1.4f; } }
    public static float UnitMoveVelocityFactor { get { return 1.85f; } }

    public static float UnitAttackTimerMax { get { return 0.9f; } }

    public static float AttackPushBackForceFactor { get { return 20.0f; } }

    public static float BulletSpeedFactor { get { return 12.0f; } }

    public static float EnemyMoveFactor { get { return 7.0f; } }
    public static float EnemyMaxVelocity { get { return 1.4f; } }
    public static float EnemyAttackTimerMax { get { return 1.1f; } }

    // public static float UnitAltarDefusionTime { get { return 10.0f;} }    // is now saved in AltarAction

    public static int StartingMoney { get { return 2500; } }
    public static int StartingResearchPoints { get { return 10; } }
    public static int BaseAttributeCosts { get { return 5000; } }
    public static float AttributeIncreaseValue { get { return 0.05f; } }

    public static int EnemyKillMoneyReward { get { return 60; } }

    public static int UnitLostMoneyFine { get { return 500; } }

    public static float UnitAttackMinimalRange { get { return 4.0f; } }

    public static float EnemyAttackMinimalRange { get { return 3.5f; } }

    public static int Rent { get { return 1000; } }
    public static float Tier2Multiplier { get { return 1.25f; } }
    public static float Tier3Multiplier { get { return 1.5f; } }
    public static float MinFixedCostsRange { get { return 0.01f; } }
    public static float MaxFixedCostsRange { get { return 0.09f; } }
}
