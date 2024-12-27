using SkulWatermelon.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SkulWatermelon.UI
{
    public class ScoreDisplayer : MonoBehaviour
    {
        [SerializeField]
        Text scoreText;


        void Update()
        {
            UpdateScore();
        }
        
        void UpdateScore()
        {
            scoreText.text = StageManager.Instance.GameCycle.Score.Amount.ToString();
        }
    }
}