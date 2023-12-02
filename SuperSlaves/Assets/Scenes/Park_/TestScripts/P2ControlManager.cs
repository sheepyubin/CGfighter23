using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class P2ControlManager : MonoBehaviour, IControlManager
{
    [SerializeField] private float m_comboResetTime = 0.35f;
    [SerializeField] private List<Keys> m_pressedKeys;
    [SerializeField] private TextMeshProUGUI m_textForTest;
    [SerializeField] private String m_playerName;

    private MovementManager m_movementManager;
    private PlayerController m_playerController;

    private Coroutine m_timer;

    private void Awake()
    {
        if (m_movementManager == null)
        {
            m_movementManager = FindObjectOfType<MovementManager>();
        }
        if (m_playerController == null)
        {
            m_playerController = this.GetComponent<PlayerController>();
        }

        m_textForTest = GameObject.Find("BufferTest (1)").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        PrintControls();
    }

    public void AddKeys(Keys key)
    {
        m_pressedKeys.Add(key);
        SetComboTimer();
    }

    //private void OnMoveP2(InputValue value)
    //{
    //    Debug.Log(this.gameObject.name);

    //    Vector2 inputVec = value.Get<Vector2>();

    //    //Left
    //    if (inputVec.x < 0)
    //    {
    //        m_pressedKeys.Add(Keys.Left);
    //    }
    //    //Right
    //    else if (inputVec.x > 0)
    //    {
    //        m_pressedKeys.Add(Keys.Right);
    //    }
    //    //Up
    //    else if (inputVec.y > 0)
    //    {
    //        m_pressedKeys.Add(Keys.Up);
    //    }
    //    //Down
    //    else if (inputVec.y < 0)
    //    {
    //        m_pressedKeys.Add(Keys.Down);
    //    }

    //    SetComboTimer();
    //}

    //private void OnPunchP2()
    //{
    //    m_pressedKeys.Add(Keys.Punch);
    //    SetComboTimer();
    //}

    //private void OnKickP2()
    //{
    //    m_pressedKeys.Add(Keys.Kick);
    //    SetComboTimer();
    //}

    //private void OnGuard()

    public void SetComboTimer()
    {
        if (!m_movementManager.CanMove(m_pressedKeys) && m_timer != null)
        {
            StopCoroutine(m_timer);
        }

        m_timer = StartCoroutine(ResetComboTimer());
    }

    public void ResetCombo()
    {
        this.m_pressedKeys.Clear();
    }

    public IEnumerator ResetComboTimer()
    {
        yield return new WaitForSeconds(m_comboResetTime);

        m_movementManager.PlayMove(m_pressedKeys, m_playerController);
        m_pressedKeys.Clear();

        yield break;
    }

    public void PrintControls()
    {
        m_textForTest.text = $"{m_playerName} Buffer : ";

        foreach (Keys keyCode in m_pressedKeys)
        {
            m_textForTest.text += $"{keyCode} ";
        }
    }
}
