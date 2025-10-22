using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class UIManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Start Screen")]
    [SerializeField] private GameObject startText;
    [SerializeField] private float time;

    [SerializeField] private GameObject endScreen;
    private int currentScene;
    private void Awake()
    {
        Time.timeScale = 1;
        StartCoroutine(StartScreen());
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void ToL1()
    {
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    private IEnumerator StartScreen()
    {
        startText.SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        startText.SetActive(false);
    }


    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
}
