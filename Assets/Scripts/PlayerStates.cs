using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    //private MobMobAnimationManager MobMobAnimationManager;
    //[SerializeField] Looter looter;
    
    [SerializeField] Collider mobMobCollider;
   
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
        attack,
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

    private void Attack1()
    {
        print("Performed Attack1");
        isDoing = true;
        Object.Instantiate(attack[0], attackPoint[0].position, attackPoint[0].rotation);
        StartCoroutine(AttackCD());
    }

    public void SwapaStates(playerState newState)
    {
        _previousState = currentState;

        currentState = newState;

        switch (currentState)
        {
            case playerState.movement:
                break;
            case playerState.attack:
                Attack1();
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

        // ne pas rentrer en perma dans les states 
        if (isDoing) return;

        else if (Input.GetButtonDown("Fire1")) { SwapaStates(playerState.attack); print("pressed A"); }

        //else if (inChaseRange() && !isAttack && playerDetected) { ChangeState(MobStates.chase); }

        //else if (!inChaseRange() && !isAttack && !playerDetected) { ChangeState(MobStates.wander); }
    }

    private void Update()
    {
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
