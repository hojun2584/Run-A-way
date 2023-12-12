using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho {
    public class ItemGrenade : MonoBehaviour, IAttackItemable
    {
        public WeaponData weaponData;
        public WeaponData WeaponData { get => weaponData; }
        public Player Player { get => player; set { player = value; } }
        Player player = null;
        public float explosionRange;        //���� ����
        public ItemType ItemType { get => weaponData.itemType; }
        Vector3 endPos, startPos;           //���ư� ��ġ
        public int maxBullet;       //�����Ǵ� �Ѿ� ��
        int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
        public int BulletCount
        {
            get { return bulletCount; }
            set
            {
                bulletCount = value;
                if (bulletCount > maxBullet) bulletCount = maxBullet;
                if (bulletCount < 0) bulletCount = 0;
            }
        }
        int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        public int TotalBullet
        {
            get { return totalBullet; }
            set
            {
                totalBullet = value;
                if (totalBullet > maxTotalBullet) totalBullet = maxTotalBullet;
                if (totalBullet < 0) totalBullet = 0;
            }
        }
        public void Use()
        {
            /*
            if (weaponData.BulletCount == 0)
                return;
            weaponData.BulletCount--;
            */
            startPos = transform.position;
            //endPos = weaponData.player.aimPos;
            StartCoroutine(MoveCo());
        }
        public void Reload()    //����ź�� reload ����
        {
            return;
        }
        public void SetItem(Player player)
        {
            if (player.weaponObjSlot[3] != null)
            {
                GameObject temp = player.weaponObjSlot[3];
                temp.transform.position = transform.position;
                temp.GetComponent<IAttackItemable>().Player = null;
                player.weaponObjSlot[3] = null;
                temp.SetActive(true);
            }
            this.player = player;
            player.weaponObjSlot[3] = gameObject;
            player.weaponObjSlot[3].SetActive(false);
        }
        IEnumerator MoveCo()            //�������� ��ġ�� ���ư��� �Լ�
        {
            float timer = 0;
            while (true)
            {
                timer += Time.deltaTime;
                transform.position = Parabola(startPos, endPos, Vector3.Distance(startPos, endPos) / 2, timer);
                yield return new WaitForEndOfFrame();
            }
        }
        Vector3 Parabola(Vector3 start, Vector3 end, float height, float time)      //������ ���ϴ� ����
        {
            Func<float, float> f = x => -4 * height * x * x + 4 * height * x;       //  y = -4ax^2 + 4ax + 0 = f(x)
            var mid = Vector3.Lerp(start, end, time);                                     //mid = x;
            return new Vector3(mid.x, f(time) + Mathf.Lerp(start.y, end.y, time), mid.z);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) && this.player == null)
            {
                SetItem(player);
            }
            GetComponent<ExplosionComponent>().Explosion(weaponData.damage, explosionRange);
            gameObject.SetActive(false);
        }
    }
}
