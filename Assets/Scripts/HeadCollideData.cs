namespace SkulWatermelon.Model
{
    public struct HeadCollisionEventData
    {
        public Head One;
        public Head Two;
        public int NextLevel;

        public HeadCollisionEventData(Head one, Head two, int nextLevel)
        {
            One = one;
            Two = two;
            NextLevel = nextLevel;
        }
    }
}
