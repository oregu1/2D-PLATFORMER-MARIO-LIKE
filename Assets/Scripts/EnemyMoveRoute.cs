using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveRoute : MonoBehaviour
{
    [SerializeField] private GameObject[] moveRoutes;
    public float enemyMoveSpeed = 3.0f;

    int currentMoveRouteIndex = 0;
    private bool isMoving;

    Animator enemyAnimator;
    [SerializeField] private Transform enemyTransform;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        IsMoving();
    }

    void IsMoving()
    {
        isMoving = true;
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, moveRoutes[currentMoveRouteIndex].transform.position, Time.deltaTime * enemyMoveSpeed);

        if (Vector2.Distance(moveRoutes[currentMoveRouteIndex].transform.position, enemyTransform.position) < .1f)
        {
            currentMoveRouteIndex++;


            if (currentMoveRouteIndex >= moveRoutes.Length)
            {
                currentMoveRouteIndex = 0;
                enemyTransform.localScale = Vector2.one;

            }
            else
            {

                enemyTransform.localScale = new Vector2(-1, 1);
            }
        }

        //Activate run-animation
        enemyAnimator.SetBool("isMoving", isMoving);
    }
}
