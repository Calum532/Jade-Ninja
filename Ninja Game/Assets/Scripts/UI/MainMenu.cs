using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject storyUI;
    public GameObject LevelSelectUI;

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

    public void Back()
    {
        menuUI.SetActive(true);
        storyUI.SetActive(false);
        LevelSelectUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
