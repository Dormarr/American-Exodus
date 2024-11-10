using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MasterDir
{
    private static Level currentLevel;

    public static void GetCurrentLevel(){
        currentLevel = GameObject.Find("Manager").GetComponent<Level>();
    }

    public static void ProceedToNextStage(){
        if(currentLevel == null){
            GetCurrentLevel();
        }
        currentLevel.ProceedToNextStage();
    }
}
