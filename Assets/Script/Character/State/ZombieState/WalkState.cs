using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hojun
{


    public class WalkState : State
    {

        Zombie ownerZombie;
        Animator aniCompo;

        public WalkState(IStateMachine sm) : base(sm)
        {
            GameObject owner = (GameObject)sm.GetOwner();

            if( owner.TryGetComponent<Zombie>( out ownerZombie ) ) 
            {
            }
            else
                Debug.Log("Don't have Zombie Compo");
            
        }

        public override void Enter()
        {
            aniCompo.SetBool("Walk" , true);
            ownerZombie.MoveStrategy = ownerZombie.GetMoveDict(Zombie.ZombieState.SEARCH_WALK);
            ownerZombie.Move();
        }

        public override void Exit()
        {
            aniCompo.SetBool("Walk" , false);
        }

        public override void Update()
        {



            // TODOLIST �翵���� Heara �����Ȱ� return  �������� �б��� ���� ��
            // ��� ���� �� �̳�.
            // �ű⼭ ������ enum�� �Ѿ���� ���¸� �� ��
            // �׳� �װ� ��Ī�ؼ� ������ ���°� �Ѿ���� �� �� ���ؼ� �ʿ��� ����
            // �Ѿ�� ���� ���� ��

        }

    }

}