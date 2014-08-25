using UnityEngine;

public class ArtColloector : MonoBehaviour
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
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ResearchPointsAdd(GameProperties.FoundSmallArtifactRPReward);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GainedResearchPoints += 5;
            Destroy(this.gameObject);
        }
    }
}
