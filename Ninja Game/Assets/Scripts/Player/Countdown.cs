using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Text countdownText;
    [SerializeField] private float mainTimer;

    private float timer;
    public static float finishTime;
    private bool canCount = true;
    private bool finished = false;

    private void Start()
    {
        timer = mainTimer;
    }

    private void Update()
    {
        if(finished == false)
        {
            timer -= Time.deltaTime;
            countdownText.text = timer.ToString("000");
        }
        else if(timer <= 0.0f)
        {
            Debug.Log("Time's up! Reloading Scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (finished == true)
        {
            canCount = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Exit"))
        {
            finishTime = timer;
            finished = true;
            countdownText.color = Color.red;
        }
    }
}
