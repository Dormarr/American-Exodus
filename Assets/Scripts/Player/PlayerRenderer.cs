using System;
using System.Collections;
using UnityEngine;
using Aarthificial.Reanimation;

public class PlayerRenderer : MonoBehaviour
{
    private static class Drivers
    {
        public const string State = "state";
        public const string AttackType = "attackType";
        public const string AttackDone = "attackDone";
    }

    private Reanimator _reanimator;

    void Awake(){
        _reanimator = GetComponent<Reanimator>();
        _reanimator.AddListener(Drivers.AttackDone, UpdatePlayerState);
        PlayerGlobals.Reanimator = _reanimator;
    }

    void Update(){
        AnimationHandler();
    }

    void AnimationHandler(){
        int facingDir = PlayerGlobals.DesiredDirection.x > 0 ? 1 : -1;
        facingDir = PlayerGlobals.DesiredDirection.x == 0 ? PlayerGlobals.FacingDirection : facingDir;

        PlayerGlobals.FacingDirection = facingDir;

        _reanimator.Flip = facingDir < 1;
        _reanimator.Set(Drivers.State, (int)PlayerGlobals.State);
        _reanimator.Set(Drivers.AttackType, (int)PlayerGlobals.AttackType);
    }

    void UpdatePlayerState(){
        PlayerGlobals.State = State.Idle;
    }

    
}