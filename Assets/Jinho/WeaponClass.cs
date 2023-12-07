using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jinho
{
    public class Weapon
    {
        protected WeaponClass weaponData;
        public string name;         //�ѱ� �̸�
        public Sprite image;        //�ѱ� ���� �̹���
        public PlayerAttackState attackState;   //���� ���
        public float damage;        //�� �����
        public int maxBullet;       //�����Ǵ� �Ѿ� ��
        int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
        public int BulletCount
        {
            get { return bulletCount; }
            set 
            {
                bulletCount = value;
                if(bulletCount > maxBullet) bulletCount = maxBullet;
                if(bulletCount < 0 ) bulletCount = 0;
            }
        }
        int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        public int TotalBullet
        {
            get { return  totalBullet; }
            set 
            {
                totalBullet = value; 
                if(totalBullet > maxTotalBullet) totalBullet = maxTotalBullet;
                if(totalBullet < 0 ) totalBullet = 0;
            }
        }

        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        public Weapon(WeaponClass weaponData)
        {
            this.weaponData = weaponData;
            this.name = weaponData.name;
            this.image = weaponData.image;
            this.attackState = weaponData.attackState;
            this.damage = weaponData.damage;
            this.maxBullet = weaponData.maxBullet;
            BulletCount = weaponData.bulletCount;
            this.maxTotalBullet = weaponData.maxTotalBullet;
            TotalBullet = weaponData.totalBullet;
            this.firePos = weaponData.firePos;
            this.bullet = weaponData.bullet;
        }

        public virtual void Fire() { }
        public virtual void Reload() { }
    }
    public class Rifle : Weapon
    {
        public Rifle(WeaponClass weaponData) : base(weaponData)
        {
        }

        public override void Fire()
        {
            Debug.Log("������ ��!");
            GameObject bulletObj = weaponData.BulletSpawn();
            bulletObj.GetComponent<bullet>().SetBulletData(this);
            bulletObj.transform.position = firePos.position;
            bulletObj.transform.rotation = firePos.rotation;
        }
        public override void Reload()
        {
            Debug.Log("������ ������~");
        }
    }
    public class Shotgun : Weapon
    {
        public Shotgun(WeaponClass weaponData) : base(weaponData)
        {
        }

        public override void Fire()
        {
            
        }
        public override void Reload()
        {

        }
    }
    public class Handgun : Weapon
    {
        public Handgun(WeaponClass weaponData) : base(weaponData)
        {
        }

        public override void Fire()
        {
            
        }
        public override void Reload()
        {
            
        }
    }
    public class WeaponClass : MonoBehaviour
    {
        public enum WeaponType
        {
            Rifle,
            Shotgun,
            Handgun,
        }
        public WeaponType weaponType;
        public PlayerAttackState attackState;
        public Weapon weapon = null;

        public string weaponName;          //���� �̸�
        public Sprite image;               //�ѱ� ���� �̹���
        public float damage;               //�� �����
        public int maxBullet;              //�����Ǵ� �Ѿ� ��
        public int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
        public int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        public int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        public Transform firePos;          //�Ѿ� �߻� ��ġ
        public GameObject bullet;          //���ư� �Ѿ� GameObject
        void Awake()
        {
            SetWeapon();
        }
        void SetWeapon()
        {
            switch (weaponType)
            {
                case WeaponType.Rifle:
                    weapon = new Rifle(this);
                    break;
                case WeaponType.Shotgun:
                    weapon = new Shotgun(this);
                    break;
                case WeaponType.Handgun:
                    weapon = new Handgun(this);
                    break;
            }
        }
        public GameObject BulletSpawn()
        {
            return Instantiate(bullet);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerController player))
            {
                player.weaponObjSlot[0] = gameObject;
                player.weaponSlot[0] = weapon;
                player.currentWeapon = player.weaponSlot[0];
                gameObject.SetActive(false);
            }
        }
    }
}
