using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class NoteJudge : MonoBehaviour
{
    [SerializeField] NotesManager noteManager; //�I�s���
    [SerializeField] private GameObject[] gameObjects; //�s�J�P�w��

    [SerializeField] TMP_Text combo;
    [SerializeField] TMP_Text score;

    // Update is called once per frame
    void Update()
    {
        if (GManager.instance.start)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //�����P�w��}
                //��] : �ƧǬ���W��� ��J��h�ӧP�w�ɷ|�y��
                //���M�ݦP�ɳB�z���e�@�Ӷ����٨S�ѨM�L�k�P�_
                //�ѨM�覡 : �s�a����U�@�Ӹ��
                if (noteManager.LaneNum[0] == 0)
                {
                    Judgement(Math.Abs(Time.time - (noteManager.noteTime[0] + GManager.instance.startTime)),0);
                }
                else
                {
                    if (noteManager.LaneNum[1] == 0)
                    {
                        Judgement(Math.Abs(Time.time - (noteManager.noteTime[1] + GManager.instance.startTime)), 1);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (noteManager.LaneNum[0] == 1)
                {
                    Judgement(Math.Abs((float)Time.time - (noteManager.noteTime[0] + GManager.instance.startTime)), 0);
                }
                else
                {
                    if (noteManager.LaneNum[1] == 1)
                    {
                        Judgement(Math.Abs(Time.time - (noteManager.noteTime[1] + GManager.instance.startTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (noteManager.LaneNum[0] == 2)
                {
                    Judgement(Math.Abs(Time.time - (noteManager.noteTime[0] + GManager.instance.startTime)), 0);
                }
                else
                {
                    if (noteManager.LaneNum[1] == 2)
                    {
                        Judgement(Math.Abs(Time.time - (noteManager.noteTime[1] + GManager.instance.startTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (noteManager.LaneNum[0] == 3)
                {
                    Judgement(Math.Abs(Time.time - (noteManager.noteTime[0] + GManager.instance.startTime)), 0);
                }
                else
                {
                    if (noteManager.LaneNum[1] == 3)
                    {
                        Judgement(Math.Abs(Time.time - (noteManager.noteTime[1] + GManager.instance.startTime)), 1);
                    }
                }
            }
            if (Time.time > noteManager.noteTime[0] + 0.25f + GManager.instance.startTime)
            {
                message(2,0);
                Debug.Log("Miss");
                GManager.instance.Miss++;
                GManager.instance.combo = 0;
                deleteData(0);
            }
       
        if (0 == noteManager.noteTime.Count)
            {
                return;
            }
        }
    }

    void Judgement(float timeLag,int num)
    {
        /*�`�N�o�� �]���o��P�_�O�Q�Φ�m�ӧP�_ �ӥB�|������~�P�����p
          (�b�h�ӦP��note���i�P�w���d��y���P�w����)
          �ҥH�Цۦ��n�Z��
          ���¦X�@*/

        if (timeLag <= 0.1)
        {
            message(0,num);
            Debug.Log("Perfect");
            GManager.instance.scoreRatio += 5;
            GManager.instance.Perfect++;
            GManager.instance.combo ++;
            deleteData(num);
        }
        else {
            if (timeLag <= 0.2)
            {
                message(1,num);
                Debug.Log("Great");
                GManager.instance.scoreRatio += 3;
                GManager.instance.Great++;
                GManager.instance.combo ++;
                deleteData(num);
            }
        }
           
    }
    /*float GetAbs(float num)//����Math.abs�N�n
    {
        if (num >=0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }*/

    void deleteData(int numOffset) //�N�w�Q�P�w��note ����
    {
        noteManager.noteTime.RemoveAt(numOffset);
        noteManager.LaneNum.RemoveAt(numOffset);
        noteManager.noteType.RemoveAt(numOffset);
        GManager.instance.score = (int)Math.Round(1000000*Math.Floor(GManager.instance.scoreRatio/GManager.instance.maxScore*1000000)/1000000);
        combo.text = GManager.instance.combo.ToString();
        score.text = string.Format("{0:0000000}",GManager.instance.score.ToString());
    }

    void message(int num,int arrayNum)
    {
        Instantiate(gameObjects[num],new Vector3(noteManager.LaneNum[arrayNum]-1.5f,1f,0.15f),Quaternion.Euler(45,0,0));
    }
}
