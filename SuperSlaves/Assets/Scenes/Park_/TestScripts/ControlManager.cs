using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class ControlManager : MonoBehaviour
{
    [SerializeField] private float m_comboResetTime = 0.5f;
    [SerializeField] private List<KeyCode> m_pressedKeys;
    [SerializeField] private TextMeshProUGUI m_textForTest;

    private MovementManager m_movementManager;

    private void Awake()
    {
        if(m_movementManager == null)
        {
            m_movementManager = FindObjectOfType<MovementManager>();
        }
    }

    private void Update()
    {
        DetectPressedKey();
        PrintControls();
    }

    public void DetectPressedKey()
    {
        foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                m_pressedKeys.Add(keyCode);

                if (!m_movementManager.CanMove(m_pressedKeys))
                {
                    //이건 코루틴 다 찾아서 하는 게 나을 듯?!
                    StopAllCoroutines();
                }

                StartCoroutine(ResetComboTimer());
            }
        }
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
        m_textForTest.text = "Buffer : ";

        foreach(KeyCode keyCode in m_pressedKeys)
        {
            m_textForTest.text += $"{keyCode} ";
        }
    }
}
