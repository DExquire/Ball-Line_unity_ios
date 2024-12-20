using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public RectTransform ballPosition;
    public float speed;
    public float finishYpos;
    
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if (transform.position.y - ballPosition.position.y > 0.5f && transform.position.y > finishYpos)
        {
            transform.position -= Vector3.down * Time.deltaTime * ballPosition.GetComponent<Rigidbody2D>().velocity.y;
        }
    }
}
