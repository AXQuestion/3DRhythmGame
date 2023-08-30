using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour //�o��O�Τ@�վ㪺�a��
{
    public static GManager instance =null;

    public float maxScore;  //�p��o��
    public float scoreRatio; //�o�����

    public int songID; //�i�H�]�wid
    public float noteSpeed;  //note �t�� �Τ@�վ�
    
    
    public float startTime; //�������ּ����������ɶ�
    public bool start; //(����) �T�{�O�_����

    public int combo; //�s����
    public int score;//����


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
