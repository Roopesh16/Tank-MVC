using Unity.VisualScripting;

public class EventManager
{
    private static EventManager instance = null;

    public static EventManager Instance
    {
        get
        {
            instance ??= new EventManager();

            return instance;
        }
    }

    public EventController OnGameOver { get; private set; }

    public EventManager()
    {
        OnGameOver = new EventController();
    }
}
