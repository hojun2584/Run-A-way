using Hojun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Hojun.Zombie;

namespace Hojun
{

    public class IdleState : Hojun.State
    {

        Zombie ownerZombie;
        Animator animator;


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
            animator.SetInteger( "State" , (int)ZombieState.IDLE);
            ownerZombie.MoveStrategy = ownerZombie.GetMoveDict(ZombieMove.IDLE);
        }

        public override void Exit()
        {

        }

        public override void Update()
        {

            if (ownerZombie.Target != null)
            {
                if (!ownerZombie.Target.activeSelf)
                    return;
            }
                
            if (ownerZombie.IsFindPlayer)
                stateMachine.SetState((int)Zombie.ZombieState.FIND);
            

            if (ownerZombie.HearValue >= 0.1f)
            {
                stateMachine.SetState((int)Zombie.ZombieState.SEARCH);
            }

            ownerZombie.MoveStrategy.Move();
        }


    }
}