using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlayerStatus : MonoBehaviour
{
    protected CarPlayerCtrl playerCtrl;
    private void Awake()
    {
        this.playerCtrl = GetComponent<CarPlayerCtrl>();
    }

    
    public virtual void Dead()
    {
        Debug.Log("Dead");
    }
}
