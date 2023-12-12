using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Jinho
{
    public class ItemShotgun : MonoBehaviour, IAttackItemable
    {
        public WeaponData weaponData;
        public WeaponData WeaponData { get { return weaponData; } }
        public Player Player { get => player; set { player = value; } }
        Player player = null;
        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        Transform aimPos;           //�Ѿ��� ���ư� ��ġ
        public ItemType ItemType => weaponData.itemType;
        public int maxBullet;       //�����Ǵ� �Ѿ� ��
        [SerializeField] int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
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
        [SerializeField] int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        [SerializeField] int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
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
        public Collider weaponCol;
        void SetTransform(Vector3[] array)   //��� ���� �Ѿ� 9���� ������ ��ǥ
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.insideUnitSphere * 1.0f + aimPos.position;    //aimPos���� ���� �� ���� ���� ���� ��ǥ�� ����
            }
        }
        public void Use()
        {
            /*
            if (weaponData.BulletCount == 0)
                return;
            weaponData.BulletCount--;
            */
            //����Ʈ + ����
            Vector3[] targetPosArray = new Vector3[9];
            aimPos = player.Aim.aimObjPos;
            SetTransform(targetPosArray);
            //�Ѿ��� ������ ȿ��
            for(int i=0; i<targetPosArray.Length; i++)
            {
                GameObject bulletObj = Instantiate(bullet);
                Bullet bulletScript = bulletObj.GetComponent<Bullet>();
                bulletScript.SetBulletData(weaponData, Player);
                bulletScript.SetBulletVec(firePos, targetPosArray[i]);
            }
        }
        public void Reload()
        {
            if (BulletCount == maxBullet) return;
                BulletCount += 1;
        }
        public void SetItem(Player player)
        {
            if (player.weaponObjSlot[0] != null)
            {
                GameObject temp = player.weaponObjSlot[0];
                temp.transform.position = transform.position;
                temp.GetComponent<IAttackItemable>().Player = null;
                player.weaponObjSlot[0] = null;
                temp.SetActive(true);
            }
            this.player = player;
            player.weaponObjSlot[0] = gameObject;
            //player.weaponObjSlot[0].SetActive(false);
            weaponCol.enabled = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) && this.player == null)
            {
                Debug.Log("asdf");
                SetItem(player);
            }
        }
    }
}
