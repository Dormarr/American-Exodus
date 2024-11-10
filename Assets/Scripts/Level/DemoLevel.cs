using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLevel : Level
{
    void Start(){
        index = 0;
    }

    public override void ProceedToNextStage(){
        switch(index){
            case 0:
                DoFirstThing();
                break;
            case 1:
                DoSecondThing();
                break;
            default:
                Debug.Log("All out of things to do.");
                break;
        }
    }

    void DoFirstThing(){
        Debug.Log("Did first thing.");
        index++;
    }

    void DoSecondThing(){
        Debug.Log("Did second thing.");
        index++;
    }
}
