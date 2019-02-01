using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownTMP;
    [SerializeField] private float mainTimer;

    public static float timer;
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
            countdownTMP.text = timer.ToString("000");
        }
        else if (finished == true)
        {
            canCount = false;
        }

        if (timer <= 0f)
        {
            Debug.Log("Time's up! Reloading Scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Exit"))
        {
            finished = true;
            countdownTMP.faceColor = Color.red;
        }
    }
}
