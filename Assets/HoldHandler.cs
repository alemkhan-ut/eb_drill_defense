using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldHandler : BaseHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private float _targetDuration = 2f; // �������� ������������ ��������� � ��������

    private float _holdDuration; // ������� ������������ ���������
    private bool _isHolding = false; // ����, ����������� �� ���������

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

        _holdDuration = 0f; // ����� ������������ ���������
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
            // ��������� �������� ����� ��������� ���������
            Debug.Log("Hold for " + _targetDuration + " seconds completed!");

            transform.parent.gameObject.SetActive(false);
        }
    }
}
