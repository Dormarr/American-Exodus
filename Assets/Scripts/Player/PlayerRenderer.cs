using System;
using System.Collections;
using UnityEngine;
using Aarthificial.Reanimation;

public class PlayerRenderer : MonoBehaviour
{
    private static class Drivers
    {
        public const string State = "state";
        public const string AttackDone = "attackDone";
    }

    private Reanimator _reanimator;

    private int facingDir;

    void Awake(){
        _reanimator = GetComponent<Reanimator>();
        _reanimator.AddListener(Drivers.AttackDone, UpdatePlayerState);
        PlayerGlobals.Reanimator = _reanimator;
    }

    void Update(){
        AnimationHandler();
    }

    void AnimationHandler(){

        if(PlayerGlobals.DesiredDirection.x > 0){
            facingDir = 1;
        }
        else if(PlayerGlobals.DesiredDirection.x < 0){
            facingDir = -1;
        }



        _reanimator.Flip = facingDir < 1;
        _reanimator.Set(Drivers.State, (int)PlayerGlobals.State);
    }

    void UpdatePlayerState(){
        PlayerGlobals.State = PlayerState.Idle;
    }

    
}