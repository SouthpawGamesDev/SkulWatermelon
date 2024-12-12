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
    public class HeadDisplayer
    {
        Image nextHead;
        SpriteRenderer currentHeadRenderer;
        HeadDropper headDropper;

        public HeadDisplayer(Image nextHead, SpriteRenderer currentHeadRenderer, HeadDropper headDropper)
        {
            this.nextHead = nextHead;
            this.currentHeadRenderer = currentHeadRenderer;
            this.headDropper = headDropper;

            Change();
            headDropper.HeadDropped += Change;
        }

        void OnDestroy()
        {
            headDropper.HeadDropped -= Change;
        }

        void Change()
        {
            var currentLevel = headDropper.currentLevel;
            var headPrefab = GameManager.Instance.GameResourceManager.GetHeadPrefab(currentLevel);

            currentHeadRenderer.sprite = headPrefab.GetSprite();
            currentHeadRenderer.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, headDropper.currentRotation));
            currentHeadRenderer.transform.localScale = headPrefab.transform.localScale;

            var nextLevel = headDropper.nextLevel;
            var nextSprite = GameManager.Instance.GameResourceManager.GetHeadPrefab(nextLevel).GetSprite();
            nextHead.sprite = nextSprite;
        }
    }
}
