using Hojun;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

namespace Jaeyoung
{
    // ���� �߻��� ����üũ
    public class SoundComponent : MonoBehaviour
    {
        public float soundAreaSize;
        public float time;

        private void OnEnable()
        {
            Collider[] coll = Physics.OverlapSphere(transform.position, soundAreaSize);

            if (coll.Length > 0)
            {
                foreach (Collider zombie in coll)
                {
                    if (zombie.TryGetComponent<IHearAble>(out IHearAble zom))
                        zom.Hear(this.gameObject);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, soundAreaSize);
        }
    }
}