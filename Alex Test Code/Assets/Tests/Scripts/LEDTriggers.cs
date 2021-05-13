using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class LEDTriggers : MonoBehaviour
{
    public Renderer render;
    private MaterialPropertyBlock block;
    public bool LUB = true;

    public void Start()
    {
        block = new MaterialPropertyBlock();
        LED();
    }

    public void LED()
    {
        if (LUB== true)
        {
            block.SetFloat("Vector1_2B282BEF", 10);
            block.SetFloat("Vector1_C54CAB44", 0);
            render.SetPropertyBlock(block);
            //LUB = false;
        }

        if (LUB == false)
        {

            block.SetFloat("Vector1_2B282BEF", 0);
            block.SetFloat("Vector1_C54CAB44", 10);
            render.SetPropertyBlock(block);
            LUB = true;
        }
    }

   
    
      
}
