using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float MaxLife;
    [SerializeField] private float CurrentLife;
    //[SerializeField] private TextMeshProUGUI m_lifeText;
    [SerializeField] private Slider m_lifeSlider;
    private IngameManager m_ingameManager;

    public float LifeRate { get { return CurrentLife / MaxLife; } }
    private PlayerController m_playerController;

    private void Awake()
    {
        if(m_playerController == null)
        {
            m_playerController = this.GetComponent<PlayerController>();
        }
        if(m_ingameManager == null)
        {
            m_ingameManager = FindObjectOfType<IngameManager>();
        }

        CurrentLife = MaxLife;
        PrintLife();
    }

    public void UpdateLife(float value)
    {
        CurrentLife -= value;
        if (CurrentLife <= 0)
        {
            m_ingameManager.GameOver();
        }
        PrintLife();
    }

    private void PrintLife()
    {
        //m_lifeText.text = $"{m_currentLife} / {m_maxLife}";
        m_lifeSlider.value = CurrentLife;
    }
}
