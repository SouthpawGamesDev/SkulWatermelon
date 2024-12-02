using SkulWatermelon.Model;
namespace SkulWatermelon.Core
{
    public interface IPayload
    {
        
    }
    
    public class A : IPayload
    {
        
    }
    
    public class CollideData : IPayload
    {
        public Head headOne;
        public Head headTwo;
        public int nextLevel;
    }
}
