using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text timeScore;
    public int timeRemaining;
    public int timeBonus;

    public Text coinsScore;
    public int coinsCollected = 0;
    public int coinsBonus = 0;

    public Text impsScore;
    public int impsKilled = 0;
    public int impsKilledBonus = 0;

    public Text pacifistScore;
    public int pacifistBonus = 1000;

    public Text deathsPScore;
    public int deaths = -239;
    public int deathsPenalty = 0;

    public Text score;
    public int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalScore = timeBonus + coinsBonus + impsKilledBonus + pacifistBonus - deathsPenalty;
        timeScore.text = timeBonus.ToString();
        impsScore.text = impsKilledBonus.ToString();
        pacifistScore.text = pacifistBonus.ToString();
        deathsPScore.text = "-"+deathsPenalty.ToString();
        score.text = totalScore.ToString(); 
    }

    public void calculateTimeBonus()
    {
        timeRemaining = Mathf.RoundToInt(Countdown.finishTime);
        timeBonus = timeRemaining * 10;
    }

    public void coinsCollectedCount()
    {
        //+1 to coins collected
        coinsCollected = coinsCollected++;
        calculateCoinsBonus();
    }

    public void calculateCoinsBonus()
    {
        //200 points per coin collected
        coinsBonus = coinsCollected * 200;
    }

    public void impsKilledCount()
    {
        //+1 to imps killed
        impsKilled = impsKilled + 1;
        pacifistBonus = 0;
        calculateImpsKilledBonus();
    }

    public void calculateImpsKilledBonus()
    {
        //100 points per Imp Kill
        impsKilledBonus = impsKilled * 100;
    }

    public void playerDeathCount()
    {
        //+1 to death count
        deaths = deaths + 1;
        calculateDeathsPenalty();
    }

    public void calculateDeathsPenalty()
    {
        //-200 points per Player death
        deathsPenalty = deaths * 200;
    }
}
