using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "New Move")]
public class Movement : ScriptableObject
{
    [SerializeField] private List<KeyCode> m_moveKeyCodes;
    
    [field: SerializeField] public int ComboPriorty { get; private set; }
    [field: SerializeField] public Moves MoveType{ get; set; }

    public bool isMoveAvailable(List<KeyCode> pPlayerKeyCodes)
    {
        int comboIndex = 0;

        for(int i = 0; i < pPlayerKeyCodes.Count; i++)
        {
            if (pPlayerKeyCodes[i] == m_moveKeyCodes[i])
            {
                comboIndex++;
                if(comboIndex == m_moveKeyCodes.Count)
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

    public int GetMoveComboCount()
    {
        return m_moveKeyCodes.Count;
    }
}

public enum Moves
{
    None,
    Punch,
    Kick,
    Skill,
}
