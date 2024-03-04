using Unity.VisualScripting;

public class EventManager
{
    private static EventManager instance = null;

    public EventController OnGameOver { get; private set; }
    public EventController OnNewWave { get; private set; }

    public EventManager()
    {
        OnGameOver = new EventController();
        OnNewWave = new EventController();
    }
}
