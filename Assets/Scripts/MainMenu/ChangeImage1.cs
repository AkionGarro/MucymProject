using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage1 : MonoBehaviour
{
    public Sprite[] sprites;
    public Image imageRenderer;
    public static int selectNum = 0;


    public int getSelectNum()
    {
        return selectNum;
    }
    public void setSelectNum(int num)
    {
        selectNum = num;
    }

    public void nextScene()
    {
       

        if (selectNum == sprites.Length-1)
        {
            imageRenderer.sprite = sprites[selectNum];
            selectNum = 0;
        }
        else
        {
            selectNum += 1;
        }
        Debug.Log("Index: " + selectNum);
        imageRenderer.sprite = sprites[selectNum];


    }

    public void previousScene()
    {
       
        if (selectNum != 0)
        {
            selectNum -= 1;
            
        }
        else
        {
            selectNum = sprites.Length-1;
        }
        Debug.Log("Index: " + selectNum);
        imageRenderer.sprite = sprites[selectNum];

    }

 

}
