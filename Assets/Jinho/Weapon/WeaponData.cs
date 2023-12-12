using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    public enum ItemType
    {
        rifle,
        shotgun,
        Melee,
        Handgun,
        HealKit,
        Grenade,
    }
    public interface IUseable
    {
        public ItemType ItemType { get; }
        public Player Player { get; set; }
        void Use();
        void Reload();
        void SetItem(Player player);
    }
    public interface IAttackItemable : IUseable
    {
        public WeaponData WeaponData { get; }
    }
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Object/Weapon Data", order = int.MaxValue)]
    public class WeaponData : ScriptableObject
    {
        public ItemType itemType;   //������ Ÿ��
        public string itemName;     //������ �̸�
        public Sprite image;        //������ �̹���
        public float damage;        //�� �����
        
    }
}
