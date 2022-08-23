using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{   
    public float moveSpeed = 1f;
    public float collisionOffset = 0.005f;
    public ContactFilter2D movementFilter;


    Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if(movementInput != Vector2.zero)
            {
                bool sucess = TryMove(movementInput);

                if(!sucess)
                {
                    sucess = TryMove(new Vector2(movementInput.x, 0));
                }
                if (!sucess)
                {
                    sucess = TryMove(new Vector2(0, movementInput.y));
                }

                animator.SetBool("IsMoving", sucess);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }

            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            } else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {   
        if(direction != Vector2.zero)
        {
        
        int count = rb.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("SwordAttack");
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}