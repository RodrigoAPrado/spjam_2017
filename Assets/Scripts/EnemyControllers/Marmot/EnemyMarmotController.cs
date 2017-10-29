using UnityEngine;
using System.Collections;

public class EnemyMarmotController : EnemyBaseController {

    public enum StateMachine
    {
        hidden,
        appear,
        wait,
        aim,
        shoot,
        hide
    }

    private StateMachine currentState;

    private float stateTimer;

    private float appearTime = 0.7f;

    private float waitTime = 0.5f;

    private float shootTime = 0.5f;

    [SerializeField]
    private Animator animator;

    void Start()
    {
        currentState = StateMachine.hidden;
        laneController = GameObject.FindGameObjectWithTag("LaneController").GetComponent<LaneController>();
    }

    void Update()
    {
        switch (currentState)
        {
            case StateMachine.hidden:
                hiddenStateControl();
                break;
            case StateMachine.appear:
                appearStateControl();
                break;
            case StateMachine.wait:
                waitStateControl();
                break;
            case StateMachine.aim:
                aimStateControl();
                break;
            case StateMachine.shoot:
                shootStateControl();
                break;
        }
    }

    private void hiddenStateControl()
    {
        stateTimer += Time.deltaTime;
        if(stateTimer >= appearTime)
        {
            currentState = StateMachine.appear;
            stateTimer = 0;
            animator.SetTrigger("Appear");
        }
    }

    private void appearStateControl()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
        {
            currentState = StateMachine.wait;
        }
    }
    
    private void waitStateControl()
    {
        stateTimer += Time.deltaTime;
        if (stateTimer >= waitTime)
        {
            currentState = StateMachine.aim;
            stateTimer = 0;
            animator.SetTrigger("Aim");
        }
    }

    private void aimStateControl()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
        {
            currentState = StateMachine.shoot;
        }
    }

    private void shootStateControl()
    {
        stateTimer += Time.deltaTime;
        if (stateTimer >= shootTime)
        {
            currentState = StateMachine.hide;
            stateTimer = 0;
            animator.SetTrigger("Hide");
        }
    }

    public StateMachine getCurrentState()
    {
        return currentState;
    }
}
