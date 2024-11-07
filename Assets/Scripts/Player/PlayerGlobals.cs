using System;
using UnityEngine;
using Aarthificial.Reanimation;


public static class PlayerGlobals{
    public static State State;
    public static Vector2 PlayerPosition;
    public static Vector2 DesiredDirection;
    public static int FacingDirection;
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