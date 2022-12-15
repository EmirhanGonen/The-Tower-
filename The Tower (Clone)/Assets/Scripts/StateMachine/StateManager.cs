using UnityEngine;


public class StateManager : MonoBehaviour
{
    public static StateManager Instance { get; private set; }

    public State currentState;

    public ObstacleData data;

    private void Awake()
    {
        Instance = this;
        data = new()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform
        };
    }

    private void Update()
    {
        //State nextState = currentState.RunCurrentState();

       // if (nextState) SwitchToTheNextState(nextState);
    }
    private void SwitchToTheNextState(State nextState) => currentState = nextState;
}