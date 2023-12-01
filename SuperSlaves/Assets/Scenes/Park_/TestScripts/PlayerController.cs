using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator m_animator;
    private ControlManager m_controlManager;
    private int m_currentComboPriorty = 0;

    private void Awake()
    {
        if (m_animator == null)
        {
            m_animator = GetComponent<Animator>();
        }
        if (m_controlManager == null)
        {
            m_controlManager = FindObjectOfType<ControlManager>();
        }
    }

    public void PlayerMove(Moves pMove, int pComboPriorty)
    {
        if (pMove != Moves.None)
        {
            if (pComboPriorty >= m_currentComboPriorty)
            {
                m_currentComboPriorty = pComboPriorty;
                ResetTriggers();
                m_controlManager.ResetCombo();
            }
            else
            {
                return;
            }

            //Set Animation
            switch (pMove)
            {
                case Moves.Punch:
                    m_animator.SetTrigger("Punch");
                    break;
                case Moves.Kick:
                    m_animator.SetTrigger("Kick");
                    break;
                case Moves.Skill:
                    m_animator.SetTrigger("Skill");
                    break;
                default:
                    break;
            }

            m_currentComboPriorty = 0;
        }
    }

    private void ResetTriggers()
    {
        foreach (var parameter in m_animator.parameters)
        {
            m_animator.ResetTrigger(parameter.name);
        }
    }
}
