using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardsEffects : MonoBehaviour
{

    public UnityEvent bonusBulletEvent;
    public UnityEvent doubleAttackEvent;

    // Start is called before the first frame update
    void Start()
    {
        bonusBulletEvent.AddListener(CreateBonusBullet);
        doubleAttackEvent.AddListener(DoubleAttack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBonusBullet()
    {
        
        Debug.Log("Create bonus bullet reward!");
    }

    public void DoubleAttack()
    {
        Debug.Log("Double attack reward!");
    }

    public delegate void RewardEffect();

    public void ChooseBonusBullet()
    {
        RewardEffect reward = GameObject.Find("RewardsManager").GetComponent<RewardsEffects>().CreateBonusBullet;
        // Add reward effect to a delegate or list of delegates
    }

    public void ChooseDoubleAttack()
    {
        RewardEffect reward = GameObject.Find("RewardsManager").GetComponent<RewardsEffects>().DoubleAttack;
        // Add reward effect to a delegate or list of delegates
    }
 

}
