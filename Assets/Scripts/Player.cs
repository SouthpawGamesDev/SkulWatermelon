// using System;
// using UnityEngine;
//
// namespace SkulWatermelon.Model
// {
//     [Serializable]
//     public class Player
//     {
//         IInput input;
//         [SerializeField]
//         HeadDropper headDropper;
//
//         public HeadDropper HeadDropper { get { return headDropper; } }
//
//         public Player(IInput input)
//         {  
//             this.input = input;
//             headDropper = new HeadDropper();
//         }
//
//         public void Update()
//         {
//             float moveValue = input.GetMoveInput();
//             headDropper.Move(moveValue);
//
//             if (input.GetDropInput())
//                 headDropper.Drop();
//         }
//     }
// }
