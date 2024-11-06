using System;
using UnityEngine;
using Aarthificial.Reanimation;

public enum PlayerState{
    Idle = 0,
    Movement = 1,
    Attack = 2,
    Damage = 3,
    Dash = 4,
    Dead = 5

}

public static class PlayerGlobals{
    public static PlayerState State;
    public static Vector2 PlayerPosition;
    public static Vector2 DesiredDirection;
    public static int MoveSpeed = 4;
    public static Reanimator Reanimator;

    // State Determining Variables
    public static bool IsMoving;
    public static bool IsAttacking;
    public static bool IsGrounded;
    public static bool IsDashing;
    public static bool IsDead;
    public static int DamageLevel; // Use to determine what texture to use, how bloodied.
}