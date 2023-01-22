using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveRoute : MonoBehaviour
{
    [SerializeField] private GameObject[] moveRoutes;
    public float enemyMoveSpeed = 3.0f;

    int currentMoveRouteIndex = 0;

    Animator enemyAnimator;
    Transform enemyTransform;

    private void Awake()
    {
        enemyTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, moveRoutes[currentMoveRouteIndex].transform.position, Time.deltaTime * enemyMoveSpeed);

        if (Vector2.Distance(moveRoutes[currentMoveRouteIndex].transform.position, enemyTransform.position) < .1f)
        {
            currentMoveRouteIndex++;
            

            if (currentMoveRouteIndex >= moveRoutes.Length)
            {
                currentMoveRouteIndex = 0;
                enemyTransform.localScale = Vector2.one;

            } else
            {

                enemyTransform.localScale = new Vector2(-1, 1);
            }
        }

        //Activate run-animation
    }
}
