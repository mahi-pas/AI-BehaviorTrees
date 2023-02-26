using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    public delegate Status Tick();
    public Tick ProcessMethod;

    //Constructors
    public Leaf() {}

    public Leaf(string n, Tick pm){
        name = n;
        ProcessMethod = pm;
    }

    //Methods
    public override Status Process(){
        if(ProcessMethod != null)
            return ProcessMethod();
        return Status.FAILURE;
    }

}
