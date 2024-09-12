using UnityEngine;

namespace SkulWatermelon.Model
{
    public class Head : MonoBehaviour
    {
        [SerializeField]
        new Rigidbody2D rigidbody2D;
        
        int level = 0;

        public void Hold() => rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        public void Unhold() => rigidbody2D.constraints = RigidbodyConstraints2D.None;

        public void SetLevel(int level)
        {
            
        }
    }
}
