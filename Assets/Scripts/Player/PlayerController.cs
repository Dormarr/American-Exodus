using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This will handle the core of the player actions, direct signals and handle inputs.
public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Rigidbody2D rigidBody2D;

    private void Awake(){
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerMovement = gameObject.AddComponent<PlayerMovement>();
        playerMovement.Initialize(this.gameObject, rigidBody2D);
        
    }

    private void Start(){
        PlayerGlobals.Reanimator.AddListener("jabConnect", Jab);
    }

    private void Jab(){
        Debug.Log("Jab Connected.");
    }

    private void Update(){

    }
}
