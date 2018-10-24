using DG.Tweening;
using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStateMachine: MonoBehaviour
{
    public float AnimationTimer = 2.0f;
    // Scale points
    public float ScaleBig ;
    public float ScaledMedium ;
    public float ScaledSmall ;

    Sequence movementSequance;

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
                DisableFPS();
                ScalePlayerBy(ScaledSmall);
                
                break;

            case PlayerState.medium:
                DisableFPS();
                ScalePlayerBy(ScaledMedium);
                
                break;

            case PlayerState.big:
                DisableFPS();
                ScalePlayerBy(ScaleBig);
                break;
        }
    }

    #region OnScale
    private void ScalePlayerBy(float newScale)
    {
        movementSequance = DOTween.Sequence();
        movementSequance.Append(transform.GetChild(0).DOScale(newScale, AnimationTimer));
        movementSequance.OnComplete(()=> {EnableFPS();});
       
    }

    private void DisableFPS()
    {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<FirstPersonController>().enabled = false;
    }


    private void EnableFPS()
    {
        GetComponent<CharacterController>().enabled = true;
        GetComponent<FirstPersonController>().enabled = true;
    }

    #endregion

    public void SetUp()
    {
        EventManager.PreBecomeBigger += OnPlayerBig;
        EventManager.PreBecomeSmaller += OnPlayerSmall;
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.OnPlayerBig();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.OnPlayerSmall();
        }
    }

    private void Start() {
        SetUp();
    }

    #endregion

}

public enum PlayerState
{
    small = 0,
    medium = 1,
    big = 2,
   
}
