using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementPlayer : MonoBehaviour
{
    private ReqPlayerState state;
    // - image

    public ReqPlayerState GetState()
    {
        return this.state;
    }

    public void CreateState()
    {
        int randomState = Random.Range(0, 3); // test 0 - 3
        this.state = (ReqPlayerState)randomState;
    }
}

public enum ReqPlayerState
{
    eat,
    sleep,
    toilet
}
