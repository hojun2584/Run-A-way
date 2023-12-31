using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hojun
{
    // 坪球 班団姶. 至展(??)
    // 越松端 鯵 瑛娠革推.
    // 展切社軒 鞠惟 展韓暗鍵陥壱 持唖梅澗汽 帖澗 言 他陥.
    // 班団亜亀 鞠蟹推? せせせせせせせせせせせせせせせせ
    
    
    //                **
    //             ********
    //               ****
    //              *    *
    //                **
    //              ******
    //            **********
    //              ******
    //            **********
    //          **************
    //        ******************
    //            **********
    //         ****************
    //       ********************
    //     ************************
    //              ******
    //              ******
    //              ******


    public class DeadState : State
    {
        Zombie ownerZombie;
        Animator aniCompo;
        NavMeshAgent agent;

        public DeadState(IStateMachine sm) : base(sm)
        {
            ownerZombie = owner.GetComponent<Zombie>();
            aniCompo = owner.GetComponent<Animator>();
            agent = owner.GetComponent<NavMeshAgent>();

            if (ownerZombie == null)
            {
                Debug.Log("ERROR");
            }

        }

        public override void Enter()
        {
            Debug.Log("dead");
            agent.SetDestination(owner.transform.position);
            ownerZombie.Die();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            
        }
    }

}
