using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    float noteSpeed;
    bool start=false;

    private void Start()
    {
        noteSpeed = GManager.instance.noteSpeed;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            start = true;
        }
        if (start)
        {
            transform.position -= transform.forward * noteSpeed * Time.deltaTime;
        }
        
    }
}
