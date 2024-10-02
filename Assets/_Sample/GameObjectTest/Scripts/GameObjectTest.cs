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

            var obj1 = ObjectTest.Singleton.SetInstance(); // ����
            var obj2 = ObjectTest.Singleton.SetInstance(); // ���� �ȵ�

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
���ӿ�����Ʈ�� gameobject, transform �����ϴ� ���, ��ü�� ���� ���� ���
1) ���ӿ�����Ʈ�� ��ũ��Ʈ �ҽ��� ������Ʈ�� �߰��Ͽ� ���� ������
2) GetComponent<�ҷ��� ������Ʈ>()
3) Find - ����Ƽ���� �����ϴ� API�� �̿��Ͽ� ��ü�� ��ȯ�޾� �����´�
4) Prefab ���� ������Ʈ ���� �� Instantiate �Լ��� ��ȯ ������ ���� ������Ʈ�� ��ü�� ����
5) �θ� �ڽİ��踦 �̿��ؼ� ���ӿ�����Ʈ�� ��ü�� �����´�
6) static �ʵ�, �̱���

*/