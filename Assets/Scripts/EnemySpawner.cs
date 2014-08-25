using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyTemplate;

    private float TimeToSpawn;
    public float SpawnInterval;


    // Use this for initialization
    void Start()
    {
        TimeToSpawn = SpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        TimeToSpawn -= Time.deltaTime;
        if (TimeToSpawn < 0)
        {
            TimeToSpawn += SpawnInterval;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(EnemyTemplate, this.transform.position, new Quaternion()) as GameObject;
        //string Identifier = Guid.NewGuid().ToString();
        //enemy.name = Identifier;
        //enemy.GetComponent<AttackTarget>().Name = Identifier;
        //Enemy.GetComponent<EnemyAttacker>().Target = PickRandomTarget();
        Debug.Log(enemy.name);
        enemy.GetComponent<EnemyAttacker>().Target = GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().GetUnitClosestTo(this.transform.position);
    }

    private GameObject PickRandomTarget()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");
        int id = UnityEngine.Random.Range(0, units.Length - 1);
        return units[id];

    }


}
