using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using TMPro;
using System;
using Unity.VisualScripting;

public class ControlManager : MonoBehaviour
{
    [SerializeField] private float m_comboResetTime = 0.35f;
    [SerializeField] private List<Keys> m_pressedKeys;
    [SerializeField] private TextMeshProUGUI m_textForTest;
    [SerializeField] private String m_playerName;

    [field: SerializeField] public float JumpPower { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }

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

    public void SetComboTimer()
    {
        if ((!m_movementManager.CanMove(m_pressedKeys) && m_timer != null) || m_timer != null)
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
