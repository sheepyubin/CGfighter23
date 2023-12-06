using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private List<Movement> m_availableMoves;

    private void Awake()
    {
        m_availableMoves.Sort(Compare);
    }

    private int Compare(Movement move1, Movement move2)
    {
        return Comparer<int>.Default.Compare(move2.ComboPriorty, move1.ComboPriorty);
    }

    public bool CanMove(List<Keys> pKeyCodes)
    {
        foreach (var movement in m_availableMoves)
        {
            if (movement.isMoveAvailable(pKeyCodes))
            {
                return true;
            }
        }
        return false;
    }

    public void PlayMove(List<Keys> pKeyCodes, PlayerController pPlayerController)
    {
        foreach (var movement in m_availableMoves)
        {
            if (movement.isMoveAvailable(pKeyCodes))
            {
                pPlayerController.PlayerMove(movement.MoveType, movement.ComboPriorty);
                break;
            }
        }
    }
}
