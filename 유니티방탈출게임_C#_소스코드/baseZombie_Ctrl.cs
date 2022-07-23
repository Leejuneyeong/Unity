using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseZombie_Ctrl : MonoBehaviour
{

    enum state
    {

        Idle,       //기본상태
        Walk,           //걷기상태
        Attack,         //공격상태
        Run,            //뛰는상태
        Death,           //죽음
    }
    state zombieState = state.Idle;

    float speed = 4.0f;        //이동속도
    float rotSpeed = 4.0f;     //회전속도
    float attackSpeed = 2.0f;  //공격속도
    int hp = 5;                 //좀비 hp

    float eyesight = 10.0f;     //시야(공격 유효 범위)
    float attackRange = 1.8f;   //공격사정거리

    //플레이어(타켓 설정)
    GameObject target;  //좀비의 타켓(플레이어)

    //좀비 애니메이션
    public Animator zombieAni;
    CharacterController zombieController;
    Vector3 orignPos;   //처음 생성위치 저장

    void Awake()
    {
        zombieAni = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        zombieController = GetComponent<CharacterController>();
        orignPos = this.transform.position;
    
    }
    void Start()
    {
        Invoke("ZombieIdle", 5.0f);
    }

    //좀비 초기화시키기
    public void ZombieIdle()
    {
        zombieAni.SetBool("Idle", true);

        zombieAni.SetBool("Attack", false);
        zombieAni.SetBool("Run", false);
        zombieState = state.Idle;
    }
    void Update()
    {
        ZombieState();
    }

    void ZombieState()
    {
        switch (zombieState)
        {
            case state.Idle:
                {
                    float distance = Vector3.Distance(target.transform.position, this.transform.position);

                    if (distance <= attackRange) // 공격범위에 들어오면 어택모드
                    {

                        zombieAni.SetBool("Attack", true);
                        zombieAni.SetBool("Run", false);

                        zombieState = state.Attack;
                    }
                    else if (distance <= eyesight) // 공격범위보단 멀지만 시야에 들어오면 달리기
                    {
                        zombieAni.SetBool("Run", true);
                        zombieAni.SetBool("Idle", false);
                        zombieState = state.Run;
                    }
                }
                break;
            case state.Run:
                {
                    float distance =
                    Vector3.Distance(target.transform.position, this.transform.position);
                    Vector3 dir = target.transform.position - this.transform.position;
                    dir.y = 0;
                    dir.Normalize();    //거리 평준화 함수
                    zombieController.SimpleMove(dir * speed);   //이동함수
                    transform.rotation =
Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);  //회전
                    if (distance > eyesight)  //거리가 시야보다 멀면 두리번모드
                    {
                        zombieAni.SetBool("Idle", true);
                        zombieAni.SetBool("Run", false);
                        zombieState = state.Idle;
                    }
                    else if (distance <= attackRange)         //공격범위 안에 오면 공격모드
                    {

                        zombieAni.SetBool("Attack", true);
                        zombieAni.SetBool("Run", false);

                        zombieState = state.Attack;
                    }
                }
                break;



        }
    }

}
