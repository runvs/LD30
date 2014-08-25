using UnityEngine;

public class VignetteEffect : MonoBehaviour
{

    private Vector2 Resolution;
    private Color col;

    private Texture2D VignetteEffectTexture;
    private Sprite VignetteEffectSprite;
    Vector2 centerPosition;

    // Use this for initialization
    void Start()
    {
        Resolution = new Vector2(Screen.width, Screen.height);
        centerPosition = new Vector2(Resolution.x / 2.0f, Resolution.y / 2.0f);
        CreateTexture();
        GetComponent<GUITexture>().texture = VignetteEffectTexture;
        GetComponent<GUITexture>().pixelInset = new Rect(0, 0, centerPosition.x, centerPosition.y);
    }

    private void CreateTexture()
    {
        col = Color.black;
        VignetteEffectTexture = new Texture2D((int)Resolution.x, (int)Resolution.y);



        float distanceToCenterMax = Mathf.Sqrt(centerPosition.x * centerPosition.x + centerPosition.y * centerPosition.y);

        for (int i = 0; i <= Resolution.x; i++)
        {
            for (int j = 0; j <= Resolution.y; j++)
            {
                Color pixelCol = col;

                Vector2 distanceToCenter = new Vector2(centerPosition.x - i, centerPosition.y - j);


                float newAlpha = 0.65f * (float)Mathf.Sqrt(distanceToCenter.x * distanceToCenter.x + distanceToCenter.y * distanceToCenter.y) / distanceToCenterMax;

                if (newAlpha < 0.0f)
                {
                    newAlpha = 0.0f;
                }

                pixelCol.a = newAlpha;
                VignetteEffectTexture.SetPixel(i, j, pixelCol);
            }
        }
        VignetteEffectTexture.Apply();
    }

    // Update is called once per frame
    void Update()
    {


    }
}
