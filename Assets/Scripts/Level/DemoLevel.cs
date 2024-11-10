using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DemoLevel : Level
{
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineConfiner2D confiner;

    public Collider2D confinerCollider1;
    public Collider2D confinerCollider2;

    void Start(){
        index = 0;

        InitializeConfiner();
    }

    void InitializeConfiner(){
        try{
            confiner = virtualCamera.GetComponent<CinemachineConfiner2D>();
        }
        catch(Exception e){
            Debug.Log($"Cinemachine Confiner Issue: {e}");
        }

        if(confiner == null){
            // confiner = virtualCamera.gameObject.AddComponent<CinemachineConfiner2D>();
            return;
        }

        confiner.m_BoundingShape2D = confinerCollider1;
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
                // Fall back on whatever, doesn't really matter.
                Debug.Log("All out of things to do.");
                break;
        }
    }

    void DoFirstThing(){
        confiner.m_BoundingShape2D = confinerCollider2;
        confiner.InvalidateCache();

        // Spawn a bunch of enemies in spots ready for this round.


        Debug.Log("Did first thing.");
        index++;
    }

    void DoSecondThing(){
        Debug.Log("Did second thing.");
        index++;
    }
}
