using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null)
                return;

        Instance = this;
    }
    #endregion

    [HideInInspector]
    public GameObject activeBall;

    [HideInInspector]
    public int countToFail = 0;
    [HideInInspector]
    public int countToCatch = 0;

    [Header("UI Elements")]
    [SerializeField] private Text _catchText;
    [SerializeField] private Text _failText;

    public void SwitchCursorStatus(bool cursorStatus)
    {
        Cursor.visible = cursorStatus;
    }

    public void UIUpdate()
    {
        _failText.text = "Fail: " + countToFail;
        _catchText.text = "Catch: " + countToCatch;
    }
}
