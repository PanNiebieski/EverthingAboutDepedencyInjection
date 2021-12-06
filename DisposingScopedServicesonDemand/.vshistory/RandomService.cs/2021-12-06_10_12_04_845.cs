public class ComputationService : IComputationService
{
    private int _randomNumber;
    public ComputationService()
    {
        _randomNumber = new Random().Next(1, 10000);
    }

    public int GiveNumber()
    {
        return _randomNumber;
    }
}