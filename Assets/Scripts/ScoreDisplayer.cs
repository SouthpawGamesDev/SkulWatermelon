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
        
        void Start()
        {
            //Evolution.OnEvolution += Change;
        }

        void Change()
        {
            //scoreText.text = Player.Instance.score.Amount.ToString();
        }
    }
}