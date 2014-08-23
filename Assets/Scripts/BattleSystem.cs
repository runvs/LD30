using UnityEngine;
using System.Collections;

public class BattleSystem : MonoBehaviour {

    public GameObject Bullet1;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }


    public void SpawnShot1(Vector3 position, Vector3 velocity, GameObject Target, float Damage)
    {
        GameObject Bullet = Instantiate(Bullet1, position, new Quaternion()) as GameObject;
        Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y);

        Bullet.GetComponent<BulletScript>().AttackTarget = Target;
        Bullet.GetComponent<BulletScript>().Damage = Damage;
        Bullet.transform.parent = GameObject.FindGameObjectWithTag("ShotGroup").transform;
    }

}
