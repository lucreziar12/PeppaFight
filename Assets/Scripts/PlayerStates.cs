using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    //private MobMobAnimationManager MobMobAnimationManager;
    //[SerializeField] Looter looter;
    
    //[SerializeField] Collider mobMobCollider;
    [SerializeField] CharacterController characterController;
     [Header("Charecater Attacks")]
    public GameObject[] attack;
    public Transform[] attackPoint;
    
    [Header("Charecater parameters")]
    private bool canAttack;
    public int attackDamages;
    public float attackCD = 2f;
    private bool isDoing;

    public enum playerState
    {
       movement,
        attack1,
        attack2,
        attack3,
        dash,
        hit
    }

    public playerState currentState;
    public playerState _previousState;

    //public playerState currentStates;
    //public playerState _previousState;

    private void Start()
    {
        //MobMobVisualManager = GetComponentInChildren<MobMobVisualManager>();
        //mobMobController = GetComponent<MobMobController>();
        isDoing = false;
        canAttack = true;
    }

    private void Attack(int AttackIndex)
    {
        print("Performed Attack1");
        isDoing = true;
        Object.Instantiate(attack[AttackIndex], attackPoint[AttackIndex].position, attackPoint[AttackIndex].rotation);
        StartCoroutine(AttackCD());
    }
    private void DashAttack(int AttackIndex)

    {
        print("Performed Attack1");
        isDoing = true;
        Object.Instantiate(attack[AttackIndex], attackPoint[AttackIndex].position, attackPoint[AttackIndex].rotation);
        StartCoroutine(AttackCD());
    }

    public void SwapaStates(playerState newState)
    {
        _previousState = currentState;

        currentState = newState;

        switch (currentState)
        {
            case playerState.movement:
            
                if (Input.GetButtonDown("Fire3")) { characterController.Dash(); }   // Dash

                break;
            case playerState.attack1:
                Attack(0);
                break;
            case playerState.attack2:
                break;
            case playerState.attack3:
                break;
            case playerState.dash:
                break;
            case playerState.hit:
                break;
            default:
                break;
        }
    }
    private void trackStateChanges()
    {
        // A = Fire1
        // X = Fire3
        // B = fire2

        // ne pas rentrer en perma dans les states 
        if (isDoing) return;
        else if (Input.GetButtonDown("Fire2")) { characterController.Dash(); }
        
        else if (Input.GetButtonDown("Fire1")) { SwapaStates(playerState.attack1); print("pressed A"); }
      
        else { currentState = playerState.movement; }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
             print("pressed X");
        }
            trackStateChanges();
    }
    //IEnumerator SpecialHitState(float VFXtime)
    //{
    //    yield return new WaitForSeconds(VFXtime);
    //    isAttack = false;   // put it in hte anim instead
    //    MobMobVisualManager.MobBurn(false);
    //    ChangeState(MobStates.wander);
    //}
    //IEnumerator Death(float WaitBeforedeactivate)
    //{
    //    // hide MobMob mesh
    //    MobMobVisualManager.MobMobVisuals[0].SetActive(false);
    //    MobMobVisualManager.MobMobVisuals[1].SetActive(false);
    //    mobMobCollider.enabled = false;
    //    // then deactivate the GO   
    //    yield return new WaitForSeconds(WaitBeforedeactivate);
    //    win_kIllCount.updateWin();
    //    gameObject.SetActive(false);
    //}
    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(.5f);
        isDoing = false;
        canAttack = true;
    }
    //private bool inAttackRange() => mobMobController.distanceToTarget < attackTriggerRange;
    //private bool ennemyDetectionIcon() => _previousState != mobStates && _previousState != MobStates.attack && mobMobController.distanceToTarget >= 4;
    //public bool inChaseRange() => mobMobController.distanceToTarget < suspectRange;
    //public bool closeToPlayer() => mobMobController.distanceToTarget < 2.3f;
}
