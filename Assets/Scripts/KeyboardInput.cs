using System;
using UnityEngine;

namespace SkulWatermelon.Model
{
    [Serializable]
    public sealed class KeyboardInput : IInput 
    {
        public float GetMoveInput()
        {
            if (Input.GetKey(KeyCode.RightArrow))
                return 1;
            if (Input.GetKey(KeyCode.LeftArrow))
                return -1;

            return 0;
        }
        
        public bool GetDropInput()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}
