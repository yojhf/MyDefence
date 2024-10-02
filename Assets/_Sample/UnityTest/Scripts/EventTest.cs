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
        // 1회 실행 - 활성화 될 때
        Debug.Log("123");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 1초에 50번 호출 - 고정
    }

    void Update()
    {
        // 매프레임 마다 호출, 1초에 60번 호출을 목표
    }

    private void LateUpdate()
    {
        // 업데이트 호출 후 바로 다음 호출 => 주로 카메라에 관련된 시스템에 사용
    }

    private void OnDisable()
    {
        // 1회 실행 - 비활성화 될 때 
        Debug.Log("456");
    }

    private void OnDestroy()
    {
        // 사라질 때
    }

}
