using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsScreen;

    private void Awake()
    {
        creditsScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        creditsScreen.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CreditsBack()
    {
        creditsScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
}
