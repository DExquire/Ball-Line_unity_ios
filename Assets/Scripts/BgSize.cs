using UnityEngine;

public class BgSize : MonoBehaviour
{
    public RectTransform ball;
    RectTransform bg;
    public float lowPos;
    public float speed;
    public float finishYpos;

    void Start()
    {
        bg = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(ball.anchoredPosition.y < lowPos && bg.anchoredPosition.y > finishYpos)
        {
            if ((bg.anchoredPosition.y - ball.anchoredPosition.y) > 100)
            {
                bg.position -= Vector3.down * ball.GetComponent<Rigidbody2D>().velocity.y * Time.deltaTime;
            }
        }
    }
}
