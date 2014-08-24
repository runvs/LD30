using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Shooter;
    public float LifeTime;
    public float Damage;

    public bool CanDoDamage;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0)
        {
            Debug.Log("Lifetime up");
            Destroy(this.gameObject);

            return;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Colllision General");
        if (CanDoDamage)
        {
            if (coll.gameObject.tag == "BadGuys")
            {
                Debug.Log("Coll BadGuy");
                coll.collider.GetComponent<HealthController>().TakeDamage(Damage);
                coll.collider.gameObject.GetComponent<EnemyAttacker>().SetTarget(Shooter);
                Destroy(this.gameObject);

            }
            GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().SpawnExplosion(this.transform.position, -this.GetComponent<Rigidbody2D>().velocity, this.Shooter);
        }
        Destroy(this.gameObject);
    }
}
