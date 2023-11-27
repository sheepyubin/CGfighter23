using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBuffer : MonoBehaviour
{
    private List<ActionItem> m_inputBuffer = new List<ActionItem>();
    private bool m_isActionAllowed;

    private void Update()
    {
        CheckInput();
        if (m_isActionAllowed)
        {
            TryBufferedAction();
        }
    }

    private void CheckInput()
    {
        
    }

    private void TryBufferedAction()
    {

    }

    private void PerformAction()
    {

    }
}
