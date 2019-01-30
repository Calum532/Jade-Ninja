using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public static float finishTime;
    private bool finished;
    private float t;

    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(finished == false)
        {
            t = Time.time - startTime;
            //string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("000");
            timerText.text = seconds;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Exit"))
        {
            finishTime = t;
            finished = true;
            timerText.color = Color.red;
        }
    }
}
