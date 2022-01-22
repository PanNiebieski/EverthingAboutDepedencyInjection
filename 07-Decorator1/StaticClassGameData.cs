public class StaticClassGameData : IGameData
{
    private Random _random = new Random();

    public int GetCountOfGames()
    {
        return _random.Next
            (1, 1000);
    }
}

