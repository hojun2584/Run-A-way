using Hojun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Hojun.State
{

    Zombie ownerZombie;
    Animator animator;

    public float HearSoundWalk 
    {
        get 
        {

            Debug.Log("������ �����ؼ� �߰� ���� �� ��. ������ ����!");
            // TODO_LIST ���� �߰��ϴ��� �ؼ� üũ�� �� ��;
            return 10f;
        }    
    }

    public float HearSoundRun
    {

        get 
        {
            Debug.Log("������ �����ؼ� �߰� ���� �� ��. ������ ����!");
            return 20f;
        }
    }

    public IdleState(IStateMachine sm) : base(sm)
    {

        ownerZombie = owner.GetComponent<Zombie>();

        if (ownerZombie == null)
            Debug.Log("Error");

        animator = owner.GetComponent<Animator>();

        if (animator == null)
            Debug.Log("Error");

    }

    public override void Enter()
    {
        animator.SetBool("Idle" , true);
    }

    public override void Exit() 
    {
        animator.SetBool("Idle" , false);
    }

    public override void Update() 
    {

        if (ownerZombie.hearValue <= HearSoundWalk && ownerZombie.hearValue <= HearSoundRun)
        {

        }


    }


}
