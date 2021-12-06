public class RandomService : IRandomNumberService
{
    private int _randomNumber;
    public RandomService()
    {
        _randomNumber = new Random().Next(1, 10000);
    }

    public int GiveNumber()
    {
        return _randomNumber;
    }
}