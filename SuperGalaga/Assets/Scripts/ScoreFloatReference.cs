using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ScoreFloatReference
{
    public bool UseContant;
    public float ConstantValue;
    public FloatVariable Variable;

    public float Value
    {
        get { return UseContant ? ConstantValue : Variable.value; }
    }
}
