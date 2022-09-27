using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen instance;

    public Text totalPointsText;
    public Text hitScoreText;
    public Text hitRateText;

    int score = 0;
    double hit = 0;
    double miss = 0;
    double hitRate = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        totalPointsText.text = score.ToString() + " " + " POINTS";
        hitScoreText.text = "Hit Score:" + " " + hit.ToString();
        hitRateText.text = "Hit Rate:" + " " + hitRate.ToString() + "%";
    }

    public void IncreaseScore() 
    {
        score += 1;
        hit += 1;
        hitScoreText.text = "Hit Score:" + " " + hit.ToString();
        totalPointsText.text = score.ToString() + " " + "POINTS";
    }

    public void DecreaseScore()
    {
        score -= 1;
        miss += 1;
        totalPointsText.text = score.ToString() + " " + "POINTS";
    }

    public void CalHitRate()
    {
        hitRate = hit / (hit + miss)*100;
        hitRateText.text = "Hit Rate:" + " " + hitRate.ToString("f2") + "%";
    }
    
    public int getScore()
    {
        if(score <= 0)
        {
            score = 0;
            return 0;
        }
        else 
        {
            return score;
        }
    }
}
