using MadSnail.EventService;
using UnityEngine;

public class BaseHandler : MonoBehaviour
{
    private MainEventService _eventService;
    public MainEventService EventService => _eventService;

    private void Awake()
    {
        _eventService = FindObjectOfType<MainEventService>();
    }
}