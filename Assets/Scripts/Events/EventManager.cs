using Unity.VisualScripting;

public class EventManager
{
    public EventController OnGameOver { get; private set; }
    public EventController OnNewWave { get; private set; }

    public EventManager()
    {
        OnGameOver = new EventController();
        OnNewWave = new EventController();
    }
}
