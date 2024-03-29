using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //이동에 사용할 리지드바디 컴포넌트
    private Rigidbody playerRigidbody;
    // 이동 속력
    public float speed = 8f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0 , zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
    }

    public void Die(){
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
        // gameObject : 모든 컴포넌트는 자신을 사용 중인 게임 오브젝트에 접근
        // GameObject : 타입 , gameObject : 변수
    }
}
