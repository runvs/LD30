using UnityEngine;
using System.Collections;

public class BattleSystem : MonoBehaviour {

    public GameObject Bullet1;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }


    public void SpawnShot1(Vector3 position, Vector3 velocity, GameObject Target, GameObject Shooter)
    {
        GameObject bullet = Instantiate(Bullet1, position, new Quaternion()) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y) * GameProperties.BulletSpeedFactor;
        bullet.GetComponent<BulletScript>().Shooter = Shooter;
        bullet.GetComponent<BulletScript>().AttackTarget = Target;
        bullet.GetComponent<BulletScript>().Damage = AttributeConverter.GetAttackDamageFromAttribute(Shooter.GetComponent<HealthController>().Attribute_Attack, false);
        bullet.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        bullet.transform.parent = GameObject.FindGameObjectWithTag("ShotGroup").transform;
    }

}
