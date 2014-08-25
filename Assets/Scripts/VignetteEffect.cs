using UnityEngine;

public class VignetteEffect : MonoBehaviour
{

    private Vector2 Resolution;
    private Color col;

    private Texture2D VignetteEffectTexture;
    private Sprite VignetteEffectSprite;

    // Use this for initialization
    void Start()
    {
        Resolution = new Vector2(Screen.width, Screen.height);
        CreateTexture();
        VignetteEffectSprite = Sprite.Create(VignetteEffectTexture, new Rect(0, 0, Resolution.x, Resolution.y), new Vector2(Resolution.x / 2.0f, Resolution.y / 2.0f));
        //VignetteEffectSprite.
        GetComponent<SpriteRenderer>().sprite = VignetteEffectSprite;
    }

    private void CreateTexture()
    {
        col = Color.black;
        VignetteEffectTexture = new Texture2D((int)Resolution.x, (int)Resolution.y);

        Vector2 centerPosition = new Vector2(Resolution.x / 2.0f, Resolution.y / 2.0f);

        float distanceToCenterMax = Mathf.Sqrt(centerPosition.x * centerPosition.x + centerPosition.y * centerPosition.y);

        for (int i = 0; i <= centerPosition.x; i++)
        {
            for (int j = 0; j <= centerPosition.y; j++)
            {
                Color pixelCol = col;

                Vector2 distanceToCenter = new Vector2(centerPosition.x - i, centerPosition.y - j);


                //newCol.A = (byte)newAlpha;
                //fadeRadialImage.SetPixel(i, j, newCol);

                float newAlpha = 255.0f * 0.75f * (float)Mathf.Sqrt(distanceToCenter.x * distanceToCenter.x + distanceToCenter.y * distanceToCenter.y) / distanceToCenterMax;

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
