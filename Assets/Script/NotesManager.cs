using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data //譜面資訊
{
    public string name;
    public int maxBlock;
    public float BPM;
    public int offset;
    public NoteType[] notes;
}

[Serializable]
public class NoteType //note 位置
{
    public int LPB;
    public int num;
    public int block;
    public int type;
}

public class NotesManager : MonoBehaviour
{
    public int noteNum;
    private string jsonName;
    
    public List<int> LaneNum =new List<int>(); //note 會出現的行數
    public List<int> noteType = new List<int>(); //note 種類
    public List<float> noteTime = new List<float>(); //note與判定線接觸的時間
    public List<GameObject> NotesObj = new List<GameObject>();

    private float notesSpeed;
    [SerializeField] GameObject noteObj;


    void OnEnable() //當選定切換一開始載入的東西
    {
        noteNum = 0;
        notesSpeed = GManager.instance.noteSpeed;
        jsonName ="NULCTRL";
        load(jsonName);
    }

    private void load(string song)
    {
        string inputString = Resources.Load<TextAsset>(song).ToString(); //呼叫歌名json檔
        Data inputJson = JsonUtility.FromJson<Data>(inputString); //inputJson 紀錄json 資料
        noteNum = inputJson.notes.Length;

        GManager.instance.maxScore = noteNum * 5; //設定連擊分機制最多要多少

        for (int i = 0; i < noteNum; i++)
        {
            float spacing = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB); //計算兩列間列note的間距秒數
            float beatSec = spacing * (float)inputJson.notes[i].LPB; //顯示note實際出現的間隔寬度
            float noteOffset = inputJson.offset * 0.01f;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB)+noteOffset;
            noteTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            noteType.Add(inputJson.notes[i].type);
            //note 生成
            float z = noteTime[i]*notesSpeed;
            NotesObj.Add(Instantiate(noteObj,new Vector3(inputJson.notes[i].block-1.5f,0.55f,z-7),Quaternion.identity));
        }
    }
}
