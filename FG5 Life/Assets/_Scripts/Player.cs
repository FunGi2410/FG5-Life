using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RequirementPlayer))]
public class Player : MonoBehaviour
{
    private ReqPlayerState curState;
    private RequirementPlayer reqPlayer;

    private void Start()
    {
        this.reqPlayer = GetComponent<RequirementPlayer>();

        // test
        this.reqPlayer.CreateState();
        this.curState = this.reqPlayer.GetState();
        print(this.curState);
    }
}
