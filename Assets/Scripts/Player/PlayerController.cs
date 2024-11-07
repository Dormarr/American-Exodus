using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This will handle the core of the player actions, direct signals and handle inputs.
public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Rigidbody2D rigidBody2D;

    //These exist so that if player attacks, every enemy in the attack range list will be impacted.
    private List<EnemyCore> enemiesInProximity = new List<EnemyCore>();
    private List<EnemyCore> enemiesInAttackRange = new List<EnemyCore>();


    private void Awake(){
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerMovement = gameObject.AddComponent<PlayerMovement>();
        playerMovement.Initialize(this.gameObject, rigidBody2D);
        
    }

    private void Start(){
        PlayerGlobals.Reanimator.AddListener("jabConnect", Jab);
    }

    #region Triggers

    private void OnTriggerEnter2D(Collider2D other) {
        // check if other is an enemy.

        EnemyCore enemy = other.GetComponent<EnemyCore>();

        if(enemy != null){
            enemiesInProximity.Add(enemy);
            Debug.Log($"Enemy entered proximity.");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        // Temporary lists to hold changes
        List<EnemyCore> toAttackRange = new List<EnemyCore>();
        List<EnemyCore> toProximity = new List<EnemyCore>();

        if (enemiesInProximity.Count >= 1) {
            foreach (EnemyCore enemy in enemiesInProximity) {
                if (AssessAttackDistance(enemy)) {
                    toAttackRange.Add(enemy);
                    Debug.Log($"Enemy is within attack range.");
                }
            }
        }

        if (enemiesInAttackRange.Count >= 1) {
            foreach (EnemyCore enemy in enemiesInAttackRange) {
                if (!AssessAttackDistance(enemy)) {
                    toProximity.Add(enemy);
                    Debug.Log($"Enemy is in proximity.");
                }
            }
        }

        // Apply changes outside of the loops
        foreach (EnemyCore enemy in toAttackRange) {
            enemiesInProximity.Remove(enemy);
            enemiesInAttackRange.Add(enemy);
        }

        foreach (EnemyCore enemy in toProximity) {
            enemiesInAttackRange.Remove(enemy);
            enemiesInProximity.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        EnemyCore enemy = other.GetComponent<EnemyCore>();

        if(enemy != null){
            try{
                enemiesInAttackRange.Remove(enemy);
            }
            catch(Exception e){
                Debug.LogWarning($"Enemy exiting proximity not in attack range list: {enemy.EnemyID}. \n Exception: {e}");
            }
            try{
                enemiesInProximity.Remove(enemy);
            }catch(Exception e){
                Debug.LogWarning($"Enemy exiting proximity not in proximity list: {enemy.EnemyID}. \n Exception: {e}");
            }
        }
    }

    #endregion

    private void Jab(){
        foreach(EnemyCore enemy in enemiesInAttackRange){
            enemy.Damage(AttackType.Jab);
        }
    }

    private bool AssessAttackDistance(EnemyCore enemy){
        int enemyRelativeX = PlayerGlobals.PlayerPosition.x < enemy.EnemyPosition.x ? 1 : -1;

        if(enemyRelativeX == PlayerGlobals.FacingDirection){
            return true;
        }
        else{
            return false;
        }
    }
}
