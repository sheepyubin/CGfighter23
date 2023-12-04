using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private ControlManager m_p1;
    [SerializeField] private ControlManager m_p2;

    private void OnMoveP1(InputValue value)
    {
        Vector2 inputVec = value.Get<Vector2>();

        //Left
        if (inputVec.x < 0)
        {
            m_p1.AddKeys(Keys.Left);
            m_p1.transform.Translate(Vector3.left * m_p1.MoveSpeed);
        }
        //Right
        else if (inputVec.x > 0)
        {
            m_p1.AddKeys(Keys.Right);
            m_p1.transform.Translate(Vector3.right * m_p1.MoveSpeed);
        }
        //Up
        else if (inputVec.y > 0)
        {
            m_p1.AddKeys(Keys.Up);
            //근데 점프 여기서해야할듯?
        }
        //Down
        else if (inputVec.y < 0)
        {
            m_p1.AddKeys(Keys.Down);
        }
    }

    private void OnPunchP1()
    {
        m_p1.AddKeys(Keys.Punch);
    }

    private void OnKickP1()
    {
        m_p1.AddKeys(Keys.Kick);
    }

    private void OnGuardP1()
    {
        m_p1.AddKeys(Keys.Guard);
    }

    private void OnMoveP2(InputValue value)
    {
        Vector2 inputVec = value.Get<Vector2>();

        //Left
        if (inputVec.x < 0)
        {
            m_p2.AddKeys(Keys.Left);
            m_p2.transform.Translate(Vector3.left * m_p2.MoveSpeed);
        }
        //Right
        else if (inputVec.x > 0)
        {
            m_p2.AddKeys(Keys.Right);
            m_p2.transform.Translate(Vector3.right * m_p2.MoveSpeed);
        }
        //Up
        else if (inputVec.y > 0)
        {
            m_p2.AddKeys(Keys.Up);
        }
        //Down
        else if (inputVec.y < 0)
        {
            m_p2.AddKeys(Keys.Down);
        }
    }

    private void OnPunchP2()
    {
        m_p2.AddKeys(Keys.Punch);
    }

    private void OnKickP2()
    {
        m_p2.AddKeys(Keys.Kick);
    }

    private void OnGuardP2()
    {
        m_p2.AddKeys(Keys.Guard);
    }
}
