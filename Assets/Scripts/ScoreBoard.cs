using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    [SerializeField] int scorePerHit = 10;
    Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        MakeNewScore();
    }
    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        MakeNewScore();


    }
    public void MakeNewScore()
    {
        scoreText.text = score.ToString();
    }

}
