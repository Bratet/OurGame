using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordattack : MonoBehaviour
{   

    public enum AttackDirection
    {
        left, right
    }

    public AttackDirection attackDirection;


    // Start is called before the first frame update
    Vector2 rightAttackOffset;
    Collider2D swordCollider;

    public void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }

    public void Swing()
    {
        if (attackDirection == AttackDirection.left)
        {
            AttackLeft();
        }
        else if (attackDirection == AttackDirection.right)
        {
            AttackRight();
        }
    }

    void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    // Update is called once per frame
    void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.position = new Vector2(transform.position.x * -1, transform.position.y);
    }

    void StopAttack()
    {
        swordCollider.enabled = false;
    }
}
