using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour //這邊是統一調整的地方
{
    public static GManager instance =null;

    public float maxScore;  //計算得分
    public float scoreRatio; //得分制度

    public int songID; //可以設定id
    public float noteSpeed;  //note 速度 統一調整
    
    
    public float startTime; //紀錄音樂播放瞬間的時間
    public bool start; //(須改) 確認是否撥放

    public int combo; //連擊數
    public int score;//分數


    public int Perfect;
    public int Great;
    public int Miss;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
