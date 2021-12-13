using UnityEngine;
using UnityEngine.UI;
public class CameraFade : MonoBehaviour
{

    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    // Rather than Lerp or Slerp, we allow adaptability with a configurable curve
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;


    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    public Image image;

    private void Start()
    {
        if (startFadedOut) alpha = 1f; else alpha = 0f;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    private void Update()
    {

        if (direction == 0 && startFadedOut)
        {
            if (alpha >= 1f) // Fully faded out
            {
                alpha = 1f;
                time = 0f;
                direction = 1;
                startFadedOut = false;
            }
            else // Fully faded in
            {
                alpha = 0f;
                time = 1f;
                direction = -1;
            }

        }



        if (alpha > 0f) image.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
          // texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
           // texture.Apply();
            if (alpha <= 0f || alpha >= 1f) direction = 0;
        }
    }
    public void OnGUI()
    {

    }
}