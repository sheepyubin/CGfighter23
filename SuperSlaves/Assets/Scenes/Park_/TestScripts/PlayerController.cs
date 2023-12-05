using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator m_animator;
    private ControlManager m_controlManager;
    private Rigidbody2D m_rigid;
    private int m_currentComboPriorty = 0;
    private bool m_isOnGround = false;

    private void Awake()
    {
        if (m_animator == null)
        {
            m_animator = this.GetComponent<Animator>();
        }
        if (m_controlManager == null)
        {
            m_controlManager = this.GetComponent<ControlManager>();
        }
        if(m_rigid == null)
        {
            m_rigid = this.GetComponent<Rigidbody2D>();
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
                case Moves.Jump:
                    m_animator.SetTrigger("Jump");
                    Jump();
                    break;
                case Moves.JumpingKick:
                    m_animator.SetTrigger("JumpingKick");
                    Jump();
                    break;

                case Moves.Punch:
                    m_animator.SetTrigger("Punch");
                    break;
                case Moves.Kick:
                    m_animator.SetTrigger("Kick");
                    break;
                case Moves.Guard:
                    m_animator.SetTrigger("Guard");
                    break;

                case Moves.Bend:
                    m_animator.SetTrigger("Bend");
                    break;
                case Moves.BendedPunch:
                    m_animator.SetTrigger("BendedPunch");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            m_isOnGround = true;
        }
    }

    public void Jump()
    {
        if (m_isOnGround)
        {
            m_rigid.AddForce(Vector3.up * m_controlManager.JumpPower, ForceMode2D.Impulse);
            m_isOnGround = false;
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
