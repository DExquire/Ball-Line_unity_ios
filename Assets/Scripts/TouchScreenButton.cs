using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScreenButton : MonoBehaviour, IPointerDownHandler
{
    public TrailCollisions trailCollisions;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!trailCollisions.isFirstTouched)
        {
            trailCollisions.FirstTouchActive();
        }
    }
}
