using UnityEngine;
using System.Collections;

public class AttackTargetEventManager : MonoBehaviour {

    public delegate void DeleteAttackTarget(string name);
    public static event DeleteAttackTarget OnDelete;

    public static void Call(string name)
    {
        if(OnDelete != null)
        {
            //OnDelete(name);
        }
    }

}
