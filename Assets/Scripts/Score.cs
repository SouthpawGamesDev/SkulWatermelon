namespace SkulWatermelon.Model
{
    public sealed class Score
    {
        public int Amount { get; private set;}

        public static Score Of(int amount) => new Score(amount);

        Score(int amount)
        {
            this.Amount = amount;
        }
    }
}