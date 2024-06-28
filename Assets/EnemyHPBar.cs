using System;
using DG.Tweening;
using MadSnail.EventService;
using Services.EventServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    [SerializeField]
    private Image _fillImage;
    [SerializeField]
    private Image _fillTraceImage;

    private MainEventService _eventService;

    private void Awake()
    {
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

    private void PlayerOnAttackEventHandler(PlayerOnAttackEvent @event)
    {
        _fillImage.fillAmount -= 0.05f;

        _fillTraceImage.DOFillAmount(_fillImage.fillAmount, 0.25f);

        if (_fillImage.fillAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
