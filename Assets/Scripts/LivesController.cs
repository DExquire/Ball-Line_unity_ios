using UnityEngine;

public class LivesController : MonoBehaviour
{
    public GameObject liveContainer;

    private void Update()
    {
        RemoveLife();
    }

    public void RemoveLife()
    {
        if (BallController.instance.livesCount >= 0 && BallController.instance.livesCount < liveContainer.transform.childCount)
        {
            liveContainer.transform.GetChild(BallController.instance.livesCount).GetChild(1).gameObject.SetActive(true);
        }
    }
}
