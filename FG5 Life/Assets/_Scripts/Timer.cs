using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    static public bool IsCounter(ref float timer, float timeDuration)
    {
        if(timer < timeDuration)
        {
            timer += Time.deltaTime;
            //float secs = Mathf.FloorToInt(timer);
            return false;
        }
        else
        {
            timer = 0f;
            return true;
        }
    }
}
