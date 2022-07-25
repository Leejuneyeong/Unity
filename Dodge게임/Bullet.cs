using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 탄알 이동 속력
    public float speed = 8f;
    // 이동에 사용할 리지드바디 컴포넌트
    private Rigidbody bulletRigidbody;
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        // GetComponent<Rigidbody>(); <- 직접 찾아오는 과정
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력 
        // 게임 오브젝트의 앞쪽 방향으로 speed 만큼의 속도를 표현한 값
        bulletRigidbody.velocity = transform.forward * speed;
        // transform.forward = 자신의 트랜스폼 컴포넌트에 바로 접근

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other){
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if(other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();
            
            // 상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
            if(playerController != null)
            {
                // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
