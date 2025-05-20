using UnityEngine;

public class BoomerSlide : MonoBehaviour
{
    public Transform moveObject;
    //public ObjFunction _objFunction;
    public FunctionActivations _activation;

    public float moveSpeed;

    public GameObject pivot;

    public float minOffset = -1f;
    public float maxOffset = 1f;

    private float currentOffset = 0f;

    public bool xDir;
    public bool yDir;
    public bool zDir;
    public bool rightArm;
    public bool leftArm;

    private void Update()
    {
        if ((xDir || yDir || zDir) && (leftArm || rightArm))
        {
            //_objFunction.SlideFunction();
        }
    }

    public void MoveX(float direction)
    {
        float delta = moveSpeed * Time.deltaTime * direction;
        float nextOffset = currentOffset + delta;

        if (nextOffset >= minOffset && nextOffset <= maxOffset)
        {
            Vector3 moveDir = pivot.transform.right;
            moveObject.position += moveDir * delta;
            currentOffset = nextOffset;
        }
    }

    public void MoveY(float direction)
    {
        float delta = moveSpeed * Time.deltaTime * direction;
        float nextOffset = currentOffset + delta;

        if (nextOffset >= minOffset && nextOffset <= maxOffset)
        {
            Vector3 moveDir = pivot.transform.up;
            moveObject.position += moveDir * delta;
            currentOffset = nextOffset;
        }
    }

    public void MoveZ(float direction)
    {
        float delta = moveSpeed * Time.deltaTime * direction;
        float nextOffset = currentOffset + delta;

        if (nextOffset >= minOffset && nextOffset <= maxOffset)
        {
            Vector3 moveDir = pivot.transform.forward;
            moveObject.position += moveDir * delta;
            currentOffset = nextOffset;
        }
    }

}
