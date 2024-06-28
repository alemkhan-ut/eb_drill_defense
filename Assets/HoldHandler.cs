using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldHandler : BaseHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private float _targetDuration = 2f; // Желаемая длительность удержания в секундах

    private float _holdDuration; // Текущая длительность удержания
    private bool _isHolding = false; // Флаг, указывающий на удержание

    private Coroutine _holdCoroutine;

    public bool IsHolding { get => _isHolding; }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isHolding = true;

        _holdCoroutine = StartCoroutine(HoldCoroutine());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isHolding = false;

        _holdDuration = 0f; // Сброс длительности удержания
    }

    private IEnumerator HoldCoroutine()
    {
        _holdDuration = 0f;

        while (_isHolding && _holdDuration < _targetDuration)
        {
            _holdDuration += Time.deltaTime;
            yield return null;
        }

        if (_isHolding)
        {
            // Выполняем действия после успешного удержания
            Debug.Log("Hold for " + _targetDuration + " seconds completed!");

            transform.parent.gameObject.SetActive(false);
        }
    }
}
