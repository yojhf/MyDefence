using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    [Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public int count;
        public float delayTime;
    }
}
