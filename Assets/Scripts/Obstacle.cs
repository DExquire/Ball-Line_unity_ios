using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Animator anim;
    public float posToStart;
    public float finishPos;
    public float speed;

    private void OnEnable()
    {
        anim.SetBool("MoveToStartPos", true);
    }

    public void DisableMoveAnim()
    {
        anim.SetBool("MoveToStartPos", false);
    }

    public void MoveToFinish()
    {
        if (transform.position.y < finishPos && transform.position.x == posToStart)
        {
            transform.position += Vector3.up * speed;
        }
    }
}
