using UnityEngine;
using UnityEngine.UI;

public class FunctionActivations : MonoBehaviour
{
    [Header("OBJ Scripts")]
    public BoomerJointControl feedRotationLeft;
    public BoomerJointControl feedRotationRight;
    public BoomerJointControl feedLookoutLeft;
    public BoomerJointControl feedLookoutRight;

    public BoomerJointControl boomLeftRotL;
    public BoomerJointControl boomUpRotL;
    public BoomerJointControl boomRotL;
    public BoomerJointControl boomRotDownL;

    public BoomerJointControl boomRightRotR;
    public BoomerJointControl boomUpRotR;
    public BoomerJointControl boomRotR;
    public BoomerJointControl boomDownRotR;

    public BoomerSlide boomExtensionLeft;
    public BoomerSlide boomExtensionRight;
    public BoomerSlide feedExtensionLeft;
    public BoomerSlide feedExtensionRight;

    public Sprite activeImage;
    public Sprite deactivatedImage;
    

    [Header("Images")]
    public Image leftArmInd;
    public Image rightArmInd;
    public Image antiParallelImageL;
    public Image antiParallelImageR;
    public Image[] feedRotate;
    public Image[] feedExtension;
    public Image[] boomExtension;
    public Image[] feedLookout;

    private bool antiParallel;
    public bool antiParallelR;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LeverFunctions();
        FeedRotation();
        FeedExtension();
        BoomExtension();
        FeedLookout();
        BoomPositionL();
        BoomPositionR();
    }

    void FeedExtension()
    {
        if (Input.GetKey(KeyCode.E) && feedExtensionLeft.leftArm == true)
        {
            feedExtensionLeft.MoveZ(1);
        }
        if (Input.GetKey(KeyCode.R) && feedExtensionLeft.leftArm == true)
        {
            feedExtensionLeft.MoveZ(-1);
        }

        if (Input.GetKey(KeyCode.U) && feedExtensionRight.rightArm == true)
        {
            feedExtensionRight.MoveZ(1);
        }
        if (Input.GetKey(KeyCode.I) && feedExtensionRight.rightArm == true)
        {
            feedExtensionRight.MoveZ(-1);
        }

        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.R))
        {
            feedExtension[0].color = Color.white;
        }
        else
        {
            feedExtension[0].color = Color.red;
        }

        if (Input.GetKey(KeyCode.U) || Input.GetKey(KeyCode.I))
        {
            feedExtension[1].color = Color.white;
        }
        else
        {
            feedExtension[1].color = Color.red;
        }
    }

    void BoomExtension()
    {
        if (Input.GetKey(KeyCode.A) && boomExtensionLeft.leftArm == true)
        {
            boomExtensionLeft.MoveZ(1);
        }
        if (Input.GetKey(KeyCode.S) && boomExtensionLeft.leftArm == true)
        {
            boomExtensionLeft.MoveZ(-1);
        }

        if (Input.GetKey(KeyCode.L) && boomExtensionRight.rightArm == true)
        {
            boomExtensionRight.MoveZ(1);
        }
        if (Input.GetKey(KeyCode.K) && boomExtensionRight.rightArm == true)
        {
            boomExtensionRight.MoveZ(-1);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            boomExtension[0].color = Color.gray;
        }
        else
        {
            boomExtension[0].color = Color.white;
        }

        if (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.K))
        {
            boomExtension[1].color = Color.gray;
        }
        else
        {
            boomExtension[1].color = Color.white;
        }
    }

    void FeedRotation()
    {
        if (Input.GetKey(KeyCode.Q) && feedRotationLeft.leftArm == true) // Rotates towards the left direction
        {
            feedRotationLeft.RotationY(1);
        }

        if (Input.GetKey(KeyCode.W) && feedRotationLeft.leftArm == true) // Rotates towards the right direction
        {
            feedRotationLeft.RotationY(-1);
        }

        if (Input.GetKey(KeyCode.P) && feedRotationRight.rightArm == true) // Rotates towards the right direction
        {
            feedRotationRight.RotationY(-1);
        }

        if (Input.GetKey(KeyCode.O) && feedRotationRight.rightArm == true) // Rotates towards the left direction
        {
            feedRotationRight.RotationY(1);
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W))
        {
            feedRotate[0].color = Color.white;
        }
        else
        {
            feedRotate[0].color = Color.green;
        }

        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.O))
        {
            feedRotate[1].color = Color.white;
        }
        else
        {
            feedRotate[1].color = Color.green;
        }

    }

    void FeedLookout()
    {
        if (Input.GetKey(KeyCode.D) && feedLookoutLeft.leftArm == true) // Rotates towards the left direction
        {
            feedLookoutLeft.RotationX(1);
        }

        if (Input.GetKey(KeyCode.F) && feedLookoutLeft.leftArm == true) // Rotates towards the right direction
        {
            feedLookoutLeft.RotationX(-1);
        }

        if (Input.GetKey(KeyCode.H) && feedLookoutRight.rightArm == true) // Rotates towards the right direction
        {
            feedLookoutRight.RotationX(-1);
        }

        if (Input.GetKey(KeyCode.J) && feedLookoutRight.rightArm == true) // Rotates towards the left direction
        {
            feedLookoutRight.RotationX(1);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F))
        {
            feedLookout[0].color = Color.white;
        }
        else
        {
            feedLookout[0].color = Color.blue;
        }

        if (Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.J))
        {
            feedLookout[1].color = Color.white;
        }
        else
        {
            feedLookout[1].color = Color.blue;
        }
    }

    void BoomPositionL()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            antiParallel = true;
            antiParallelImageL.sprite = activeImage;
        }
        if (antiParallel && Input.GetKeyUp(KeyCode.Tab))
        {
            antiParallel = false;
            antiParallelImageL.sprite = deactivatedImage;
        }

        if (antiParallel == true)
        {
            if (Input.GetKey(KeyCode.Z) && boomRotL.leftArm == true && boomRotL.yDir == true)
            {
                boomRotL.RotationY(-1);
            }
            if (Input.GetKey(KeyCode.X) && boomRotL.leftArm == true && boomRotL.yDir == true)
            {
                boomRotL.RotationY(1);
            }
            if (Input.GetKey(KeyCode.C) && boomRotDownL.leftArm == true && boomRotDownL.xDir == true)
            {
                boomRotDownL.RotationX(-1);
            }
            if (Input.GetKey(KeyCode.V) && boomRotDownL.leftArm == true && boomRotDownL.xDir == true)
            {
                boomRotDownL.RotationX(1);
            }
        }
        else if (antiParallel == false)
        {
            if (Input.GetKey(KeyCode.Z) && boomLeftRotL.leftArm == true && boomLeftRotL.yDir == true)
            {
                boomLeftRotL.RotationY(-1);
            }
            if (Input.GetKey(KeyCode.X) && boomLeftRotL.leftArm == true && boomLeftRotL.yDir == true)
            {
                boomLeftRotL.RotationY(1);
            }
            if (Input.GetKey(KeyCode.C) && boomUpRotL.leftArm == true && boomUpRotL.xDir == true)
            {
                boomUpRotL.RotationX(-1);
            }
            if (Input.GetKey(KeyCode.V) && boomUpRotL.leftArm == true && boomUpRotL.xDir == true)
            {
                boomUpRotL.RotationX(1);
            }
        }
    }

    void BoomPositionR()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            antiParallelR = true;
            antiParallelImageR.sprite = activeImage;
        }
        if (antiParallelR && Input.GetKey(KeyCode.UpArrow))
        {
            antiParallelR = false;
            antiParallelImageR.sprite = deactivatedImage;
        }

        if (antiParallelR == true)
        {
            if (Input.GetKey(KeyCode.B) && boomRotR.rightArm == true && boomRotR.yDir == true)
            {
                boomRotR.RotationY(-1);
            }
            if (Input.GetKey(KeyCode.N) && boomRotR.rightArm == true && boomRotR.yDir == true)
            {
                boomRotR.RotationY(1);
            }
            if (Input.GetKey(KeyCode.M) && boomDownRotR.rightArm == true && boomDownRotR.xDir == true)
            {
                boomDownRotR.RotationX(-1);
            }
            if (Input.GetKey(KeyCode.RightAlt) && boomDownRotR.rightArm == true && boomDownRotR.xDir == true)
            {
                boomDownRotR.RotationX(1);
            }
        }
        else if (antiParallelR == false)
        {
            if (Input.GetKey(KeyCode.B) && boomRightRotR.rightArm == true && boomRightRotR.yDir == true)
            {
                boomRightRotR.RotationY(-1);
            }
            if (Input.GetKey(KeyCode.N) && boomRightRotR.rightArm == true && boomRightRotR.yDir == true)
            {
                boomRightRotR.RotationY(1);
            }
            if (Input.GetKey(KeyCode.M) && boomUpRotR.rightArm == true && boomUpRotR.xDir == true)
            {
                boomUpRotR.RotationX(-1);
            }
            if (Input.GetKey(KeyCode.RightAlt) && boomUpRotR.rightArm == true && boomUpRotR.xDir == true)
            {
                boomUpRotR.RotationX(1);
            }
        }
    }

    public void LeverFunctions()
    {
        #region Mouse Press
        if (Input.GetMouseButtonDown(0))
        {
            leftArmInd.sprite = activeImage;
            rightArmInd.sprite = deactivatedImage;
        }

        if (Input.GetMouseButtonDown(1))
        {
            rightArmInd.sprite = activeImage;
            leftArmInd.sprite = deactivatedImage;
            //This must also activate the ui for the letters that will be used.
        }
        #endregion

        #region Feed Rotation

        #endregion
    }
}
