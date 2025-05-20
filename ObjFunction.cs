using UnityEngine;

public class ObjFunction : MonoBehaviour
{
    //I will add functionality for using the keyboard instead of the vr headset.
    public BoomerJointControl _controller;
    public BoomerSlide _boomerSlide;

    private bool xAxis;
    private bool yAxis;
    private bool zAxis;

    public void ButtonFunctions()
    {
        if (_controller.yDir && _controller.leftArm == true || _controller.yDir && _controller.rightArm == true)
        {
            if (Input.GetKey(KeyCode.Q) && _controller.leftArm || Input.GetKey(KeyCode.E) && _controller.rightArm)
            {
                yAxis = true;
                if (yAxis)
                {
                    _controller.RotationY(1);
                }
            }
            else if (Input.GetKey(KeyCode.W) && _controller.leftArm|| Input.GetKey(KeyCode.R) && _controller.rightArm)
            {
                yAxis = true;
                if (yAxis)
                {
                    _controller.RotationY(-1);
                }
            }
            else
            {
                yAxis = false;
            }
        }

        if (_controller.xDir == true && _controller.leftArm == true || _controller.xDir && _controller.rightArm == true)
        {
            if (Input.GetKey(KeyCode.T) && _controller.leftArm || Input.GetKey(KeyCode.U) && _controller.rightArm)
            {
                xAxis = true;
                if (xAxis)
                {
                    _controller.RotationX(1);
                }
            }
            else if (Input.GetKey(KeyCode.Y) && _controller.leftArm || Input.GetKey(KeyCode.I) && _controller.rightArm)
            {
                xAxis = true;
                if (xAxis)
                {
                    _controller.RotationX(-1);
                }
            }
            else
            {
                xAxis = false;
            }
        }

        if (_controller.zDir == true && _controller.leftArm == true || _controller.zDir && _controller.rightArm == true)
        {
            if (Input.GetKey(KeyCode.O) && _controller.leftArm || Input.GetKey(KeyCode.A) && _controller.rightArm)
            {
                zAxis = true;
                if (zAxis)
                    _controller.RotationZ(1);
            }
            else if (Input.GetKey(KeyCode.P) && _controller.leftArm || Input.GetKey(KeyCode.S) && _controller.rightArm)
            {
                zAxis = true;
                if (zAxis)
                    _controller.RotationZ(-1);
            }
            else
            {
                zAxis = false;
            }
        }
    }

    public void SlideFunction()
    {
        if (_boomerSlide.zDir == true && _boomerSlide.leftArm == true || _boomerSlide.zDir && _boomerSlide.rightArm == true)
        {
            if (Input.GetKey(KeyCode.D) && _boomerSlide.leftArm || Input.GetKey(KeyCode.G) && _boomerSlide.rightArm)
            {
                zAxis = true;
                if (zAxis)
                    _boomerSlide.MoveZ(1);
            }
            else if (Input.GetKey(KeyCode.F) && _boomerSlide.leftArm || Input.GetKey(KeyCode.H) && _boomerSlide.rightArm)
            {
                zAxis = true;
                if (zAxis)
                    _boomerSlide.MoveZ(-1);
            }
            else
            {
                zAxis = false;
            }
        }

        if (_boomerSlide.xDir == true && _boomerSlide.leftArm == true || _boomerSlide.xDir && _boomerSlide.rightArm == true)
        {
            if (Input.GetKey(KeyCode.J) && _boomerSlide.leftArm || Input.GetKey(KeyCode.Z) && _boomerSlide.rightArm)
            {
                xAxis = true;
                if (xAxis)
                    _boomerSlide.MoveX(1);
            }
            else if (Input.GetKey(KeyCode.K) && _boomerSlide.leftArm || Input.GetKey(KeyCode.X) && _boomerSlide.rightArm)
            {
                xAxis = true;
                if (xAxis)
                    _boomerSlide.MoveX(-1);
            }
            else
            {
                xAxis = false;
            }
        }

        if (_boomerSlide.yDir == true && _boomerSlide.leftArm == true || _boomerSlide.yDir && _boomerSlide.rightArm == true)
        {
            if (Input.GetKey(KeyCode.C) && _boomerSlide.leftArm || Input.GetKey(KeyCode.B) && _boomerSlide.rightArm)
            {
                yAxis = true;
                if (yAxis)
                    _boomerSlide.MoveY(1);
            }
            else if (Input.GetKey(KeyCode.V) && _boomerSlide.leftArm || Input.GetKey(KeyCode.N) && _boomerSlide.rightArm)
            {
                yAxis = true;
                if (yAxis)
                    _boomerSlide.MoveY(-1);
            }
            else
            {
                yAxis = false;
            }
        }
    }
}
