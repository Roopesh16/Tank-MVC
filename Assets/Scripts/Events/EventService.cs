using Unity.VisualScripting;

public class EventService
{
    private static EventService instance = null;

    public static EventService Instance
    {
        get
        {
            instance ??= new EventService();

            return instance;
        }
    }

    public EventController OnGameOver { get; private set; }

    public EventService()
    {
        OnGameOver = new EventController();
    }
}
