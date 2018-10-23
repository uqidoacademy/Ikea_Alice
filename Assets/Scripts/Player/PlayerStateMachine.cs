using DG.Tweening;
using System;
using UnityEngine;

public class PlayerStateMachine: MonoBehaviour
{
    public float AnimationTimer = 2.0f;

    // Scale points
    public float ScaledBigHeight = 20;
    public float ScaledMediumHeight = 10;
    public float ScaledSmallHeight = 1;

    #region Properties
    private PlayerState _currentState = PlayerState.medium;


    public PlayerState CurrentState
    {
        get { return _currentState; }
        set
        {
            if (_currentState != value)
            {
                PlayerState oldState = _currentState;
                _currentState = value;
                StateChanged();
            }
            if (_currentState == value)
            {

            }
        }
    }

    #endregion
    /// <summary>
    /// Chiamata quando cambio stato
    /// </summary>
    private void StateChanged()
    {
        
        switch (CurrentState)
        {
            case PlayerState.small:
                ScalePlayerBy(ScaledSmallHeight);
                break;

            case PlayerState.medium:
                ScalePlayerBy(ScaledMediumHeight);
                break;

            case PlayerState.big:
                ScalePlayerBy(ScaledBigHeight);

                break;
        }
    }

    private void ScalePlayerBy(float newHeight)
    {
        transform.DOMove(new Vector3(transform.position.x, newHeight, transform.position.z), AnimationTimer);
    }


    public void SetUp()
    {
        EventManager.PostBecomeBigger += OnPlayerBig;
        EventManager.PostBecomeSmaller += OnPlayerSmall;
    }

    /// <summary>
    /// Funzione che ingrandisce lo stato
    /// </summary>
    private void OnPlayerBig()
    {
        if (CurrentState == PlayerState.small)
            CurrentState = PlayerState.medium;

        else if (CurrentState == PlayerState.medium)
            CurrentState = PlayerState.big;

    }

    /// <summary>
    /// Funzione che rimpicciolisce le cose
    /// </summary>
    private void OnPlayerSmall()
    {
        if (CurrentState == PlayerState.big)
            CurrentState = PlayerState.medium;

        else if (CurrentState == PlayerState.medium)
            CurrentState = PlayerState.small;

    }

    #region Lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.OnPlayerBig();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            this.OnPlayerSmall();
        }
    }

    #endregion

}

public enum PlayerState
{
    small = 0,
    medium = 1,
    big = 2,
   
}
