using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public PlayerController playerController;

    public void ResetAction()
    {
        print("Reset anim");
        playerController.isDoing = false;
        animator.SetBool("attack1", false);
        animator.SetBool("attack2", false);
    }
    public void SwapAnimation()
    {
        switch (playerController.currentState)
        {
            case PlayerController.PeppaStates.attack1:
                animator.SetBool("attack1",true);
                animator.SetBool("moving", false);

                break;
            case PlayerController.PeppaStates.attack2:
                animator.SetBool("attack2", true);
                animator.SetBool("moving", false);

                break;
            case PlayerController.PeppaStates.movements:
                animator.SetBool("moving", true);
                animator.SetFloat("speed", playerController.controller.velocity.magnitude);
                break;
            case PlayerController.PeppaStates.attack3:
                break;
            case PlayerController.PeppaStates.dash:
                break;
            default:
                break;
        }
    }
    void Update()
    {
        SwapAnimation();
    }
}
