using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    private void Awake()
    {

    }

    private void OnEnable()
    {
        // 1ȸ ���� - Ȱ��ȭ �� ��
        Debug.Log("123");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 1�ʿ� 50�� ȣ�� - ����
    }

    void Update()
    {
        // �������� ���� ȣ��, 1�ʿ� 60�� ȣ���� ��ǥ
    }

    private void LateUpdate()
    {
        // ������Ʈ ȣ�� �� �ٷ� ���� ȣ�� => �ַ� ī�޶� ���õ� �ý��ۿ� ���
    }

    private void OnDisable()
    {
        // 1ȸ ���� - ��Ȱ��ȭ �� �� 
        Debug.Log("456");
    }

    private void OnDestroy()
    {
        // ����� ��
    }

}
