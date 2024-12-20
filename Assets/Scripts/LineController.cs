using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            Destroy(gameObject);
        }
    }
}
