using Hojun;
using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Jaeyoung
{
    // 231211 hojun made
    // 들려서 찾았다는 확신할 수 있는 범위 팀원과 상의 할 것.

    public class HearComponent : MonoBehaviourPunCallbacks , IHearAble
    {
        // 추격, 인식 범위 (밸런스 수정시 값 수정)
        const float ChaseValue = 2.0f;
        const float DetectiveValue = 1.0f;

        [SerializeField]
        float resultDistance;
        [SerializeField]
        GameObject soundOwner;
        [SerializeField]
        Vector3 soundArea;


        public GameObject SoundOwner 
        {
            get 
            {
                return soundOwner;
            }
            set
            {
                soundOwner = value;
                if(value != null)
                    soundArea = value.transform.position;
            }
        }
        
        public Vector3 SoundArea 
        {
            get { return soundArea; }
        }

        public float ResultDistance 
        {
            get
            {
                return resultDistance;
            }    
        }


        [PunRPC]
        public void Hear(GameObject soundOwner)
        {
            float soundSize = soundOwner.GetComponent<SoundComponent>().soundAreaSize;
            resultDistance = (soundSize - Vector3.Distance(transform.position, soundOwner.transform.position));
            SoundOwner = soundOwner;
        }

        public void InitTarget()
        {
            resultDistance = 0.0f;
            soundOwner = null;
            soundArea = Vector3.zero;
        }

    }
}