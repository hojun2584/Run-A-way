using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionComponent : MonoBehaviour
{
    public float explosionRange;        //���� ����
    public float damage;                //���� �����
    public void Explosion(float damage, float explosionRange = 0) //����
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRange);
        //����Ʈ + ���� �߻�

        if(cols.Length > 0)
        {
            foreach(var col in cols)
            {
                //if(col.TryGetComponent(out IHitable hitable)) hitable.Hit(damage);
            }
        }
    }
}
