using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jinho
{
    public class WeaponData
    {
        public string weaponName;          //���� �̸�
        public Sprite image;               //�ѱ� ���� �̹���
        public float damage;               //�� �����
        public int maxBullet;              //�����Ǵ� �Ѿ� ��
        public int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
        public int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        public int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        public Transform firePos;          //�Ѿ� �߻� ��ġ
        public GameObject bullet;          //���ư� �Ѿ� GameObject
        public PlayerAttackState attackState;
        public WeaponData(string name, Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, PlayerAttackState attackState, GameObject bullet)
        {
            weaponName = name;
            this.image = image;
            this.damage = damage;
            this.maxBullet = maxBullet;
            this.bulletCount = bulletCount;
            this.maxTotalBullet = maxTotalBullet;
            this.totalBullet = totalBullet;
            this.firePos = firePos;
            this.bullet = bullet;
            this.attackState = attackState;
        }
    }
    public class Weapon
    {
        protected WeaponData weaponData;
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
        public Weapon(WeaponData weaponData)
        {
            this.weaponData = weaponData;
            this.name = weaponData.weaponName;
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
        public Rifle(WeaponData weaponData) : base(weaponData)
        {
        }

        public override void Fire()
        {
            Debug.Log("������ ��!");
        }
        public override void Reload()
        {
            Debug.Log("������ ������~");
        }
    }
    public class Shotgun : Weapon
    {
        public Shotgun(WeaponData weaponData) : base(weaponData)
        {
        }

        public override void Fire()
        {
            Debug.Log("��� ��!!");
        }
        public override void Reload()
        {

        }
    }
    public class Handgun : Weapon
    {
        public Handgun(WeaponData weaponData) : base(weaponData)
        {
        }

        public override void Fire()
        {
            Debug.Log("���� ����!!!");
        }
        public override void Reload()
        {
            
        }
    }
    public class Sword : Weapon
    {
        public Sword(WeaponData weaponData) : base(weaponData)
        {
        }
        public override void Fire()
        {
            Debug.Log("Į ����!!!!");
        }
    }
    public class Granade : Weapon
    {
        public Granade(WeaponData weaponData) : base(weaponData)
        {
        }
        public override void Fire()
        {
            Debug.Log("����ź ��ô~");
        }
    }
    public class WeaponClass : MonoBehaviour
    {
        public enum WeaponType
        {
            Rifle,
            Shotgun,
            Handgun,
            Sword,
            Granade,
        }
        public WeaponType weaponType;
        public Weapon weapon = null;
        public WeaponData weaponData = null;
        void Awake()
        {
            SetWeapon();
        }
        void SetWeapon()
        {
            switch (weaponType)
            {
                case WeaponType.Rifle:
                    weapon = new Rifle(weaponData);
                    break;
                case WeaponType.Shotgun:
                    weapon = new Shotgun(weaponData);
                    break;
                case WeaponType.Handgun:
                    weapon = new Handgun(weaponData);
                    break;
                case WeaponType.Sword:
                    weapon = new Sword(weaponData);
                    break;
                case WeaponType.Granade:
                    weapon = new Granade(weaponData);
                    break;
            }
        }
        void SetPlayerSlot(PlayerController player)
        {
            switch(weaponType)
            {
                case WeaponType.Rifle:
                case WeaponType.Shotgun:
                    player.weaponSlot[0] = weapon;
                    player.weaponObjSlot[0] = gameObject;
                    break;
                case WeaponType.Handgun:
                case WeaponType.Sword:
                    player.weaponSlot[1] = weapon;
                    player.weaponObjSlot[1] = gameObject;
                    break;
                case WeaponType.Granade:
                    player.weaponSlot[3] = weapon;
                    player.weaponObjSlot[3] = gameObject;
                    break;
            }
            gameObject.SetActive(false);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerController player))
            {
                SetPlayerSlot(player);
                player.currentWeapon = player.weaponSlot[0];
            }
        }
    }
}
