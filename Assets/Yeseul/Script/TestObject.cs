using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yeseul;

namespace Yeseul
{

    public class TestObject : MonoBehaviour, IInteractive
    {
        GameObject interactiveObj;
     
        public void Interaction(GameObject interactivePlayer)
        {

            //if(interactiveObj.TryGetComponent<Player>( out Player player))
            //{
            //    player.Hp -= 10;

            //    Debug.Log(player + "�� ü�� 10 ����");
            //}

        }

    }


    public class Door : MonoBehaviour, IInteractive
    {
        public float rotationAngle = 90f; // ȸ�� ������ �����մϴ�.
        [SerializeField] bool rotateDir = false; // ȸ�� ���θ� Ȯ���ϴ� �÷����Դϴ�.

        // rotatedir �� �������� ���� ȸ�� ������ ȸ�� 

        public void Interaction(GameObject interactivePlayer)
        {
            if (!rotateDir)
            {
                transform.Rotate(Vector3.left * rotationAngle);
                rotateDir = true; 
            }
            else
            {
                transform.Rotate(Vector3.right * rotationAngle);
                rotateDir = false; 
            }
        }
    }


    public class AmmoSupply : MonoBehaviour, IInteractive
    {
        public void Interaction(GameObject interactivePlayer)
        {
                

        }
    }



}
