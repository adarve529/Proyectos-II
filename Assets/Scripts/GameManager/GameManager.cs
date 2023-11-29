using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject pauseMenu;


    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Scene Change
    public static void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    //Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
    
    //pause menu
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
