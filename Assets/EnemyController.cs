using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum STATE { LOOKFOR, GOTO, ATTACK, DEAD };
    public STATE currentState = STATE.LOOKFOR;
    public float enemySpeed;
    public float attackDistance;
    public float gotoDistance;
    public Transform target;
    public string playerTag;
    public float attackTime;
    public float currentTime;
    public Animator animator;
    float playerDistance;
    float angle;
    PlayerController playerController;
    void start()
    {
        // animator = this.GetComponent<Animator>();

    }
    IEnumerator Start()
    {
        currentTime = attackTime;
        if (target != null)
        {
            playerController = target.GetComponent<PlayerController>();

        }

        while (true)
        {
            switch (currentState)
            {
                case STATE.LOOKFOR:

                    LookFor();
                    animator.SetTrigger("isIdle");
                    break;
                case STATE.GOTO:
                    animator.SetTrigger("isRunning");

                    Goto();
                    break;
                case STATE.ATTACK:
                    animator.SetTrigger("isShooting");
                    Attack();
                    break;
                case STATE.DEAD:
                    animator.SetTrigger("isSleeping");
                    Dead();
                    break;
                default:
                    break;
            }
            yield return null;
        }

    }

    public void LookFor()
    {

        if (playerDistance < gotoDistance)
        {
            currentState = STATE.GOTO;
        }

        print("This is LookForState");
    }
    public void Goto()
    {
        if (playerDistance > attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        }

        else
        {
            currentState = STATE.ATTACK;
        }
        print("This is GotoState");
    }
    public void Attack()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime < 0f)
        {
            playerController.health--;
            print(playerController.health);
            currentTime = attackTime;
        }
        if (playerController.health < 0)
        {
            currentState = STATE.DEAD;
        }
        if (playerDistance > attackDistance)
        {
            currentState = STATE.ATTACK;
        }
        print("This is AttackState");




        print("This is AttackState");
    }
    public void Dead()
    {
        print("Game Over!!");
    }
    public float PlayerDistance()
    {
        playerDistance = Vector3.Distance(target.transform.position, this.transform.position);
        return playerDistance;
    }
}
