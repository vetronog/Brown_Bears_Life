using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : IPlayerView
{    
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerPresenter _presenter;

    public override void EndAnimation()
    {
        _animator.SetTrigger("stop");
    }

    public override void StartAnimation()
    {
        _animator.SetTrigger("start");
    }

    public void SetPresenter(PlayerPresenter newPresenter)
    {
        _presenter = newPresenter;
    }

    void Update()
    {
        transform.position = _presenter.transform.position;
    }
}
