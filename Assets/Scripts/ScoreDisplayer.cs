using SkulWatermelon.Model;
using System.Collections;
using System.Collections.Generic;
using SkulWatermelon.Core;
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
            scoreText.text = GameManager.Instance.StageManager.Score.Amount.ToString();
        }
    }
}