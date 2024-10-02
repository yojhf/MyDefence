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
            // 직진
        }

        public virtual void GoBack()
        {
            // 후진
        }
        public virtual void TurnLeft()
        {
            // 좌회전
        }

        public virtual void TurnRight()
        {
            // 우회전
        }
    }

    // Vehicle을 상속 받는 Car class
    public class Car : Vehicle
    {
        public override void GoForward() 
        {
            // 차가 앞으로 이동
        }
        public override void GoBack() 
        {
            // 차가 후진 한다
        }
        public override void TurnLeft() 
        {
            // 차가 좌회전 한다
        }
        public override void TurnRight() 
        {
            // 차가 우회전 한다
        }

    }

    // Vehicle을 상속 받는 Train class
    public class Train : Vehicle
    {
        public override void GoForward() 
        {
            // 기차가 앞으로 이동
        }
        public override void GoBack() 
        {
            // 기차가 뒤로 이동
        }

        public override void TurnLeft() { }
        public override void TurnRight() { }
    }
}
