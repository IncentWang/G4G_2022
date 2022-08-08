using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRepeatRandom
{
    int totalCount;
    int nowCount = 0;
    Hashtable hashtable = new Hashtable();
    public NoRepeatRandom(int total)
    {
        totalCount = total;
        float randomNumber;
        int i = 0;
        while (hashtable.Count < total)
        {
            randomNumber = Random.Range(0, 1f);
            if (!hashtable.ContainsValue(randomNumber))
            {
                hashtable.Add(i, randomNumber);
                i++;
            }
        }
    }

    public float Next()
    {
        float result = (float)hashtable[nowCount];
        nowCount++;
        if (nowCount == totalCount)
        {
            nowCount = 0;
        }
        return result;
    }
}
