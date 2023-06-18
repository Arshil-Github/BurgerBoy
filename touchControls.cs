using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class touchControls : MonoBehaviour
{
    public static float HorizontalButton = 0;
    public static bool Jump = false;
    public static bool Attack = false;

    public bool Shoot;

    public bool Pressing = false;
    public int Holding = 0;
    public void Rightbutton() 
    {
        if(Pressing == false)
        {
            StartCoroutine(changeHB(moveDistance));
        }
        AndroidManager.HapticFeedback();
    }
    public float waitForMove;
    public float moveDistance;
    IEnumerator changeHB(float f)
    {
        Pressing = true;
        HorizontalButton = f;

        yield return new WaitForSeconds(.1f);
        HorizontalButton = 0;

        yield return new WaitForSeconds(waitForMove);

        Pressing = false;
    }

    public void Leftbutton()
    {
        if (Pressing == false)
        {
            StartCoroutine(changeHB(-moveDistance));
        }
        AndroidManager.HapticFeedback();
    }
    public void ResetButton()
    {
        HorizontalButton = 0;
        Holding = 0;
    }
    public void JumpButton()
    {
        Jump = true;
        AndroidManager.HapticFeedback();
    }
    public void ResetJump()
    {
        Jump = false;
    }
    public void AttackButton()
    {
        Attack = true;
        AndroidManager.HapticFeedback();
    }
    public void ResetAttack()
    {
        Attack = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Rightbutton();
            Holding = 1;
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            Leftbutton();
            Holding = 2;
        }
        if(Input.GetKeyUp(KeyCode.L) && Input.GetKeyUp(KeyCode.J))
        {
            Holding = 0;
            HorizontalButton = 0;
            ResetButton();
        }
        if(Holding == 1)
        {
            Rightbutton();
        }
        else if(Holding == 2)
        {
            Leftbutton();
        }
    }
}

