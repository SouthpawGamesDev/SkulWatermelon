using UnityEngine;
namespace SkulWatermelon.Model
{
    
    
    public class HeadGenerator
    {
        Head headPrefab;
        int current;
        int next;
        
        public HeadGenerator(Head headPrefab)
        {
            this.headPrefab = headPrefab;
            current = Random.Range(0, 4);
            next = Random.Range(0, 4);
        }
        
        public Head GetHead()
        {
            Head currentHead = GameObject.Instantiate(headPrefab);
            currentHead.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,Random.Range(-180f,180f)));
            currentHead.Hold();
            currentHead.SetLevel(current);

            current = next;
            next = Random.Range(0, 4);

            return currentHead;
        }
    }
}
