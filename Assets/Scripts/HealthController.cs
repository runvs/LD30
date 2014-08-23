using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Health;
    public float Attack;
    public float Science;

    void Start()
    {
        GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetHealth(gameObject.GetComponent<UnitScript>().Name);
        GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetAttack(gameObject.GetComponent<UnitScript>().Name);
        GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetScience(gameObject.GetComponent<UnitScript>().Name);
    }

    void Update()
    {
        CheckDead();
    }

    private void CheckDead()
    {
        if (Health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void RemoveHealth(float value)
    {
        Health -= value;
        CheckDead();
    }
    public float GetHealth ()
    {
        return Health;
    }

    
}
