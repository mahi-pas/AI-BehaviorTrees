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

    public enum ActionState {IDLE, RUNNING};
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    // Start is called before the first frame update
    void Start()
    {
        agent  = GetComponent<NavMeshAgent>();

        tree = new BehaviorTree();
        Sequence steal = new Sequence("Steal object");
        Leaf goToDiamond =  new Leaf("Go To Diamond", GoToDiamond);
        Leaf goToVan = new Leaf("Go To Van", GoToVan);

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        tree.PrintTree();
    }
    // Update is called once per frame
    void Update()
    {
        if(treeStatus == Node.Status.RUNNING){
            treeStatus = tree.Process();
        }
    }

    //Methods
    public Node.Status GoToDiamond(){
        return GoToLocation(diamond.position);
    }

    public Node.Status GoToVan(){
        return GoToLocation(van.position);
    }

    Node.Status GoToLocation(Vector3 destination){
        float dist = Vector3.Distance(destination, transform.position);

        if(state == ActionState.IDLE){
            agent.SetDestination(destination);
            state = ActionState.RUNNING;
        }
        else if(Vector3.Distance(agent.pathEndPosition, destination) >= 2){
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (dist < 2){
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

}
