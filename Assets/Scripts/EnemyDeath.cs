using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public bool enemyIsKilled = false;
    private GameObject enemyPatrolRoute;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            enemyIsKilled = true;
            enemyPatrolRoute = GameObject.FindWithTag("PatrolRoute");
            Destroy(this.gameObject);
            Destroy(enemyPatrolRoute);
        }
    }
}
