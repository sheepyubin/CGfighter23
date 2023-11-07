using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ReadyManager : MonoBehaviour
{
    public bool drowGizmo;                              //기즈모 그릴건지
    [SerializeField] GameObject redBox;                 //애니메이션용 박스
    public GameObject[] character;                      //캐릭터 종류
    public Vector3[] characterPos = new Vector3[10];    //캐릭터 선택창 포지션
    public float selectPos;                             //선택창 위치
    public float gapX, gapY;                            //캐릭터별 간극
    public Vector2 boxSize;                             //박스의 사이즈
    public float delay;                                 //애니메이션 딜레이

    float tempPos1,tempPos2;                            //스폰의 시작점
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
            Gizmos.DrawCube(new Vector2(0,-selectPos), new Vector2(boxSize.x, boxSize.y + (gapY*2)));
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
                if (i != 2)
                {
                    characterPos[i] = new Vector3(tempPos1, gapY - selectPos);
                    tempPos1 += gapX;
                    Instantiate(character[0], characterPos[i], Quaternion.identity);
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
                    Instantiate(character[0], characterPos[i], Quaternion.identity);
                }
                else
                    tempPos2 += gapX;
            }
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        
    }
}
