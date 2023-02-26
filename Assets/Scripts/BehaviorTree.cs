using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : Node
{
    //Constructors
    public BehaviorTree(){
        name = "Tree";
    }

    public BehaviorTree(string n){
        name = n;
    }

    //Methods
    public override Status Process(){
        return children[currentChild].Process();
    }

    //Printing
    struct NodeLevel{
        public int level;
        public Node node;
    }

    public void PrintTree(){
        string output = "";
        Stack<NodeLevel> nodes = new Stack<NodeLevel>();
        Node cur = this;
        nodes.Push(new NodeLevel{level = 0, node = cur} );

        while(nodes.Count != 0){
            NodeLevel next = nodes.Pop();
            output += new string('-',next.level) + next.node.name + "\n";
            for(int i = next.node.children.Count-1; i>=0; i--){
                nodes.Push(new NodeLevel{level = next.level+1, node = next.node.children[i]});

            }
        }

        Debug.Log(output);

    }

}
