using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject storyUI;
    public GameObject LevelSelectUI;
    public GameObject ControlsUI;
    private int sceneToContinue;

    public void Continue()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if(sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
        }
        else
        {
            return;
        }
    }

    public void DisplayStory()
    {
        menuUI.SetActive(false);
        storyUI.SetActive(true);
    }

    public void LevelSelect()
    {
        LevelSelectUI.SetActive(true);
        menuUI.SetActive(false);
    }

    public void DisplayControls()
    {
        ControlsUI.SetActive(true);
        menuUI.SetActive(false);
    }

    public void Back()
    {
        menuUI.SetActive(true);
        storyUI.SetActive(false);
        LevelSelectUI.SetActive(false);
        ControlsUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
