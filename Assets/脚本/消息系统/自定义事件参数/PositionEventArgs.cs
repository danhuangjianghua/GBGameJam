using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionEventArgs : EventArgs
{
    public Vector3 worldPosition;
    public bool obstacle;
}
