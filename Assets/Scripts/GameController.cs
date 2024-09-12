using System;
using UnityEngine;

namespace SkulWatermelon.Model
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        HeadDropper headDropper;
        
        [SerializeReference,SubclassSelector]
        IInput input;
        
        void Start()
        {
            
        }

        void Update()
        {
            float moveValue = input.GetMoveInput();
            headDropper.Move(moveValue);
            
            if(input.GetDropInput())
                headDropper.Drop();
        }
    }
}
