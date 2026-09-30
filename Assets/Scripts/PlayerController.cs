using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public bool canMove = true;
    private Rigidbody2D rb;
    private bool touchGround;
    public Color[] rainbowColors = new Color[7];
    public int indexCurrentColor = 0;
    private Animator animator;
    private float moveInput;
    public MoveCounter register;
    public SoundPlayer jukebox;
    public Teleport teleporter;
    private Vector3 newPosition;
    private bool neverRepeat = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (touchGround)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Bounce(1);
                animator.SetBool("isGrounded", false);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Bounce(-1);
                animator.SetBool("isGrounded", false);
            }
        }
        if (!canMove && !neverRepeat)
        {
            animator.SetBool("CourseClear", true);
            register.Complete();
            neverRepeat = true;
            jukebox.PlaySuccess();
            return;
        }
    }
    void Bounce(float direction)
    {
        touchGround = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(direction * speed, jumpForce), ForceMode2D.Impulse);
        register.JumpRegister();
        jukebox.PlayJump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SolidFloor"))
        {
            animator.SetBool("isGrounded", true);
            if (rainbowColors.Length > 0)
            {
                indexCurrentColor = (indexCurrentColor + 1) % rainbowColors.Length;
                GetComponent<SpriteRenderer>().color = rainbowColors[indexCurrentColor];
            }
            jukebox.PlayLanding();
        }
        if (collision.gameObject.CompareTag("Hazard"))
        {
            animator.SetBool("touchHazard", true);
            jukebox.PlayHurt();
            teleporter.StartTeleport(newPosition);
        }
        else
        {
            animator.SetBool("touchHazard", false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SolidFloor"))
        {
            if (rb.velocity.y <= 0.01f)
            {
                touchGround = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SolidFloor"))
        {
            touchGround = false;
        }
    }
}