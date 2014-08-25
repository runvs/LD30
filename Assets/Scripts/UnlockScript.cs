using UnityEngine;
using UnityEngine.UI;

public class UnlockScript : MonoBehaviour
{
    public int Tier;

    private GameController _gc;

    void Start()
    {
        _gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        GetComponent<Button>().onClick.AddListener(ClickListener);
    }

    void ClickListener()
    {
        var tierCost = 0;

        if (Tier == 2)
        {
            tierCost = GameProperties.Tier2Cost;
        }
        else if (Tier == 3)
        {
            tierCost = GameProperties.Tier3Cost;
        }

        if (_gc.ResearchPoints >= tierCost)
        {
            _gc.ResearchPointsRemove(tierCost);

            if (Tier == 2)
                _gc.Tier2Available = true;
            else if (Tier == 3)
                _gc.Tier3Available = true;

            var tierButtons = GameObject.FindGameObjectsWithTag("UnlockTierButton");
            foreach (var button in tierButtons)
            {
                if (button.name == "UnlockTier" + Tier)
                {
                    button.SetActive(false);
                }
            }

            var tierToggles = transform.parent.GetComponentsInChildren<Toggle>();
            foreach (var toggle in tierToggles)
            {
                toggle.interactable = true;
            }
        }
    }

    void Update()
    {
        if (Tier == 2 && _gc.Tier2Available)
        {
            gameObject.SetActive(false);
        }
        else if (Tier == 3 && _gc.Tier3Available)
        {
            gameObject.SetActive(false);
        }

        if (Tier == 2)
        {
            if (_gc.ResearchPoints < GameProperties.Tier2Cost)
            {
                GetComponent<Button>().interactable = false;
            }
            else
            {
                GetComponent<Button>().interactable = true;
            }
        }
        else if (Tier == 3)
        {
            if (_gc.ResearchPoints < GameProperties.Tier3Cost || !_gc.Tier2Available)
            {
                GetComponent<Button>().interactable = false;
            }
            else
            {
                GetComponent<Button>().interactable = true;
            }
        }
    }
}
