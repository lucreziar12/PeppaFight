using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] Attack;
    public Transform[] AttackPoint;
    public GameObject Dash;
    public CharacterController controller;
    
    // in Inspector
    public float speed;
    public float DashSpeed;

    // private bools
    private bool _isDead;
    public bool isDoing;

    public enum PeppaStates
    {
        movements,
        attack1,
        attack2,
        attack3,
        dash
    }
    public PeppaStates currentState;
    public PeppaStates previousState;

    // Inputs Reader
    private float MoveInputX() => Input.GetAxisRaw("Horizontal");
    private float MoveInputZ() => Input.GetAxisRaw("Vertical");
    //
    public void ChangeState(PeppaStates newstate)
    {
        previousState = currentState;

        currentState = newstate;
        
        switch (currentState)
        {
            case PeppaStates.movements:
                PlayerMovement();
                break;

            case PeppaStates.attack1:
                Object.Instantiate(Attack[0], AttackPoint[0].position, AttackPoint[0].rotation);
                isDoing = true;
                StartCoroutine(RestetAction());

                break;
            case PeppaStates.attack2:
                StartCoroutine(RestetAction());

                break;
            case PeppaStates.attack3:
                StartCoroutine(RestetAction());

                break;
            case PeppaStates.dash:
                isDoing = true;
                dash();
                StartCoroutine(RestetAction());
                break;

            default:
                break;
        }
    }
    public void CheckPlayerStates()
    {
        if (isDoing) return;
        if (_isDead) return;

        else if (Input.GetButtonDown("Fire2")) { ChangeState(PeppaStates.dash); }   // DASH
        else if (Input.GetButtonDown("Fire1")) { ChangeState(PeppaStates.attack1); }  // Basic attack
        else if (Input.GetButtonDown("Fire3")) { ChangeState(PeppaStates.attack2); }    // Jump attack
        else                                   { ChangeState(PeppaStates.movements); }  // Default state is moving (AKA idle)

    }
    // movements
    public void PlayerMovement()
    {
        controller.Move(new Vector3(MoveInputX(), -1, MoveInputZ()) * speed * Time.deltaTime);
    }

    public void dash()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            print("dashes");
            controller.Move(Vector3.forward * DashSpeed * Time.deltaTime);
            Object.Instantiate(Dash, transform.position, transform.rotation);
        }
    }
    void Update()
    {
        CheckPlayerStates();
    }
    
    IEnumerator RestetAction()
    {
        yield return new WaitForSeconds(.2f);
        isDoing = false;
    }
}