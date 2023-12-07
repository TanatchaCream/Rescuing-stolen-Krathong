using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public float checkDistance = 10.0f;
    public float checkAttackDistance = 1.5f;
    Vector3 direction;
    private Animator animator;
    private bool dead = false;
    public float enemyeyesAngle = 45;
    public float playereyesAngle = 360;
    private float angle;
    private int hit;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - this.transform.position;
        direction.y = 0;
        angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.position, this.transform.position) < checkDistance)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                hit++;
                if (hit == 2)
                {
                    animator.SetBool("isHitting", true);
                    dead = true;
                }
            }

            if (Vector3.Distance(player.position, this.transform.position) < checkDistance && !dead && angle <= enemyeyesAngle)
            {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-direction), 0.05f);

                if (direction.magnitude < checkAttackDistance)
                {
                    animator.SetBool("isAttacking", true);

                }
                else
                {
                    animator.SetBool("isAttacking", false);
                    animator.SetBool("isWalking", true);
                    this.transform.Translate(0, 0, 0.02f);

                }

            }
        }

        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttack", false);
        }

    }
}