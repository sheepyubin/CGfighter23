using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameHitBox : MonoBehaviour
{
    [field : SerializeField] public PlayerLife Player { get; private set; }
    [field : SerializeField] public HitBox Type { get; private set; }
    [field : SerializeField] public float Power { get; private set; }   //방어의 경우 음수, 공격은 양수

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitbox = collision.GetComponent<IngameHitBox>();
        if (hitbox != null && hitbox.Player != this.Player)
        {
            if(this.Type == HitBox.Attack)
            {
                if(hitbox.Type == HitBox.Attack)
                {
                    //그냥 맞은 걸로 침... 둘 다.
                    hitbox.Player.UpdateLife(this.Power);
                }
                else
                {
                    //Power 서로 더해서 공격맞은 걸로 침
                    hitbox.Player.UpdateLife(Mathf.Clamp(this.Power + hitbox.Power, 0, this.Power));
                }
            }
        }
    }
}

public enum HitBox
{
    Attack,
    Defense,
    Body,
}