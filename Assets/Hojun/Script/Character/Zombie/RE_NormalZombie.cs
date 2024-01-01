using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Hojun;
using UnityEditor;
using UnityEngine.AI;
using Jaeyoung;
using System;
using Unity.VisualScripting;
using JetBrains.Annotations;
using Photon.Pun;
using Photon;
using Photon.Realtime;



namespace Hojun
{

    public class RE_NormalZombie : Zombie
    {
        [PunRPC]
        public event Action dieAction;
        public event Action attackAction;

        // obj pool ���� ������ų �� �ʿ��� �ʱ�ȭ �Լ��� �����ִ� �뵵
        [PunRPC]
        public event Action pool_InitZombie;

        public IAttackStrategy attackStrategy;
        public IHitStrategy hitStrategy;
        Animator animator;
        [SerializeField] float deathTime = 3.0f;

        public override float Hp
        {
            get => base.Hp;
            set
            {
                if (value <= 0)
                    stateMachine.SetState((int)Zombie.ZombieState.DEAD);

                base.Hp = value;
            }
        }

        public override IAttackStrategy AttackStrategy => attackStrategy;

        public new void Awake()
        {

            base.Awake();

            InitZombie();

            hearComponent = gameObject.GetComponent<HearComponent>();
            animator = GetComponent<Animator>();

            dieAction += () => { StartCoroutine(DieCo()); };

            //attackStrategy = new ZombieAttack();

        }



        // Update is called once per frame
        void Update()
        {
            stateMachine.Update();
        }

        IEnumerator DieCo()
        {
            animator.SetInteger("State", (int)ZombieState.DEAD);
            yield return new WaitForSeconds(deathTime);
            PoolingManager.instance.ReturnPool(this.gameObject);
        }

        public override void Die()
        {
            dieAction();
        }

        void InitZombie()
        {
            moveDict.Add(ZombieMove.SEARCH, new SearchStrategy(this));
            moveDict.Add(ZombieMove.IDLE, new IdleStrategy(this));
            moveDict.Add(ZombieMove.FIND, new FindStrategy(this));

            stateMachine.AddState((int)Zombie.ZombieState.IDLE, new IdleState(stateMachine));
            stateMachine.AddState((int)Zombie.ZombieState.SEARCH, new SearchState(stateMachine));
            stateMachine.AddState((int)Zombie.ZombieState.FIND, new FindState(stateMachine));
            stateMachine.AddState((int)Zombie.ZombieState.DEAD, new DeadState(stateMachine));
            stateMachine.AddState((int)Zombie.ZombieState.ATTACK, new AttackState(stateMachine));

            stateMachine.SetState((int)Zombie.ZombieState.IDLE);
        }


        public void OnTriggerEnter(Collider other)
        {

            if (other.TryGetComponent<IAttackAble>(out IAttackAble attack))
            {
                photonView.RPC("Hit", RpcTarget.All, attack.GetDamage());
            }

        }


        [PunRPC]
        public override void Hit(float damage, IAttackAble attacker)
        {
            Debug.Log("hit");
            Hp -= damage;
        }

        public override float GetDamage()
        {
            return attackStrategy.GetDamage();
        }

        [PunRPC]
        public override void Hit(float damage)
        {
            Debug.Log("hit");
            Hp -= damage;
        }
    }



}
