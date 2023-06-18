using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class combatSystem : MonoBehaviour
{
    public int noOfClicks;
    float lastClickedtime;
    public float maxComboDelay;
    public Animator anim;

    public static bool hitAnEnemy = false;

    public ParticleSystem spark;
    public int heavyAttackDamageAdder;
    public float heavyAttackRangeAdder;

    [Header("UI Control Button")]
    public GameObject attackButton;
    public Sprite chargedbutton;
    public Sprite normalbutton;
    bool isWhite;


    void Update()
    {
        if (Time.time - lastClickedtime > maxComboDelay)
        {
            noOfClicks = 0;
        }
        if (Input.GetKeyDown(KeyCode.Z) || touchControls.Attack)
        {
            lastClickedtime = Time.time;
            noOfClicks++;

            if (noOfClicks == 1)
            {
                anim.SetBool("Attack1", true);
            }

            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        }
        else if (!isWhite && !touchControls.Attack)
        {
            StartCoroutine(HeavyAttackbutton());
        }

        CheckforHeavy();
    }

    public void return1()
    {
        if (noOfClicks >= 2 && hitAnEnemy == true)
        {
            anim.SetBool("Attack2", true);
            hitAnEnemy = false;
        }
        else
        {
            anim.SetBool("Attack1", false);
            touchControls.Attack = false;
            hitAnEnemy = false;
            noOfClicks = 0;
        }
    }
    public void return2()
    {
        if (noOfClicks >= 3 && hitAnEnemy == true)
        {
            anim.SetBool("Attack3", true);
            hitAnEnemy = false;
        }
        else
        {
            anim.SetBool("Attack2", false);
            noOfClicks = 0;
        }
    }
    public void return3()
    {
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        touchControls.Attack = false;
        noOfClicks = 0;
    }

    public void StartSpark()
    {
        spark.Play();
    }

    // Warning pseudo code
    float startTime = 0f;
    public float holdTimeForHeavy = 0.5f; // 5 seconds
 
    public void CheckforHeavy()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            startTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            if(startTime + holdTimeForHeavy <= Time.time)
            {
                anim.SetTrigger("HeavyAttack");
                PlayerMovement.heavyDamage = heavyAttackDamageAdder;
                PlayerMovement.heavyRange = heavyAttackRangeAdder;
            }
        }
        if (touchControls.Attack && isWhite)
        {
            anim.SetTrigger("HeavyAttack");
            PlayerMovement.heavyDamage = heavyAttackDamageAdder;
            PlayerMovement.heavyRange = heavyAttackRangeAdder;
            isWhite = false;
        }
    }
    IEnumerator HeavyAttackbutton()
    {
        attackButton.GetComponent<Image>().sprite = normalbutton;

        yield return new WaitForSeconds(holdTimeForHeavy);

        attackButton.GetComponent<Image>().sprite = chargedbutton;
        isWhite = true;
        StopAllCoroutines();
    }
}
