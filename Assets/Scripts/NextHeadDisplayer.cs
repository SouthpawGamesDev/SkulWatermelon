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
    public class NextHeadDisplayer : MonoBehaviour
    {
        [SerializeField]
        Image nextHead;

        [SerializeField]
        SpriteRenderer currentHeadRenderer;

        [SerializeField]
        StageManager stageManager;

        void Start()
        {
            Change();
            stageManager.GameCycle.HeadDropper.HeadDropped += Change;
        }

        void OnDestroy()
        {
            stageManager.GameCycle.HeadDropper.HeadDropped -= Change;
        }

        void Change()
        {
            var headGenerator = stageManager.GameCycle.HeadGenerator;

            var currentLevel = headGenerator.current;
            var headPrefab = GameManager.Instance.GameResourceManager.GetHeadPrefab(currentLevel);

            currentHeadRenderer.sprite = headPrefab.GetSprite();
            currentHeadRenderer.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, headGenerator.currentRotation));
            currentHeadRenderer.transform.localScale = headPrefab.transform.localScale;
                
            var nextLevel = headGenerator.next;
            var nextSprite = GameManager.Instance.GameResourceManager.GetHeadPrefab(nextLevel).GetSprite();
            nextHead.sprite = nextSprite;
        }
    }
}