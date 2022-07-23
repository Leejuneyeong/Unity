using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private string AttackSound;
    public int attackDamage = 10;
    public Animator animator;

    GameObject player;
 
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    bool enableAttack = false; // 공격이 가능하다면 true 불가능하다면 false
    bool enableAttackSound = true; // 재생이 가능하면 true 불가능 하다면 false

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        animator = this.GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) //현재 애니메이터 상태가 어택일 경우
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.2f && enableAttackSound)
            { // 칼소리 재생을 한 번만 하도록 bool타입의 enableAttackSound 변수를 둬서 이를 해결함.
                SoundManager.instance.PlaySE(AttackSound);
                enableAttackSound = false; 
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f) {
                enableAttackSound = true;
            }

            if (playerInRange && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.3f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.5f)
            { // 마찬가지로 데미지도 한 번만 주도록 bool타입의 enableAttack 변수를 둬서 이를 해결함
                
                Attack();
                enableAttack = false;
            }
            else if(playerInRange && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.3f)
            {
                enableAttack = true;
            }
        }
    }

    void Attack()
    {
        if (playerHealth.currentHealth > 0 && enableAttack)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}