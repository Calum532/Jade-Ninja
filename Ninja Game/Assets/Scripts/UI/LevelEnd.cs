using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject levelCompleteUI;

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        levelCompleteUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        levelCompleteUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("LEVEL COMPLETE");
            FindObjectOfType<AudioManager>().Play("EndGong");
            levelCompleteUI.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.gameIsPaused = true;
        }
    }
}
