using UnityEngine;
using System.Collections;

public class AltarProgressIndicator : MonoBehaviour
{
    public AltarAction aa;

    // Use this for initialization
    void Start()
    {
        aa = this.transform.parent.GetComponent<AltarAction>();
    }

    // Update is called once per frame
    void Update()
    {
        float scale = aa.AltarTimeRemaining / aa.AltarTime;
        this.transform.localScale = new Vector3(scale, 1);
    }
}
