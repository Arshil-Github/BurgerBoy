using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy_Run : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    enemy enemy;
    //StateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<enemy>();

        enemy.speed = globalObject.Instance.eSpeed;
    }

    //StateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtPlayer();

         Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, enemy.speed * Time.fixedDeltaTime);

        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= enemy.rangeDetect && enemy.canAttack == true)
        {
            animator.SetTrigger("Attack");
            enemy.StopAllCoroutines();
            enemy.canAttack = false;
        }
    }

    //tateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
    
}
