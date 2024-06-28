using Services.EventServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapHandler : BaseHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Tap!");

        transform.parent.gameObject.SetActive(false);

        EventService.Broadcast(new PlayerOnAttackEvent());
    }
}
