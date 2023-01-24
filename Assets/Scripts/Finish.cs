using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Animator portalAnimator;
    public string levelToLoad;

    private void Awake()
    {
        portalAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            portalAnimator.SetBool("isClosing", true);
            
            StartCoroutine(ClosePortalAndLoadLevel());

            collision.gameObject.SetActive(false);
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator ClosePortalAndLoadLevel()
    {
        
        yield return new WaitForSeconds(1.0f);

        LoadLevel(levelToLoad);
    }
}
