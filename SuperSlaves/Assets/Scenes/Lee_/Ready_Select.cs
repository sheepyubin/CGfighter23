using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class Ready_Select : MonoBehaviour
{
    //오브젝트 받아오기
    [SerializeField] bool drowGizmo;                //기즈모 드로우 유/무
    [SerializeField] GameObject[] player;           //플레이어 리스트
    [SerializeField] GameObject aniBox;             //애니메이션용 박스
    [SerializeField] Color color1;                  //애니메이션용 박스 색_1
    [SerializeField] Color color2;                  //애니메이션용 박스 색_2
    [SerializeField] GameObject randomBox;          //랜덤박스(젤 큰거)
    [SerializeField] Vector2 boxSize;               //박스의 사이즈

    //딜레이
    [SerializeField] float moveDelay;               //움직임 딜레이
    [SerializeField] float changeDelay;             //체인지 딜레이
    [SerializeField] float colorDelay;              //컬러 딜레이

    //코드 내에서만 보여지는 함수
    float time;
    float tempPos1;
    float tempPos2;

    Vector3[] characterPos = new Vector3[10];       //캐릭터 선택창 포지션
    float selectPos;                                //선택창 위치
    float gapX, gapY;                               //캐릭터별 간극
    bool spawn = false;                             //스폰이 끝났는가
    GameObject[] MoveObj = new GameObject[12];      //Dotween함수 쓰려고 만든거
    short checkSpawn = 0;                           //switch함수용 변수

    private void OnDrawGizmos()
    {
        if (drowGizmo)
        {
            tempPos1 = -gapX * 2;
            tempPos2 = -gapX * 2;
            for (int i = 0; i < characterPos.Length; i++)
            {
                if (i < 5)
                {
                    if (i != 2)
                    {
                        characterPos[i] = new Vector3(tempPos1, gapY - selectPos);
                        tempPos1 += gapX;
                        Gizmos.color = new UnityEngine.Color(1, 0, 0, 0.5f);
                        Gizmos.DrawCube(characterPos[i], boxSize);
                    }
                    else
                        tempPos1 += gapX;
                }
                else
                {
                    if (i != 7)
                    {
                        characterPos[i] = new Vector3(tempPos2, -gapY - selectPos);
                        tempPos2 += gapX;
                        Gizmos.color = new UnityEngine.Color(1, 0, 0, 0.5f);
                        Gizmos.DrawCube(characterPos[i], boxSize);
                    }
                    else
                        tempPos2 += gapX;
                }
            }
            Gizmos.color = new UnityEngine.Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(new Vector2(0, -selectPos), new Vector2(boxSize.x, boxSize.y + (gapY * 2)));
        }
    }

    void Start()
    {
        aniBox.GetComponent<SpriteRenderer>().color = color1;
        time = 0.0f;

        tempPos1 = -gapX * 2;
        tempPos2 = -gapX * 2;
        for (int i = 0; i < characterPos.Length; i++)
        {
            if (i < 5)
            {
                characterPos[i] = new Vector3(tempPos1, gapY - selectPos);
                tempPos1 += gapX;
            }
            else
            {
                characterPos[i] = new Vector3(tempPos2, -gapY - selectPos);
                tempPos2 += gapX;
            }
        }
    }

    private void Update()
    {
        if (!spawn)
        {
            switch (checkSpawn)
            {
                case 0:
                    time += Time.deltaTime;
                    if (time > 0.5f)
                    {
                        //Top
                        MoveObj[0] = Instantiate(aniBox, new Vector3(0, -selectPos), Quaternion.identity);
                        MoveObj[0].transform.DOMoveY(gapY - selectPos, moveDelay);
                    }
                    checkSpawn++;
                    time = 0.0f;
                    break;
                case 1:
                    time += Time.deltaTime;
                    if (time > changeDelay)
                    {
                        //Top
                        {
                            MoveObj[2] = Instantiate(aniBox, new Vector3(0, gapY - selectPos), Quaternion.identity);
                            MoveObj[2].transform.DOMoveX(characterPos[1].x, moveDelay);

                            MoveObj[3] = Instantiate(aniBox, new Vector3(0, gapY - selectPos), Quaternion.identity);
                            MoveObj[3].transform.DOMoveX(characterPos[3].x, moveDelay);
                        }
                        //Bottom
                        {
                            MoveObj[4] = Instantiate(aniBox, new Vector3(0, -gapY - selectPos), Quaternion.identity);
                            MoveObj[4].transform.DOMoveX(characterPos[6].x, moveDelay);

                            MoveObj[5] = Instantiate(aniBox, new Vector3(0, -gapY - selectPos), Quaternion.identity);
                            MoveObj[5].transform.DOMoveX(characterPos[8].x, moveDelay);
                        }
                        checkSpawn++;
                        time = 0.0f;
                    }
                    break;
                case 2:
                    time += Time.deltaTime;
                    if (time > changeDelay * 0.9f)
                    {
                        //Top
                        {
                            MoveObj[6] = Instantiate(aniBox, new Vector3(characterPos[1].x, gapY - selectPos), Quaternion.identity);
                            MoveObj[6].transform.DOMoveX(characterPos[0].x, moveDelay);

                            MoveObj[7] = Instantiate(aniBox, new Vector3(characterPos[3].x, gapY - selectPos), Quaternion.identity);
                            MoveObj[7].transform.DOMoveX(characterPos[4].x, moveDelay);
                        }
                        //Bottom
                        {
                            MoveObj[8] = Instantiate(aniBox, new Vector3(characterPos[6].x, -gapY - selectPos), Quaternion.identity);
                            MoveObj[8].transform.DOMoveX(characterPos[5].x, moveDelay);

                            MoveObj[9] = Instantiate(aniBox, new Vector3(characterPos[8].x, -gapY - selectPos), Quaternion.identity);
                            MoveObj[9].transform.DOMoveX(characterPos[9].x, moveDelay);
                        }
                        checkSpawn++;
                        time = 0.0f;
                    }
                    break;
                case 3:
                    time += Time.deltaTime;
                    if (time > changeDelay)
                    {
                        //Top
                        {
                            MoveObj[10] = Instantiate(aniBox, new Vector2(0, gapY - selectPos), Quaternion.identity);
                            MoveObj[10].transform.DOMoveY(-selectPos, moveDelay * 25);
                        }
                        //Bottom
                        {
                            MoveObj[11] = Instantiate(aniBox, new Vector2(0, -gapY - selectPos), Quaternion.identity);
                            MoveObj[11].transform.DOMoveY(-selectPos, moveDelay * 25);
                        }
                        checkSpawn++;
                        time = 0.0f;
                    }
                    break;
                case 4:
                    time += Time.deltaTime;
                    if (time > changeDelay)
                    {
                        Destroy(MoveObj[0]);
                        Destroy(MoveObj[1]);
                        Destroy(MoveObj[10]);
                        Destroy(MoveObj[11]);
                        MoveObj[0] = Instantiate(aniBox, new Vector3(0, -selectPos), Quaternion.identity);
                        MoveObj[0].transform.localScale = new Vector3(boxSize.x, boxSize.y + (gapY * 2), 1);
                        MoveObj[0].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        checkSpawn++;
                        time = 0.0f;
                    }
                    break;
                case 5:
                    time += Time.deltaTime;
                    if (time > changeDelay * 1.2f)
                    {
                        MoveObj[2].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        MoveObj[3].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        MoveObj[4].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        MoveObj[5].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        checkSpawn++;
                        time = 0.0f;
                    }
                    break;
                case 6:
                    time += Time.deltaTime;
                    if (time > changeDelay * 1.2f)
                    {
                        MoveObj[6].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        MoveObj[7].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        MoveObj[8].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        MoveObj[9].GetComponent<SpriteRenderer>().DOColor(color2, colorDelay);
                        checkSpawn++;
                        time = 0.0f;
                    }
                    break;
                case 7:
                    time += Time.deltaTime;
                    if (time > changeDelay * 1.2f)
                    {
                        MoveObj[0].GetComponent<SpriteRenderer>().DOColor(new UnityEngine.Color(0.2f, 0, 0, 0), colorDelay * 1.5f);
                        checkSpawn++;
                        time = 0.0f;
                    }
                    break;
            }
        }
    }
}
