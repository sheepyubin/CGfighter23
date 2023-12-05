using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float m_maxLife;
    [SerializeField] private float m_currentLife;
    [SerializeField] private TextMeshProUGUI m_lifeText;

    private PlayerController m_playerController;

    private void Awake()
    {
        if(m_playerController == null)
        {
            m_playerController = this.GetComponent<PlayerController>();
        }

        m_currentLife = m_maxLife;
        PrintLife();
    }

    public void UpdateLife(float value)
    {
        m_currentLife -= value;
        PrintLife();
    }

    private void PrintLife()
    {
        m_lifeText.text = $"{m_currentLife} / {m_maxLife}";
    }
}
