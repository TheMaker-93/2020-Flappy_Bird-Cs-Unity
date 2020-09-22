using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private OnScoreChangeEvent OnScoreChanged;

    [SerializeField] private CanvasedText scoreText;

    private void Awake()
    {
        if (OnScoreChanged == null)
            OnScoreChanged = new OnScoreChangeEvent();
    }

    private void Start()
    {
        LoadScore();
        scoreText.UpdateText(Score);
    }

    public int Score
    {
        get
        {
            return score;
        }
        private set
        {
            score = value;
        }
    }

   

    public void ModifyScore(int _deltaAmount = 1)
    {
        Debug.Log("Increasing Score");

        Score += _deltaAmount;

        // SaveScore();
        scoreText.UpdateText(score);
    }

    public void SaveScore()
    {
        CrossSceneData.Score = score;
    }
    private void LoadScore()
    {
        score = CrossSceneData.Score;
    }

}


[System.Serializable]
public class OnScoreChangeEvent : UnityEvent<int>
{

}