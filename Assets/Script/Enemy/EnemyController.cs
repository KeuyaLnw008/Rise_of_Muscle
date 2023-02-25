using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public EnemyProfile _enemy;
    public int Hp { get; set; }

    [Header("DontTouch")]
    GameObject targetPlayer;
    GameObject[] players;
    public bool facingRight = false;
    [SerializeField] private Animator animator;
    private void Start()
    {
        Hp = _enemy.maxHP;
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    private void Update()
    {
        if (Hp > 0)
        {
            FindNearTarget();
            MoveToTarget();
            CheckFlip();
        }

        StartCoroutine(Die());
    }

    void FindNearTarget()
    {
        foreach (GameObject player in players)
        {
            if (player.GetComponent<Player2DStats>().PlayerHP > 0)
            {
                if (targetPlayer == null)
                {
                    targetPlayer = player;
                }
                else if (PAndTDistance(player) < PAndTDistance(targetPlayer))
                {
                    targetPlayer = player;
                }
            }
        }
        if (targetPlayer.GetComponent<Player2DStats>().PlayerHP <= 0)
        {
            targetPlayer = null;
        }
        else { }
    }
    void MoveToTarget()
    {
        if (PAndTDistance(targetPlayer) > _enemy.fixRangeToWalk && Hp > 0 && !this.GetComponent<EnemyAttack>().attacking)
        {
            animator.SetBool("IsMoving",true);
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, _enemy.speed * Time.deltaTime);
        }
        else animator.SetBool("IsMoving", false);
    }

    IEnumerator  Die()
    {
        if (Hp <= 0)
        {
            SoundManager.instance.Play(SoundManager.SoundName.EnemyDead);
            animator.SetBool("Dead",value:true);
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
    float PAndTDistance(GameObject target)
    {
        if (target == null)
        {
            return 0;
        }
        else
        {
            return Vector2.Distance(target.transform.position, transform.position);
        }
    }
    void CheckFlip()
    {
        if (targetPlayer == null)
        { }
        else
        {
            if (targetPlayer.transform.position.x < gameObject.transform.position.x && facingRight)
                Flip();
            if (targetPlayer.transform.position.x > gameObject.transform.position.x && !facingRight)
                Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
}
