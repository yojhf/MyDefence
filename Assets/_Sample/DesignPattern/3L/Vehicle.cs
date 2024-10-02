using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public class Vehicle
    {
        public float speed;
        public Vector3 direction;

        public virtual void GoForward()
        {
            // ����
        }

        public virtual void GoBack()
        {
            // ����
        }
        public virtual void TurnLeft()
        {
            // ��ȸ��
        }

        public virtual void TurnRight()
        {
            // ��ȸ��
        }
    }

    // Vehicle�� ��� �޴� Car class
    public class Car : Vehicle
    {
        public override void GoForward() 
        {
            // ���� ������ �̵�
        }
        public override void GoBack() 
        {
            // ���� ���� �Ѵ�
        }
        public override void TurnLeft() 
        {
            // ���� ��ȸ�� �Ѵ�
        }
        public override void TurnRight() 
        {
            // ���� ��ȸ�� �Ѵ�
        }

    }

    // Vehicle�� ��� �޴� Train class
    public class Train : Vehicle
    {
        public override void GoForward() 
        {
            // ������ ������ �̵�
        }
        public override void GoBack() 
        {
            // ������ �ڷ� �̵�
        }

        public override void TurnLeft() { }
        public override void TurnRight() { }
    }
}
