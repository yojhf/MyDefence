using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        public static GameObjectTest instance;

        private List<Transform> tlist = new List<Transform>();

        public Transform cube;

        private GameObject[] tagobjs;
        private GameObject tagobj;

        public Transform prefabobj;

        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            Material material = GetComponent<MeshRenderer>().material;
            Collider collider = GetComponent<Collider>();
            Rigidbody rb = GetComponent<Rigidbody>();

            Material c_mat = cube.GetComponent<MeshRenderer>().material;

            //tagobjs = GameObject.FindGameObjectsWithTag("tagString");
            //tagobj = GameObject.FindGameObjectWithTag("tagString");

            //foreach (var obj in tagobjs)
            //{
            //    transform.position = obj.transform.position;
            //}

            //Transform tmp_pobj = Instantiate(prefabobj, prefabobj.position, Quaternion.identity);

            //for (int i = 0; i < transform.childCount; i++)
            //{
            //    tlist.Add(transform.GetChild(i));
            //}


            //tmp_pobj.position = transform.GetChild(0).position;
            //transform.parent = tmp_pobj;

            //StaticClass.number = 10;
            //StaticClass.instance.num = 20;

            var obj1 = ObjectTest.Singleton.SetInstance(); // 생성
            var obj2 = ObjectTest.Singleton.SetInstance(); // 생성 안됨

            Debug.Log(obj1.Test());

            if(obj1 == obj2)
            {
                Debug.Log(obj1);
            }
            var a = ObjectTest.Singleton.Instance;


            SingletonTest.instance.Test();

        }
    }
}

/*
게임오브젝트의 gameobject, transform 접근하는 방법, 객체를 가져 오는 방법
1) 게임오브젝트에 스크립트 소스를 컴포넌트로 추가하여 직접 가져옴
2) GetComponent<불러올 컴포넌트>()
3) Find - 유니티에서 제공하는 API를 이용하여 객체를 반환받아 가져온다
4) Prefab 게임 오브젝트 생성 시 Instantiate 함수의 반환 값으로 게임 오브젝트의 객체를 생성
5) 부모 자식관계를 이용해서 게임오브젝트의 객체를 가져온다
6) static 필드, 싱글턴

*/