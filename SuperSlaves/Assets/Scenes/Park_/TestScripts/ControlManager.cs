using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using TMPro;
using System;
using Unity.VisualScripting;

public class ControlManager : MonoBehaviour
{
    [SerializeField] private float m_comboResetTime = 0.5f;
    [SerializeField] private List<Keys> m_pressedKeys;
    [SerializeField] private TextMeshProUGUI m_textForTest;
    [SerializeField] private String m_playerName;

    [SerializeField] private JoyStickController m_joyStickController;

    private MovementManager m_movementManager;

    private void Awake()
    {
        if (m_movementManager == null)
        {
            m_movementManager = FindObjectOfType<MovementManager>();
        }
    }

    private void Update()
    {
        //DetectPressedKey();
        //m_joyStickController.JoystickUpdate();
        PrintControls();
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputVec = value.Get<Vector2>();

        //m_textStick.text = $"({inputVec.x},{inputVec.y})";  //근데 그냥 여기 들어오는 값부터가 잘못 들어오는데요??

        //Up
        if(inputVec.y > 0)
        {
            m_pressedKeys.Add(Keys.Up);
        }
        //Down
        else if (inputVec.y < 0)
        {
            m_pressedKeys.Add(Keys.Down);
        }
        //Left
        else if(inputVec.x < 0)
        {
            m_pressedKeys.Add(Keys.Left);
        }
        //Right
        else if(inputVec.x > 0)
        {
            m_pressedKeys.Add(Keys.Right);
        }

        SetComboTimer();
    }

    private void OnPunch()
    {
        m_pressedKeys.Add(Keys.Punch);
        SetComboTimer();
    }

    private void OnKick()
    {
        m_pressedKeys.Add(Keys.Kick);
        SetComboTimer();
    }

    private void SetComboTimer()
    {
        if (!m_movementManager.CanMove(m_pressedKeys))
        {
            //이건 코루틴 다 찾아서 하는 게 나을 듯?!
            StopAllCoroutines();
        }

        StartCoroutine(ResetComboTimer());
    }

    public void ResetCombo()
    {
        m_pressedKeys.Clear();
    }

    private IEnumerator ResetComboTimer()
    {
        yield return new WaitForSeconds(m_comboResetTime);

        m_movementManager.PlayMove(m_pressedKeys);
        m_pressedKeys.Clear();
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
