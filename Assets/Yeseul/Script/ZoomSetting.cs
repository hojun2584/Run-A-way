using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yeseul
{
    public class ZoomSetting : MonoBehaviour
    {
        public bool isZoom = false;                 //ZoomIn ����
        public CinemachineVirtualCamera ZoomInCam;

        public void ZoomIn() //��Ŭ���� ����, ��Ŭ�� ������ �ܾƿ�
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (!isZoom)
                {
                    ZoomInCam.m_Priority = 11;     //ZoomInCam�� �켱������ ZoomOutCam(10) ���� ����
                    isZoom = true;
                }
            }
            else
                ZoomInCam.m_Priority = 9;          //ZoomInCam�� �켱������ ZoomOutCam(10) ���� ����
            isZoom = false;

        }
        // Start is called before the first frame update
        void Start()
        {
            ZoomInCam = gameObject.GetComponent<CinemachineVirtualCamera>();
        }

        // Update is called once per frame
        void Update()
        {
            ZoomIn();
        }
    }

}
