using System.Collections;
using UnityEngine;
[RequireComponent(typeof(TrailRenderer))]
public class MouseTrail : MonoBehaviour
{
    TrailRenderer trailLine;
    private void Awake()
    {
        trailLine = this.GetComponent<TrailRenderer>();

    }
    private void Update()
    {
        //not ideal since it happens when clicking anywhere.
        //good enough for test/showcasing purposes
        if (Input.GetMouseButtonDown(0) && !BallController.instance.isLose && !BallController.instance.isWin)
        {
            StartCoroutine(DrawTrailLine());
        }
    }

    private IEnumerator DrawTrailLine()
    {
        transform.position = GetWorldPositionFromMouse();
        trailLine.Clear();
        while (true)
        {
            transform.position = GetWorldPositionFromMouse();
            if (Input.GetMouseButtonUp(0))
            {
                yield break;
            }
            yield return null;
        }
    }

    //Gets mouse position in 2dWorldSpace
    private Vector2 GetWorldPositionFromMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 transformPos = Camera.main.ScreenToWorldPoint(mousePos);
        transformPos.z = 0;
        return transformPos;
    }
}