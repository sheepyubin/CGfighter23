using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_player1;
    [SerializeField] private GameObject m_player2;

    public float Distance;
    public int Sign { get; private set; }

    private void Awake()
    {
        Sign = 1;
    }

    private void Update()
    {
        Distance = m_player2.transform.position.x - m_player1.transform.position.x;
        if (Distance * Sign < 0)
        {
            Sign *= -1;
            var scaleP1 = m_player1.transform.localScale;
            scaleP1.x *= -1;
            m_player1.transform.localScale = scaleP1;

            //var xPos2 = m_player2.GetComponent<SpriteRenderer>().flipX;
            //m_player2.GetComponent<SpriteRenderer>().flipX = !xPos2;

            var scaleP2 = m_player2.transform.localScale;
            scaleP2.x *= -1;
            m_player2.transform.localScale = scaleP2;
        }
    }
}
