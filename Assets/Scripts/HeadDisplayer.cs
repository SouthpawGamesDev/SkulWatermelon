using System;
using SkulWatermelon.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using SkulWatermelon.Core;

namespace SkulWatermelon.UI
{
    public class HeadDisplayer : MonoBehaviour
    {
        [SerializeField]
        Image nextHead;
        [SerializeField]
        SpriteRenderer currentHeadRenderer;
        
        [SerializeField]
        Player player;

        HeadDropper headDropper;
        
        void Start()
        {
            headDropper = player.HeadDropper; 
            headDropper.HeadDropped += Change;
            Change();
        }

        void OnDestroy()
        {
            headDropper.HeadDropped -= Change;
        }

        void Change()
        {
            HeadDropper.HeadData currentData = headDropper.CurrentData;
            HeadDropper.HeadData nextData = headDropper.NextData;
            
            var currentLevel = currentData.Level;
            var headPrefab = GameManager.Instance.StageManager.Setting.GetHeadPrefab(currentLevel);

            currentHeadRenderer.sprite = headPrefab.GetSprite();
            currentHeadRenderer.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, currentData.Rotation));
            currentHeadRenderer.transform.localScale = headPrefab.transform.localScale;

            var nextLevel = nextData.Level;
            var nextSprite = GameManager.Instance.StageManager.Setting.GetHeadPrefab(nextLevel).GetSprite();
            nextHead.sprite = nextSprite;
        }
    }
}
