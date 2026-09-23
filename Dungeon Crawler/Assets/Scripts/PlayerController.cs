using Unity.Mathematics;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool skipMove = false;
    public float moveSpeed = 10f;
    public float rotationSpeed = 500f;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetGridPos = Vector3Int.RoundToInt(transform.position);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (true)
        {
            prevTargetGridPos = targetGridPos;

            Vector3 targetPosition = targetGridPos;

            if((targetRotation.y > 270f) &&  (targetRotation.y < 361f)) targetRotation.y = 0f;
            if(targetRotation.y < 0f) targetRotation.y = 270f;

            if (!skipMove)
            {
                transform.position = targetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
            else
            {
                transform.position = Vector3.MoveTowards(
                    transform.position, targetPosition, Time.deltaTime * moveSpeed);
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);
            }
        } else
        {
            targetGridPos = prevTargetGridPos;
        }
    }

    public void RotateLeft() { if (AtRest) targetRotation -= Vector3.up * 90f; }
    public void RotateRight() { if (AtRest) targetRotation += Vector3.up * 90f; }
    public void MoveForward() { if (AtRest) targetGridPos += transform.forward; }
    public void MoveBack() { if (AtRest) targetGridPos -= transform.forward; }
    public void MoveLeft() { if (AtRest) targetGridPos -= transform.right; }
    public void MoveRight() { if (AtRest) targetGridPos += transform.right; }

    bool AtRest {
        get{
            if((Vector3.Distance(transform.position, targetGridPos) < 0.05f) && 
                (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f)){
                    return true;
            }
            else
            {
                return false;
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
