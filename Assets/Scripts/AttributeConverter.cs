using UnityEngine;
using System.Collections;

public static class AttributeConverter  
{
    public static float GetMaxHealthFromAttribute(float AttributeHealth, bool Enemy)
    {
        float retVal = (AttributeHealth * (5.0f + (Enemy ? 0.0f : 1.0f) ));
        return retVal;
    }

    public static float GetAttackDamageFromAttribute(float AttributeAttack, bool Enemy)
    {
        float retVal = (AttributeAttack * (2.0f + (Enemy ? 0.0f : 1.0f)));
        return retVal;
    }

    public static float GetAttackTimeFactorFromAttribute(float AttributeAttack, bool Enemy)
    {
        float retVal = (1.0f - ((Enemy?  0.25f : 0.5f )* AttributeAttack));
        return retVal;
    }

    public static float GetScienceTimeFactorFromAttribute(float AttributeScience, bool Enemy)
    {
        float retVal = (1.0f - ((Enemy?  0.25f : 0.5f )* AttributeScience));
        return retVal;
    }

}
