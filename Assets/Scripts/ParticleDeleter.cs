using UnityEngine;
using System.Collections;

public class ParticleDeleter : MonoBehaviour {

    private ParticleSystem ps;
    private float _lifetime;

    // Use this for initialization
    void Start()
    {
        ps = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        _lifetime += Time.deltaTime;
        if (_lifetime >= 1.5f)
        {
            Destroy(gameObject);
        }
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
