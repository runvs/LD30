using UnityEngine;
using System.Collections;

public class UnitProperties : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float Jack_Health = 1;
    public float Jack_Attack = 1;
    public float Jack_Science = 1;

}
