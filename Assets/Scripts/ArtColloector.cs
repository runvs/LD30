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
            SfxrSynth synth = new SfxrSynth();
            synth.parameters.SetSettingsString("1,.5,,.324,,.569,,.2933,,.3784,,,,,,,,,,,,,.6636,,,1,,,,,,");
            synth.PlayMutated();

            var gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

            gc.ResearchPointsAdd(GameProperties.FoundSmallArtifactRPReward);
            gc.GainedResearchPoints += 5;

            gc.MoneyAdd(GameProperties.FoundSmallArtifactMoneyReward);
            gc.FoundArtefacts += GameProperties.FoundSmallArtifactMoneyReward;

            Destroy(this.gameObject);

        }
    }
}
