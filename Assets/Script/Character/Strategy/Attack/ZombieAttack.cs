using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hojun
{

    public class ZombieAttack : IAttackStrategy
    {
        public float Attack(IHitAble hitObj)
        {
            Debug.Log("attack �̰� ���� �Ұ� return �� ����� ������ �Ⱥ���");

            return 10f;
        }

        public float GetDamage()
        {
            Debug.Log("getdamage call �̰� ���� �Ұ� return �� ����� ������ �Ⱥ���");
            return 10f;
        }
    }
}