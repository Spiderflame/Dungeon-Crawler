using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode turnLeft = KeyCode.Q;
    public KeyCode turnRight = KeyCode.E;
    public KeyCode run = KeyCode.LeftShift;
    public bool canMove = true;
    
    PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(canMove){
            if (Input.GetKeyUp(forward)) controller.MoveForward();
            if (Input.GetKeyUp(back)) controller.MoveBack();
            if (Input.GetKeyUp(left)) controller.MoveLeft();
            if (Input.GetKeyUp(right)) controller.MoveRight();
            if (Input.GetKeyUp(turnLeft)) controller.RotateLeft();
            if (Input.GetKeyUp(turnRight)) controller.RotateRight();
            if (Input.GetKey(run))
            { 
                controller.Run();
            }
            else
            {
                controller.Slow();
            }
        }
    }
}
