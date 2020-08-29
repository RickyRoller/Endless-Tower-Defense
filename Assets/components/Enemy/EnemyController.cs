using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class EnemyController : MonoBehaviour
{
    public EnemyStats _baseStats;
    public EnemyStats stats;
    public Vector3 destination;
    public Units unitList;
    public Image healthBar;
    public State currentState;

    public enum State
    {
        RUNNING,
        ATTACKING,
    }

    private GameManager GameManager;
    private Animator animator;
    private float attackTime;

    [ProgressBar(0, 1), ShowInInspector]
    private float attackTimeBar
    {
        get { return attackTime / _baseStats.attackSpeed; }
    }

    private void Start()
    {
        unitList.Add(gameObject);
        currentState = State.RUNNING;
        stats = _baseStats;
        attackTime = _baseStats.attackSpeed;

        animator = GetComponent<Animator>();
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnDestroy()
    {

        unitList.Remove(gameObject);
    }

    void Update()
    {
        switch (currentState)
        {
            case State.ATTACKING:
                Attack();
                break;
            case State.RUNNING:
            default:
                Run();
                break;
        }
    }

    private void Attack()
    {
        if (attackTime <= 0)
        {
            animator.SetTrigger("Attack");
            attackTime = stats.attackSpeed;
            StartCoroutine(DealDamage());
        } else
        {
            attackTime -= Time.deltaTime;
        }
    }

    private IEnumerator DealDamage()
    {
        yield return new WaitForSeconds(0.3f);
        GameManager.wallController.SendMessage("ApplyDamage", stats.damage);

    }

    private void Run()
    {
        if (transform.position != destination && destination != null)
        {
            LookAtTarget();
            MoveToTarget();
        } else
        {
            currentState = State.ATTACKING;
            animator.SetBool("isRunning", false);
        }
    }

    private void MoveToTarget()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, destination, stats.speed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(position);
    }

    private void LookAtTarget()
    {
        transform.LookAt(destination);
    }

    public void ApplyDamage(float damage)
    {
        Debug.Log("Took Damage: " + damage);
        if (stats.health - damage <= 0)
        {
            Destroy(gameObject);
        }
        stats.health -= damage;
        healthBar.fillAmount = stats.health / _baseStats.health;
    }
}
