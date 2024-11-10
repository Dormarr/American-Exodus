using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    protected int index = 0;
    public abstract void ProceedToNextStage();
}
