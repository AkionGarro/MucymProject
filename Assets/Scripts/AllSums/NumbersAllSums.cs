using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersAllSums : MonoBehaviour
{
    public int value; //The number on the piece
    public int row = 5; //0 to 4 are the positions on the game board          
    public int col = 2;

    private int _originalRow;
    private int _originalColumn;

    private Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.localPosition;
        _originalRow = row;
        _originalColumn = col;
    }

    public void ResetPosition()
    {
        transform.localPosition = _originalPosition;
        row = _originalRow;
        col = _originalColumn;
    }
}
