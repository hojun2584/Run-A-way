using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaeyoung
{
    public class Defense : Mission
    {
        [SerializeField] private float timeLimit;
        public float curTime;

        public void Start()
        {
            // �̷� �������� �ٸ� �̼ǵ� �����������
            MissionManager.instance.condition = () => { return curTime >= timeLimit; };
        }

        public override void Play()
        {
            curTime += Time.deltaTime;
            base.Play();
        }
    }
}
