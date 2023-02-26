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
        Node goToDiamond =  new Node("Go To Diamond");
        Node goToVan = new Node("Go To Van");

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        tree.PrintTree();

        agent.SetDestination(diamond.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
