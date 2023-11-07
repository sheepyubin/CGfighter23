using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class ReadyManager : MonoBehaviour
{
    public bool drowGizmo;                              //기즈모 그릴건지
    [SerializeField] GameObject tempBox;                //애니메이션용 박스
    public GameObject[] character;                      //캐릭터 종류
    public Vector3[] characterPos = new Vector3[10];    //캐릭터 선택창 포지션
    public float selectPos;                             //선택창 위치
    public float gapX, gapY;                            //캐릭터별 간극
    public Vector2 boxSize;                             //박스의 사이즈
    public float moveDelay;                             //움직임 딜레이
    public float changeDelay;                           //체인지 딜레이
    public float colorDelay;                            //컬러 딜레이

    float tempPos1, tempPos2;                            //스폰의 시작점
    float time;                                         //deltatime용 변수

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
        time = 0.0f;

        tempPos1 = -gapX * 2;
        tempPos2 = -gapX * 2;
        for (int i = 0; i < characterPos.Length; i++)
        {
            if (i < 5)
            {
                characterPos[i] = new Vector3(tempPos1, gapY - selectPos);
                tempPos1 += gapX;
                //Instantiate(character[0], characterPos[i], Quaternion.identity);
            }
            else
            {
                characterPos[i] = new Vector3(tempPos2, -gapY - selectPos);
                tempPos2 += gapX;
                //Instantiate(character[0], characterPos[i], Quaternion.identity);
            }
        }
    }


    GameObject[] tempObj = new GameObject[12];
    short checkSpawn = 0;
    bool spawn = false;
    int tempArr = 0;

    void Update()
    {
        if (!spawn)
        {
            switch (checkSpawn)
            {
                case 0:
                    time += Time.deltaTime;
                    if(time > 0.5f)
                    {
                        //Top
                        {
                            tempObj[0] = Instantiate(tempBox, new Vector3(0, -selectPos), Quaternion.identity);
                            tempObj[0].transform.DOMoveY(gapY - selectPos, moveDelay);
                            tempArr++;
                        }
                        //Bottom
                        {
                            tempObj[1] = Instantiate(tempBox, new Vector3(0, -selectPos), Quaternion.identity);
                            tempObj[1].transform.DOMoveY(-gapY - selectPos, moveDelay);
                            tempArr++;
                        }
                        checkSpawn++;
                        time = 0.0f;
                    }
                    
                    break;

                case 1:
                    time += Time.deltaTime;
                    if(time> changeDelay)
                    {
                        //Top
                        {
                            tempObj[2] = Instantiate(tempBox, new Vector3(0, gapY - selectPos), Quaternion.identity);
                            tempObj[2].transform.DOMoveX(characterPos[1].x, moveDelay);
                            tempArr++;
                            
                            tempObj[3] = Instantiate(tempBox, new Vector3(0, gapY - selectPos), Quaternion.identity);
                            tempObj[3].transform.DOMoveX(characterPos[3].x, moveDelay);
                            tempArr++;
                        }
                        //Bottom
                        {
                            tempObj[4] = Instantiate(tempBox, new Vector3(0, -gapY - selectPos), Quaternion.identity);
                            tempObj[4].transform.DOMoveX(characterPos[6].x, moveDelay);
                            tempArr++;

                            tempObj[5] = Instantiate(tempBox, new Vector3(0, -gapY - selectPos), Quaternion.identity);
                            tempObj[5].transform.DOMoveX(characterPos[8].x, moveDelay);
                            tempArr++;
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
                            tempObj[6] = Instantiate(tempBox, new Vector3(characterPos[1].x, gapY - selectPos), Quaternion.identity);
                            tempObj[6].transform.DOMoveX(characterPos[0].x, moveDelay);
                            tempArr++;

                            tempObj[7] = Instantiate(tempBox, new Vector3(characterPos[3].x, gapY - selectPos), Quaternion.identity);
                            tempObj[7].transform.DOMoveX(characterPos[4].x, moveDelay);
                            tempArr++;
                        }
                        //Bottom
                        {
                            tempObj[8] = Instantiate(tempBox, new Vector3(characterPos[6].x, -gapY - selectPos), Quaternion.identity);
                            tempObj[8].transform.DOMoveX(characterPos[5].x, moveDelay);
                            tempArr++;

                            tempObj[9] = Instantiate(tempBox, new Vector3(characterPos[8].x, -gapY - selectPos), Quaternion.identity);
                            tempObj[9].transform.DOMoveX(characterPos[9].x, moveDelay);
                            tempArr++;
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
                            tempObj[10] = Instantiate(tempBox, new Vector2(0,gapY - selectPos), Quaternion.identity);
                            tempObj[0].transform.DOMoveY(-selectPos, moveDelay * 50);
                            tempArr++;
                        }
                        //Bottom
                        {
                            tempObj[11] = Instantiate(tempBox, new Vector2(0, -gapY - selectPos), Quaternion.identity);
                            tempObj[11].transform.DOMoveY(-selectPos, moveDelay * 50);
                            tempArr++;
                        }
                        checkSpawn++;
                        time = 0.0f;
                    }
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;

            }
        }
    }
}
