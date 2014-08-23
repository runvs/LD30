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
        GameObject Bullet = Instantiate(Bullet1, position, new Quaternion()) as GameObject;
        Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y) * GameProperties.BulletSpeedFactor;
        Bullet.GetComponent<BulletScript>().Shooter = Shooter;
        Bullet.GetComponent<BulletScript>().AttackTarget = Target;
        Bullet.GetComponent<BulletScript>().Damage = AttributeConverter.GetAttackDamageFromAttribute(Shooter.GetComponent<HealthController>().Attribute_Attack, false);
        Bullet.transform.parent = GameObject.FindGameObjectWithTag("ShotGroup").transform;
    }

}
