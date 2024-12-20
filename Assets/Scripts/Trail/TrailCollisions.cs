using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]

public class TrailCollisions : MonoBehaviour
{
    TrailRenderer trailRender;
    EdgeCollider2D trailCollider;
    public EdgeCollider2D validCollider;

    List<EdgeCollider2D> unusedColliders = new();

    public bool isFirstTouched = false;

    void Awake()
    {
        trailRender = GetComponent<TrailRenderer>();
        trailCollider = GetValidCollider();

        trailCollider.enabled = false;

        isFirstTouched = false;
    }

    void Update()
    {        
        SetColliderTrailsToPoint(trailRender, trailCollider);
    }

    public void FirstTouchActive()
    {
       isFirstTouched = true; 
    }

    EdgeCollider2D GetValidCollider()
    {
        EdgeCollider2D validCollider;
        if(unusedColliders.Count > 0)
        {
            validCollider = unusedColliders[0];
            validCollider.enabled = true;
            unusedColliders.RemoveAt(0);
        }
        else
        {
            validCollider = new GameObject("TrailCollider", typeof(EdgeCollider2D)).GetComponent<EdgeCollider2D>();
        }
        return validCollider;
    }

    void SetColliderTrailsToPoint(TrailRenderer trail, EdgeCollider2D collider)
    {
        if(isFirstTouched)
        {
            trailCollider.enabled = true;
        }
        
        List<Vector2> points = new();
        for(int position = 0; position<trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }
        collider.SetPoints(points);
    }

    private void OnDestroy()
    {
        if(trailCollider != null)
        {
            trailCollider.enabled = false;
            unusedColliders.Add(trailCollider);
        }
    }
}
