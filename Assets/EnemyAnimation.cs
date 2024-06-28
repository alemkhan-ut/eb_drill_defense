using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MadSnail.EventService;
using Services.EventServices;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private MainEventService _eventService;

    private Transform _transform;
    private Sequence _attackedSequence;

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

    public void PlayerOnAttackEventHandler(PlayerOnAttackEvent attackEvent)
    {
        _attackedSequence?.Kill();

        _attackedSequence = DOTween.Sequence();

        _attackedSequence.Append(_transform.DORotate(new Vector3(0, 0, Random.Range(0, 2) == 0 ? 5 : -5), 0.15f));
        _attackedSequence.Append(_transform.DORotate(new Vector3(0, 0, 0), 0.1f));

        _attackedSequence.Play();
    }
}
