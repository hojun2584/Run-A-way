using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yeseul
{
    public class MoveFov : MonoBehaviour
    {
        public float sensitivity = 1.5f;      //�þ� ȸ�� ����
        Vector2 defaultAngle = Vector2.zero;  //ī�޶� �⺻ ����
        public float yAngle = 15f;            //���� ȸ����
        //public float xAngle = 45f;          //�¿� ȸ���� (�־���ϳ�?)

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            defaultAngle.x += mouseX * sensitivity;
            defaultAngle.y -= mouseY * sensitivity;
            defaultAngle.y = Mathf.Clamp(defaultAngle.y, -yAngle, yAngle); //���� ȸ������ ����
            //defaultAngle.x = Mathf.Clamp(defaultAngle.x, -xAngle, xAngle); //�¿� ȸ������ ����

            transform.localRotation = Quaternion.AngleAxis(defaultAngle.x, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(defaultAngle.y, Vector3.right);
            transform.rotation = Quaternion.Euler(0, defaultAngle.x, 0);

        }
    }

}
