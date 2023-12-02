using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[CreateAssetMenu(fileName = "New Move", menuName = "New Move")]
public class Movement : ScriptableObject
{
    [SerializeField] private List<Keys> m_moveKeyCodes;

    [field: SerializeField] public int ComboPriorty { get; private set; }
    [field: SerializeField] public Moves MoveType { get; set; }

    public bool isMoveAvailable(List<Keys> pPlayerKeyCodes)
    {
        int comboIndex = 0;

        for (int i = 0; i < m_moveKeyCodes.Count && i < pPlayerKeyCodes.Count; i++)
        {
            if (pPlayerKeyCodes.Count <= i || m_moveKeyCodes.Count <= i)
            {
                break;
            }

            if (pPlayerKeyCodes[i] == m_moveKeyCodes[i])
            {
                comboIndex++;
                if (comboIndex == m_moveKeyCodes.Count)
                {
                    return true;
                }
            }
            else
            {
                comboIndex = 0;
            }
        }
        return false;
    }
}

public enum Moves
{
    None,
    Punch,
    Kick,
    Skill,
}

public enum Keys
{
    None,
    Up,
    Down,
    Left,
    Right,
    Punch,
    Kick,
}
