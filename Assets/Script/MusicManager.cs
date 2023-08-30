using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    AudioSource source;
    AudioClip clip;
    string songName; //�q���W �i��n��reference���覡
    bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        songName = "NULCTRL(short ver.)";
        source = GetComponent<AudioSource>();
        if (source == null) source = gameObject.AddComponent<AudioSource>();
        clip = Resources.Load<AudioClip>("Music/"+songName);

        isPlaying = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& !isPlaying) //�ثe�O�]�w�L�u����Uspace�~��C��
        {
            GManager.instance.start = true;
            GManager.instance.startTime = Time.time;
            isPlaying = true;
            source.PlayOneShot(clip, 0.3f);
        }
    }
}
