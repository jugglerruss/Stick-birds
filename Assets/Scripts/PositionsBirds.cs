using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsBirds : MonoBehaviour
{
    private bool _isEmpty = true;

    public void PutIn()
    {
        _isEmpty = false;
    }
    public void Clear()
    {
        _isEmpty = true;
    }
    public bool IsEmpty()
    {
        return _isEmpty;
    }
}
