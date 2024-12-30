using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkulWatermelon.Model
{
    public sealed class Player : MonoBehaviour
    {
        [Serializable]
        public class HeadDropperSetting
        {
            [SerializeField] internal Transform transform;
            [SerializeField] internal Vector2 range;
            [SerializeField] internal float speed;
        }
        
        [SerializeReference, SubclassSelector]
        public IInput Input;

        [SerializeField]
        HeadDropperSetting setting;
        
        HeadDropper headDropper;
        public HeadDropper HeadDropper => headDropper;

        public void Awake()
        {
            headDropper = new HeadDropper(setting);
        }

        void Update()
        {
            headDropper.Move(Input.GetMoveInput());
            if(Input.GetDropInput())
                headDropper.Drop();
        }
    }
}
