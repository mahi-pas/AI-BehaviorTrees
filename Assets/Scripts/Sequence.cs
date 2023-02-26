using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    //Constructor
    public Sequence(string n){
        name  = n;
    }

    //Methods
    public override Status Process(){
        Status childStatus = children[currentChild].Process();
        if(childStatus == Status.RUNNING) return Status.RUNNING;
        if(childStatus == Status.FAILURE) return childStatus;
        
        //if successful
        currentChild++;
        if(currentChild>= children.Count){ //if finished all children in sequence
            currentChild = 0;
            return Status.SUCCESS;
        }

        return Status.RUNNING;
    }
}
