﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData",menuName ="Enemy/Data")]
public class EnemyData : ScriptableObject
{
    public float speed;
    public GameObject EnemyDes;
    public float endZpoint;
}
