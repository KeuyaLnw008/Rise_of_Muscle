using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header ("Fire")]
    [SerializeField] public EnemyProfile _enemy;
    private float nextFire = 0;

    [Header ("Dont Touch")]
    public bool triggerStayCheck = false;
    public Collider2D col;
    public bool attacking;
    [SerializeField]private Animator animator;

    private void Update()
    {
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        if (triggerStayCheck && Time.time >= nextFire)
        {
            nextFire += _enemy.fireRate + _enemy.atkAnimationSec;
            attacking = true;
            animator.SetBool("Attack", true);
            Debug.Log("attacking");
            yield return new WaitForSeconds(_enemy.atkAnimationSec);
            attacking = false;
            animator.SetBool("Attack", false);
            Debug.Log("attacked");
        }
    }
}
