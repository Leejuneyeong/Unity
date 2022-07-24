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
    {   // 상하좌우 방향키를 감지하고 게임 오브젝트를 해당 방향으로 움직임
        // Input.GetKey = bool 타입 해당 키를 누르고 있으면 true 그렇지 않으면 false
        // Input.GetKey() = '누르는 동안' true 그렇지 않으면 false
        // Input.GetKeyDown() = '누르는 순간' true 그렇지 않으면 false
        // Input.GetKeyUp() = '떼는 순간 true 그렇지 않으면 false
        if(Input.GetKey(KeyCode.UpArrow)==true){
            // 위쪽 방향키 입력이 감지된 경우 z 방향 힘 주기
            playerRigidbody.AddForce(0f,0f,speed);
        }

        if(Input.GetKey(KeyCode.DownArrow)==true){
            // 아래 방향키 입력이 감지된 경우 -z 방향 힘 주기
            playerRigidbody.AddForce(0f,0f,-speed);
        }

        if(Input.GetKey(KeyCode.RightArrow)==true){
            // 오른쪽 방향키 입력이 감지된 경우 x 방향 힘 주기
            playerRigidbody.AddForce(speed,0f,0f);
        }

        if(Input.GetKey(KeyCode.LeftArrow)==true){
            // 왼쪽 방향키 입력이 감지된 겨웅 -x 방향 힘 주기
            playerRigidbody.AddForce(-speed,0f,0f);
        }
    }

    public void Die(){
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
        // gameObject : 모든 컴포넌트는 자신을 사용 중인 게임 오브젝트에 접근
        // GameObject : 타입 , gameObject : 변수
    }
}
