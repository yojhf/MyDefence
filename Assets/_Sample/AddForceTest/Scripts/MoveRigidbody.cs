using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class MoveRigidbody : MonoBehaviour
    {
        public Rigidbody rb;
        public float moveSpeed = 1.0f;
        public float force = 3.0f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            // ������ �̵�
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }



        void Update()
        {

        }

        private void FixedUpdate()
        {
            // Kinematic Move
            //rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * moveSpeed);

            if(Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.forward * force, ForceMode.Force);
            }
     

        }
    }
}

/*
3D �浹ü (�浹 ������Ʈ)
���� �浹ü : �������� �ʴ� �浹ü
- Static : ��, �ǹ�, ����

���� �浹ü : �����̴� �浹ü - Rigidbody (������Ʈ�� �������� �����·� ����)
- Kinematic : �ܺο��� ���� �������� ����, ���, �̵��ϴ� ����, ��
- Dynamic : �׿� ���������� ���ܵǴ� ������Ʈ

�浹üũ
- �� ������Ʈ�� ��� �浹ü�� ������ �־�� �Ѵ�
- ������ �ϳ��� Dynamic �̾�� �ϰ� Dynamic�� �̵��ϴ� ������Ʈ �̾�� �Ѵ�
- �̵��ϴ� Kinematic�� Dynamic�� �浹üũ�� �ȴ�


2D �浹ü (�浹 ������Ʈ)
���� �浹ü : �������� �ʴ� �浹ü
- Static : ��, �ǹ�, ����

���� �浹ü : �����̴� �浹ü - Rigidbody (������Ʈ�� �������� �����·� ����)
- Kinematic : �ܺο��� ���� �������� ����, ���, �̵��ϴ� ����, ��
- Dynamic : �׿� ���������� ���ܵǴ� ������Ʈ

�浹üũ
- �� ������Ʈ�� ��� �浹ü�� ������ �־�� �Ѵ�
- ������ �ϳ��� Dynamic �̾�� �ϰ� Dynamic�� �̵��ϴ� ������Ʈ �̾�� �Ѵ�
- �̵��ϴ� Kinematic�� Dynamic�� �浹üũ�� �ȴ�

//
AddForce : ForceMode 4����
ForceMode.Force (����, ���� ���)
- �ٶ�, �ڱ�� ó�� ���������� ���� �ִ� ��
- ª�� �ð��� �߻��ϴ� ��

ForceMode.Acceleration (����, ���� ����)
- ������ �߷�
- ������ ������� ������ ���ӷ��� �ִ� ��

ForceMode.Impulse (�ҿ���, ���� ���)
- ����, Ÿ��
- ���������� �ۿ��ϴ� ��

ForceMode.VelocityChange (�ҿ���, ���� ����)
- ������ �����ϰ� ���������� �ӵ��� ��ȭ�� �ִ� ��
- 


*/
