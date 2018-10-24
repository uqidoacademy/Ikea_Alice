using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public string HandTag { get { return "HAND";  } }
    public string MouthTag { get { return "MOUTH"; } }
    public Canvas endScreen;
    public float fadeDuration = 3.0f;
    public Animation fadeOutAnimation;
    private CanvasGroup endScreenGroup;

    #region Singleton

    private static MainManager _instance;
    public static MainManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    #region Methods

    private void Start()
    {
        RegisterToEvents();
        SetupEndExperience();
    }


    private void RegisterToEvents()
    {
        // register to the needed events of event manager
        EventManager.PostOpenDoor += EndExperience;
    }

    #endregion

    #region End Experience
    private void SetupEndExperience()
    {
        endScreenGroup = endScreen.GetComponent<CanvasGroup>();
        endScreenGroup.alpha = 0.0f;
    }

    private void EndExperience()
    {
        Debug.Log("End experience");
        FadeOutCamera();
    }

    private void FadeOutCamera() {
        StartCoroutine(Animations.FadeCanvas(endScreenGroup, 0.0f, 1.0f, fadeDuration));
    }
    #endregion

}
