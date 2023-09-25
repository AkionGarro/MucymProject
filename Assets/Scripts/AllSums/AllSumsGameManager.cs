using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSumsGameManager : MonoBehaviour
{
    public GameObject[] replacementNumbers;

    private int[,] _numbers;

    public GameObject pivot;

    private UI_ManagerAllSums _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        DisableReplacementNumbers();
        _numbers = new int[5, 2];
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_ManagerAllSums>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableReplacementNumbers()
    {
        pivot.SetActive(false);
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(false);
        }
        
    }

    public void EnableReplacementNumbers()
    {
        pivot.SetActive(true);
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(true);
        }
       
    }



    
    private bool CheckIfWin()
    {
        bool flag = false;

        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            NumbersAllSums numScript = nums[i].GetComponent<NumbersAllSums>();
            //Debug.Log("[" + numScript.row + "," + numScript.col + "] = " + numScript.value);

            if (numScript.row != 5 && numScript.col != 2)
            {
                if (numScript.value == 0) //If there are still clean pieces on the evaluation board: row -> 0,1,2 or col -> 0,1,2
                    return false;
                else
                    _numbers[numScript.row, numScript.col] = numScript.value; //Load the value of the piece on it's current position 
            }
        }

        int condition1_value = _numbers[0, 0] + _numbers[0, 1] + pivot.GetComponent<NumbersAllSums>().value;
        int condition2_value = _numbers[1, 0] + _numbers[1, 1] + pivot.GetComponent<NumbersAllSums>().value;
        int condition3_value = _numbers[2, 0] + _numbers[2, 1] + pivot.GetComponent<NumbersAllSums>().value;
        int condition4_value = _numbers[3, 0] + _numbers[3, 1] + pivot.GetComponent<NumbersAllSums>().value;
        int condition5_value = _numbers[4, 0] + _numbers[4, 1] + pivot.GetComponent<NumbersAllSums>().value;
        Debug.Log(condition1_value);
        Debug.Log(condition2_value);
        Debug.Log(condition3_value);
        Debug.Log(condition4_value);
        Debug.Log(condition5_value);

        int targetValue = condition1_value;
       if (condition1_value != targetValue ||
           condition2_value != targetValue ||
           condition3_value != targetValue ||
           condition4_value != targetValue ||
           condition5_value != targetValue)
        {
            flag = false;
        }
        else
        {
            flag = true;
        }

        
        return false;



    }
    public void CheckLastMovement()
    {
        if (CheckIfWin())
        {
            _uiManager.ShowVictoryScreen();
            _uiManager.StopTimer();
        }

    }

    public void RestartGame()
    {
        _uiManager.HideVictoryScreen();
        EnableReplacementNumbers();
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i].GetComponent<NumbersAllSums>().ResetPosition();
        }
        DisableReplacementNumbers();

        _uiManager.ResetTimer();
    }



    

}

