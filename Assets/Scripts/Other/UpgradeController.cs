using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour {

    [SerializeField]
    private GameObject upgradeItem;

    private Animator animator;

    [SerializeField]
    private Transform spawnItemPosition;

    public enum StateMachine
    {
        wait,
        item,
        after
    }

    private StateMachine currentState;

    private float throwItemPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = StateMachine.wait;
        throwItemPosition = 0;
    }

    void Update()
    {
        switch (currentState)
        {
            case StateMachine.wait:
                waitStateControl();
                break;
            case StateMachine.item:
                itemStateControl();
                break;
        }
    }

    public void waitStateControl()
    {
        if (transform.position.x < throwItemPosition)
        {
            currentState = StateMachine.item;
            animator.SetTrigger("Item");
        }
    }

    public void itemStateControl()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Final")){
            currentState = StateMachine.after;
            GameObject.Instantiate(upgradeItem, spawnItemPosition.position, upgradeItem.transform.rotation);
        }
    }

	public void setUpgrade(GameObject upgradeItem)
    {
        this.upgradeItem = upgradeItem;
    }

    public StateMachine getCurrentState()
    {
        return currentState;
    }
}
