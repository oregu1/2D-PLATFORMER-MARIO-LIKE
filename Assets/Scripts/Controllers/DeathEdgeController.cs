using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathEdgeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BoxCollider2D playerCollider = collision.GetComponent<BoxCollider2D>();//get access to player's BoxCollider2D-component

        if (playerCollider != null)
        {
            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reload the scene after 3 seconds sicne player dies
    }
}
