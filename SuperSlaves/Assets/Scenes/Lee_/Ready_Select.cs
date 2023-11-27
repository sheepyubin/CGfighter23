using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ready_Select : MonoBehaviour
{
    [SerializeField] bool drowGizmo;                //기즈모 드로우 유/무
    [SerializeField] GameObject[] player;           //플레이어 리스트
    [SerializeField] GameObject aniBox;             //애니메이션용 박스
    [SerializeField] GameObject randomBox;          //랜덤박스(젤 큰거)
    [SerializeField] Vector2 boxSize;               //박스의 사이즈
    [SerializeField] float moveDelay;               //움직임 딜레이
    [SerializeField] float changeDelay;             //체인지 딜레이
    [SerializeField] float colorDelay;              //컬러 딜레이

    Vector3[] characterPos = new Vector3[10];       //캐릭터 선택창 포지션
    float selectPos;                                //선택창 위치
    float gapX, gapY;                               //캐릭터별 간극
}
