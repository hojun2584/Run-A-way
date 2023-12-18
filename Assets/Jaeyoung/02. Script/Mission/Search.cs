using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Jaeyoung
{
    public class Search : Mission
    {
        [SerializeField] private GameObject targetItem;
        [SerializeField] private SpawnPoint spawnItemPoint;
        public int targetCount;
        [SerializeField] private int curCount;
        public int CurCount
        { 
            get { return curCount; }
            set 
            {
                curCount = value;
                // ������ �� �̼� ���� UI����
            }
        }

        private void Start()
        {
            if (!PhotonNetwork.IsMasterClient)
                return;

            if(targetCount > spawnItemPoint.points.Count)
                targetCount = spawnItemPoint.points.Count;

            // ã�ƾ� �ϴ� ������ŭ ����(��ġ�� ��ġ�� ����)
            for (int i = 0; i < targetCount; i++)
            {
                int index = Random.Range(0, spawnItemPoint.points.Count);
                GameObject obj = PhotonNetwork.Instantiate(targetItem.name, spawnItemPoint.points[index].position, spawnItemPoint.points[index].rotation);
                spawnItemPoint.points.RemoveAt(index);
            }
        }

        public override void Play()
        {
            base.Play();
        }

        public override bool Condition()
        {
            // �������� �������� ã�Ҵ°�?
            return curCount == targetCount;
        }
    }
}
