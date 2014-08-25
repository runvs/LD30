
public static class GameProperties
{

    public static float UnitMaxVelocity { get { return 1.4f; } }
    public static float UnitMoveVelocityFactor { get { return 1.85f; } }

    public static float UnitAttackTimerMax { get { return 0.9f; } }

    public static float AttackPushBackForceFactor { get { return 20.0f; } }

    public static float BulletSpeedFactor { get { return 12.0f; } }


    public static float EnemyMaxVelocity { get { return 1.4f; } }
    public static float EnemyAttackTimerMax { get { return 1.1f; } }

    public static int StartingMoney { get { return 2500; } }
    public static int StartingResearchPoints { get { return 10; } }
    public static int BaseAttributeCosts { get { return 5000; } }
    public static float AttributeIncreaseValue { get { return 0.05f; } }

    public static int EnemyKillMoneyReward { get { return 60; } }
    public static int UnitLostMoneyFine { get { return 500; } }

    public static int FoundArtifactRPReward { get { return 15; } }
    public static int FoundArtifactMoneyReward { get { return 1500; } }

    public static int FoundSmallArtifactRPReward { get { return 5; } }
    public static int FoundSmallArtifactMoneyReward { get { return 200; } }

    public static float UnitAttackMinimalRange { get { return 2.5f; } }
    public static float EnemyAttackMinimalRange { get { return 3.5f; } }



    public static int Rent { get { return 1000; } }
    public static float Tier2Multiplier { get { return 1.25f; } }
    public static float Tier3Multiplier { get { return 1.5f; } }
    public static float MinFixedCostsRange { get { return 0.01f; } }
    public static float MaxFixedCostsRange { get { return 0.09f; } }

    public static float EnemyAttribute_Bug_Health { get { return 0.20f + UnityEngine.Random.Range(-0.05f, +0.05f); } }
    public static float EnemyAttribute_Bug_Attack { get { return 0.10f + UnityEngine.Random.Range(-0.05f, 0.05f); } }
    public static float EnemyMoveFactor_Bug { get { return 6.0f; } }

    public static float EnemyAttribute_BugFast_Health { get { return 0.15f + UnityEngine.Random.Range(-0.05f, +0.05f); } }
    public static float EnemyAttribute_BugFast_Attack { get { return 0.35f + UnityEngine.Random.Range(-0.05f, 0.05f); } }
    public static float EnemyMoveFactor_BugFast { get { return 10.0f; } }

    public static float EnemyAttribute_Enemy_Health { get { return 0.5f + UnityEngine.Random.Range(-0.05f, +0.05f); } }
    public static float EnemyAttribute_Enemy_Attack { get { return 0.55f + UnityEngine.Random.Range(-0.05f, 0.05f); } }
    public static float EnemyMoveFactor_Enemy { get { return 7.0f; } }

    public static float EnemyAttribute_EnemyWP_Health { get { return 0.95f + UnityEngine.Random.Range(-0.05f, +0.05f); } }
    public static float EnemyAttribute_EnemyWP_Attack { get { return 0.95f + UnityEngine.Random.Range(-0.05f, 0.05f); } }
    public static float EnemyMoveFactor_EnemyWP { get { return 5.0f; } }


    public static float EnemyAttributeDefaultScience { get { return 0.0f; } }






}
