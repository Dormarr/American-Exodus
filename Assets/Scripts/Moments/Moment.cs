using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Moment : ScriptableObject
{
    public bool Complete;

    public abstract void Execute();
}

[CreateAssetMenu(fileName = "New Generic Moment", menuName = "Moments/Generic Moment")]
public class GenericMoment : Moment{
    public override void Execute(){
        Debug.Log("GenericMoment: Execute called.");
    }
}