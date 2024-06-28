using Services.EventServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeHandler : BaseHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private bool _isLeftHandler;

    private Vector2 initialTouchPosition;
    private Vector2 finalTouchPosition;
    private bool isSwiping = false;
    private float swipeThreshold = 50f; // Минимальное расстояние для считывания свайпа

    public void OnPointerDown(PointerEventData eventData)
    {
        initialTouchPosition = eventData.position;
        isSwiping = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        finalTouchPosition = eventData.position;
        isSwiping = false;

        // Определяем направление свайпа
        float swipeMagnitude = (finalTouchPosition - initialTouchPosition).magnitude;

        if (swipeMagnitude >= swipeThreshold)
        {
            float swipeDirectionX = finalTouchPosition.x - initialTouchPosition.x;
            if (Mathf.Abs(swipeDirectionX) > swipeThreshold)
            {
                if (swipeDirectionX > 0)
                {
                    if (!_isLeftHandler)
                    {
                        Debug.Log("On Right Swipe!");

                        transform.parent.gameObject.SetActive(false);

                        EventService.Broadcast(new PlayerOnAttackEvent());
                    }
                }
                else
                {
                    if (_isLeftHandler)
                    {
                        Debug.Log("On Left Swipe!");

                        transform.parent.gameObject.SetActive(false);

                        EventService.Broadcast(new PlayerOnAttackEvent());
                    }
                }
            }
        }

    }
}
