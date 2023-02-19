using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GameObject enemyPatrolRoute;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyPatrolRoute = GameObject.FindWithTag("PatrolRoute");

            StartCoroutine(enemyDeath());


        }
    }

    private IEnumerator enemyDeath()
    {

        animator.SetBool("enemyIsKilled", true);

        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
        Destroy(enemyPatrolRoute);
    }
}
