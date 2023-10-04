using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Range {

    [SerializeField] private int min;
    [SerializeField] private int max;

    public int Value { get { return UnityEngine.Random.Range(min, max + 1); } }

}
