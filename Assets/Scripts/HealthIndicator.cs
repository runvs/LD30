using UnityEngine;
using System.Collections;

public class HealthIndicator : MonoBehaviour
{

    public HealthController hc;

    // Use this for initialization
    void Start()
    {
        hc = this.transform.parent.GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        float scale = hc.CurrenteHealth / hc.HealthMax;
        this.transform.localScale = new Vector3(scale, 1);
    }
}
