using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class NoteJudge : MonoBehaviour
{
    [SerializeField] NotesManager noteManager; //呼叫資料
    [SerializeField] private GameObject[] gameObjects; //存入判定用

    [SerializeField] TMP_Text combo;
    [SerializeField] TMP_Text score;

    // Update is called once per frame
    void Update()
    {
        if (GManager.instance.start)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //雙壓判定改良
                //原因 : 排序為單獨資料 當遇到多個判定時會造成
                //雖然需同時處理但前一個順序還沒解決無法判斷
                //解決方式 : 連帶抓取下一個資料
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
        /*注意這裡 因為這邊判斷是利用位置來判斷 而且會有錯位誤判的情況
          (在多個同行note都可判定的範圍造成判定失敗)
          所以請自行抓好距離
          謝謝合作*/

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
    /*float GetAbs(float num)//其實用Math.abs就好
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

    void deleteData(int numOffset) //將已被判定的note 移除
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
