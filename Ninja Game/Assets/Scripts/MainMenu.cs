using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject storyUI;

    public void DisplayStory()
    {
        menuUI.SetActive(false);
        storyUI.SetActive(true);
    }

    public void Back()
    {
        menuUI.SetActive(true);
        storyUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
