using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    namespace ObjectTest
    {
        public class Singleton
        {
            private static Singleton instance;

            public static Singleton Instance { get { return instance; } }

            public static Singleton SetInstance() 
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }


                return instance; 
            }



            public string Test()
            {
                string a = "ASDASD";
                return a;

            }


        }
    }
}