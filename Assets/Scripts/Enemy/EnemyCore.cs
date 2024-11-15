using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aarthificial.Reanimation;

// I'll handle all the animation triggers and stuff here, it's easier that way.
// I'll likely add a pathfinding script as either an additional script or as a static class.

public class EnemyCore : MonoBehaviour
{
    private static class EnemyDrivers
    {
        public const string State = "state";
        public const string DamageDone = "damageDone";
    }

    // TEMPORARY
    private int health = 5;
    private bool isDead = false;



    private Reanimator _reanimator;
    public Guid EnemyID { get; private set; } //UNUSED - But might use later.
    public Vector2 EnemyPosition { get; private set; }
    public State EnemyState { get; private set; }

    private bool inAttackRange = false;

    private void Awake(){
        _reanimator = GetComponentInChildren<Reanimator>();
        EnemyID = Guid.NewGuid();
        Debug.Log($"Enemy created with ID: {EnemyID}");
        EnemyState = State.Idle;
    }

    public void Start(){
        _reanimator.AddListener(EnemyDrivers.DamageDone, SwitchState);
    }

    public void Update(){
        EnemyPosition = transform.position;
        AnimationHandler();
    }

    private void AnimationHandler(){
        _reanimator.Set(EnemyDrivers.State, (int)EnemyState);
    }

    public void Attack(){
        // Attack the player.

        // Pathfind to player, if within desired range, then trigger attack.
    }

    public void Damage(AttackType attackType){
        // Take damage, trigger damage animations.

        if(isDead){
            return;
        }

        EnemyState = State.Damage;
        Debug.Log($"Damage Taken from {attackType}");

        health--;

        if(health <= 0){
            Die();
        }

        // If it's heavy damage, add velocity in opposite direction of relative player position.
    }

    public void Die(){
        // Remove any colliders.

        // Temporary to demonstrate level stage development.
        MasterDir.ProceedToNextStage();
        EnemyState = State.Dead;
    }

    private void SwitchState(){
        EnemyState = State.Idle;
    }

}
