using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCondition : MonoBehaviour
{
    private Collider2D objectCollider;
    public int requestedColor;
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController Placeholder = collision.gameObject.GetComponent<PlayerController>();
            if (Placeholder != null)
            {
                if (Placeholder.indexCurrentColor == requestedColor)
                {
                    Placeholder.canMove = false;
                    Rigidbody2D rbBlob = collision.gameObject.GetComponent<Rigidbody2D>();
                    if (rbBlob != null) rbBlob.velocity = Vector2.zero;
                    gameObject.SetActive(false);
                }
                else
                {
                    Placeholder.canMove = true;
                }
            }
        }
    }
    void Update()
    {
        
    }
}
