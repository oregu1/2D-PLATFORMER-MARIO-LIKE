using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    public Transform startingPoint;

    private void Awake()
    {
        startingPoint = GameObject.FindWithTag("StartingPoint").GetComponent<Transform>();
    }
    private void Start()
    {
        LoadCharacterToScene();
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You quit");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);

        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }

    public void LoadCharacterToScene()
    {
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");
        Instantiate(characterPrefabs[characterIndex], new Vector2(startingPoint.transform.position.x - 1, startingPoint.transform.position.y), Quaternion.identity);
        
    }
}
