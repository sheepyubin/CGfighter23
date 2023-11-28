using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private List<Movement> m_availableMoves;

    private PlayerController m_player1;
    private ControlManager m_controlManager;

    private void Awake()
    {
        m_player1 = FindObjectOfType<PlayerController>();
        m_controlManager = FindObjectOfType<ControlManager>();

        m_availableMoves.Sort();
    }

    public bool CanMove(List<KeyCode> pKeyCodes)
    {
        foreach(var movement in m_availableMoves)
        {
            if (movement.isMoveAvailable(pKeyCodes))
            {
                return true;
            }
        }
        return false;
    }

    public void PlayMove(List<KeyCode> pKeyCodes)
    {
        foreach (var movement in m_availableMoves)
        {
            if (movement.isMoveAvailable(pKeyCodes))
            {
                m_player1.PlayerMove(movement.MoveType, movement.ComboPriorty);
                break;
            }
        }
    }
}
