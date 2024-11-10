using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentManager : MonoBehaviour
{
    // public List<Moment> moments = new List<Moment>();
    public int index;
    public Moment[] moments;

    void Start(){
        index = 0;
    }

    public void ExecuteNextMoment(){
        moments[index].Execute();
        index++;
    }
}
