using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hojun
{

    public class ZombieAttack : MonoBehaviour, IAttackAble
    {
        public GameObject GetAttacker()
        {
            return gameObject;
        }

        public float GetDamage()
        {
            Debug.Log("getdamage");
            return 3f;
        }
    }
}