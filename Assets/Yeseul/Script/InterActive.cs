using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yeseul
{

    public class InterActive : MonoBehaviour
    {
        // ������

        public float range = 2f; // ��ȣ�ۿ� ��� Ž������

        GameObject FindNearestObj(Collider[] cols) // ����� �������̽� ������� üũ 
        {

            GameObject nearestObj = null;

            float leastDistance = Mathf.Infinity;

            foreach (Collider itemCol in cols)
            {
                if (itemCol.TryGetComponent(out IInteractive inter))    //IInteractive �������̽��� �������� �Ÿ�üũ
                {
                    float distance = Vector3.Distance(transform.position, itemCol.transform.position);

                    if (distance < leastDistance)
                    {
                        leastDistance = distance;
                        nearestObj = itemCol.gameObject;
                    }
                }
            }

            return nearestObj;
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, range);
                
                if (cols.Length != 0)
                {
                    IInteractive interactiveObj = FindNearestObj(cols).GetComponent<IInteractive>();
                    interactiveObj?.Interaction(this.gameObject);
                }
            }
        }


    }
}
