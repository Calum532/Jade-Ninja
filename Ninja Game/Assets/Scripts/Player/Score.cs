using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI timeScore;
    public int timeRemaining;
    public int timeBonus;

    public TextMeshProUGUI coinsScore;
    public int coinsCollected = 0;
    public int coinsBonus = 0;

    public TextMeshProUGUI impsScore;
    public int impsKilled = 0;
    public int impsKilledBonus = 0;

    public TextMeshProUGUI pacifistScore;
    public int pacifistBonus = 1000;

    public TextMeshProUGUI deathsPScore;
    public int deaths;
    public int deathsPenalty = 0;

    public TextMeshProUGUI missedPScore;
    public int missed = 0;
    public int missedPenalty = 0;

    public TextMeshProUGUI score;
    public int totalScore = 0;

    void Update()
    {
        totalScore = timeBonus + coinsBonus + impsKilledBonus + pacifistBonus - deathsPenalty - missedPenalty;
        timeScore.text = timeBonus.ToString();
        impsScore.text = impsKilledBonus.ToString();
        pacifistScore.text = pacifistBonus.ToString();
        deathsPScore.text = "-"+deathsPenalty.ToString();
        missedPScore.text = "-"+missedPenalty.ToString();
        score.text = totalScore.ToString();
        calculateTimeBonus();
    }

    public void calculateTimeBonus()
    {
        timeRemaining = Mathf.RoundToInt(Countdown.timer);
        timeBonus = timeRemaining * 10;
    }

    public void coinsCollectedCount()
    {
        //+1 to coins collected
        coinsCollected = coinsCollected + 1;
        calculateCoinsBonus();
    }

    public void calculateCoinsBonus()
    {
        //200 points per coin collected
        coinsBonus = coinsCollected * 300;
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

    public void arrowMissedCount()
    {
        //+1 to missed count
        missed = missed + 1;
        calculateMissedPenalty();
    }

    public void calculateMissedPenalty()
    {
        //-10 points for missing a shot;
        missedPenalty = missed * 10;
    }
}
