using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameHitBox : MonoBehaviour
{
    [field : SerializeField] public PlayerLife Player { get; private set; }
    [field : SerializeField] public HitBox Type { get; private set; }
    [field : SerializeField] public float Power { get; private set; }   //방어의 경우 음수, 공격은 양수

    private List<IngameHitBox> hits = new List<IngameHitBox>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitbox = collision.GetComponent<IngameHitBox>();
        if (hitbox != null && hitbox.Player != this.Player)
        {
            if(this.Type == HitBox.Attack)
            {
                hits.Add(hitbox);
            }
        }
    }

    private void FixedUpdate()
    {
        if (hits.Count > 0)
        {
            bool isDefense = false;

            foreach (var hit in hits)
            {
                if (hit.Type == HitBox.Defense)
                {
                    isDefense = true;
                }
            }

            if (!isDefense)
            {
                hits[0].Player.UpdateLife(this.Power);
            }
        }

        hits.Clear();
    }
}

public enum HitBox
{
    Attack,
    Defense,
    Body,
}