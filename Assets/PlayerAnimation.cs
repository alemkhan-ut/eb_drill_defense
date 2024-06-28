using System;
using DG.Tweening;
using MadSnail.EventService;
using Services.EventServices;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private MainEventService _eventService;

    private Transform _transform;
    private Sequence _attackSequence;

    private void Awake()
    {
        _transform = transform;
        _eventService = FindObjectOfType<MainEventService>();
    }

    private void OnEnable()
    {
        _eventService.AddListener<PlayerOnAttackEvent>(PlayerOnAttackEventHandler);
    }

    private void OnDisable()
    {
        _eventService.RemoveListener<PlayerOnAttackEvent>(PlayerOnAttackEventHandler);
    }

    public void TakeDamage()
    {
        throw new NotImplementedException();
    }

    public void PlayerOnAttackEventHandler(PlayerOnAttackEvent attackEvent)
    {
        _attackSequence?.Kill();

        _attackSequence = DOTween.Sequence();

        _attackSequence.Append(_transform.DORotate(new Vector3(0, 0, 13), 0.15f));
        _attackSequence.Append(_transform.DORotate(new Vector3(0, 0, 0), 0.1f));

        _attackSequence.Play();
    }
}
