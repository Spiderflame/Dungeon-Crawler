using Unity.Mathematics;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool skipMove = false;//Set to true for sprinting
    public float moveSpeed = 10f;
    public float rotationSpeed = 500f;

    Vector3 targetGridPos;//Next Position
    Vector3 currGridPos;//Current position
    Vector3 targetRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currGridPos = Vector3Int.RoundToInt(transform.position);
        targetGridPos = currGridPos;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (!WallInTarget)
        {
            currGridPos = targetGridPos;
        } else
        {
            targetGridPos = currGridPos;
        }

        if((targetRotation.y > 270f) && (targetRotation.y < 361f)) {targetRotation.y = 0f;}
        if(targetRotation.y < 0f) {targetRotation.y = 270f;}

        if (skipMove)
        {
            transform.position = targetGridPos;
            transform.rotation = Quaternion.Euler(targetRotation);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetGridPos, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);
        }
    }

    bool WallInTarget
    {
        //Gets true or false based on if there is an object in front of the player and if that target is a wall
        get
        {
            Collider[] hits = Physics.OverlapSphere(targetGridPos, 0.2f);//finds objects within target position

            foreach (Collider hit in hits)
            {
                BaseObject obj = hit.GetComponentInParent<BaseObject>();

                if (obj != null && obj.wall)
                {
                    return true;
                }
            }
            
            return false;
        }
    }

    #region Player Move Functions
    public void RotateLeft() { if (AtRest) targetRotation -= Vector3.up * 90f; }
    public void RotateRight() { if (AtRest) targetRotation += Vector3.up * 90f; }
    public void MoveForward() { if (AtRest) targetGridPos += transform.forward; }
    public void MoveBack() { if (AtRest) targetGridPos -= transform.forward; }
    public void MoveLeft() { if (AtRest) targetGridPos -= transform.right; }
    public void MoveRight() { if (AtRest) targetGridPos += transform.right; }
    public void Run() {skipMove = true;}
    public void Slow() {skipMove = false;}
    #endregion

    //Checks if still moving or not
    bool AtRest {
        get{
            if((Vector3.Distance(transform.position, targetGridPos) < 0.05f) && (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f)){
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
