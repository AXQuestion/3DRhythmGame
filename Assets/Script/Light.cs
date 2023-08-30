using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Light : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f; //消失的速度
    [SerializeField] private int lane;
    private Renderer rend;
    private float alfa = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); //獲取renderer的
    }

    // Update is called once per frame
    void Update()
    {
        if(!(rend.material.color.a <= 0))
        {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alfa);
        }

        if (Input.GetKeyDown(KeyCode.D))
            {
                if (lane == 1)
                {
                    colorChange();
                }
            }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lane == 2)
            {
                colorChange();
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (lane == 3)
            {
                colorChange();
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (lane == 4)
            {
                colorChange();
            }
        }


        alfa -= speed * Time.deltaTime;
    }
        
    void colorChange()
    {
        alfa = 0.3f;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alfa);
    }


}
