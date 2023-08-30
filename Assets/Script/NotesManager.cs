using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data //�Э���T
{
    public string name;
    public int maxBlock;
    public float BPM;
    public int offset;
    public NoteType[] notes;
}

[Serializable]
public class NoteType //note ��m
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
    
    public List<int> LaneNum =new List<int>(); //note �|�X�{�����
    public List<int> noteType = new List<int>(); //note ����
    public List<float> noteTime = new List<float>(); //note�P�P�w�u��Ĳ���ɶ�
    public List<GameObject> NotesObj = new List<GameObject>();

    private float notesSpeed;
    [SerializeField] GameObject noteObj;


    void OnEnable() //���w�����@�}�l���J���F��
    {
        noteNum = 0;
        notesSpeed = GManager.instance.noteSpeed;
        jsonName ="NULCTRL";
        load(jsonName);
    }

    private void load(string song)
    {
        string inputString = Resources.Load<TextAsset>(song).ToString(); //�I�s�q�Wjson��
        Data inputJson = JsonUtility.FromJson<Data>(inputString); //inputJson ����json ���
        noteNum = inputJson.notes.Length;

        GManager.instance.maxScore = noteNum * 5; //�]�w�s��������̦h�n�h��

        for (int i = 0; i < noteNum; i++)
        {
            float spacing = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB); //�p���C���Cnote�����Z���
            float beatSec = spacing * (float)inputJson.notes[i].LPB; //���note��ڥX�{�����j�e��
            float noteOffset = inputJson.offset * 0.01f;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB)+noteOffset;
            noteTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            noteType.Add(inputJson.notes[i].type);
            //note �ͦ�
            float z = noteTime[i]*notesSpeed;
            NotesObj.Add(Instantiate(noteObj,new Vector3(inputJson.notes[i].block-1.5f,0.55f,z-7),Quaternion.identity));
        }
    }
}
