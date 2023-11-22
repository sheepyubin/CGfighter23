using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ready_Select : MonoBehaviour
{
    [SerializeField] bool drowGizmo;            //기즈모 드로우 유/무
    [SerializeField] GameObject[] player;       //플레이어 오브젝트
    [SerializeField] GameObject aniBox;         //애니메이션용 박스
    [SerializeField] GameObject randomBox;      //랜덤박스(젤 큰거)
    [SerializeField] GameObject question;       //물음표
}
