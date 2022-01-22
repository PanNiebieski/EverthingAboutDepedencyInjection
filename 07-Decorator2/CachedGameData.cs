public class CachedGameData : IGameData
{
    private readonly IGameData _repository;
    private readonly GamesCacheSettings _settings;

    public CachedGameData(IGameData repository,
        GamesCacheSettings settings)
    {
        _repository = repository;
        _settings = settings;
    }
    private int _count;
    public int GetCountOfGames()
    {
        if (_settings.Minutes != DateTime.Now.Minute)
        {
            _count = _repository.GetCountOfGames();
            _settings.Minutes = DateTime.Now.Minute;
        }

        return _count;
    }
}

