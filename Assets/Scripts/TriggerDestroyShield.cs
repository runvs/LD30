using UnityEngine;
using System.Collections;

public class TriggerDestroyShield : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Units")
        {
            foreach (var go in GameObject.FindGameObjectsWithTag("MothershipShield"))
            {
                Destroy(go);
            }
        }
    }
}
