using SkulWatermelon.Data;
using System.Collections.Generic;
using SkulWatermelon.Model;
using UnityEngine;
using UnityEngine.Serialization;
using System;

[Serializable]
public class GameResourceManager
{
    [SerializeField]
    List<Head> head;

    public int maximumLevel => head.Count;

    public Head GetHeadPrefab(int level)
    {
        if (head.Count <= level)
            return head[0];

        return head[level];
    }
}
