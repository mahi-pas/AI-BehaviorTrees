using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehavior : MonoBehaviour
{
    BehaviorTree tree;
    NavMeshAgent agent;
    public Transform diamond;
    public Transform van;

    // Start is called before the first frame update
    void Start()
    {
        agent  = GetComponent<NavMeshAgent>();

        tree = new BehaviorTree();
        Node steal = new Node("Steal object");
        Leaf goToDiamond =  new Leaf("Go To Diamond", GoToDiamond);
        Leaf goToVan = new Leaf("Go To Van", GoToVan);

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        tree.PrintTree();

        tree.Process();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //Methods
    public Node.Status GoToDiamond(){
        agent.SetDestination(diamond.position);
        return Node.Status.SUCCESS;
    }

    public Node.Status GoToVan(){
        agent.SetDestination(van.position);
        return Node.Status.SUCCESS;
    }
}
