using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Units")
        {
            other.GetComponent<HealthController>().TakeDamage(GameProperties.ForceFieldDamage * Time.deltaTime);
        }

    }

}
