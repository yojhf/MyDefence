using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public class RoadVehicle : IMoveAble, ITurnAble
    {
        public void GoForward() 
        {
            // 도로위 탈것이 전진
        }
        public void GoBack() 
        {
            // 도로위 탈것이 후진
        }
        public void TurnLeft() 
        {
            // 도로위 탈것이 좌회전
        }
        public void TurnRight() 
        {
            // 도로위 탈것이 우회전
        }
    }

}
