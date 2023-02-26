using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{   
    public string name;
    public enum Status {SUCCESS, RUNNING, FAILURE};
    public Status status;
    public List<Node> children = new List<Node>();
    public int currentChild = 0;

    //constructors
    public Node() {}
    public Node(string n){
        name = n;
    }

    //methods
    public void AddChild(Node n){
        children.Add(n);
    }

    public virtual Status Process(){
        return Status.SUCCESS;
    }

}
