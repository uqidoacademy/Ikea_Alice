using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public string HandTag { get { return "HAND";  } }
    public string MouthTag { get { return "MOUTH"; } }

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

    public void Setup()
    {
    }

    #endregion

}
