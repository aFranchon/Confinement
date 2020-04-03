using UnityEngine;

public class CameraNotClickedState : CameraBaseState
{
    public override void EnterState(CameraController camera)
    {
        camera.ChangeCursorVisibility(true);
    }

    public override void LateUpdate(CameraController camera)
    {
        if (Input.GetAxis("Fire1") >= 0.1f)
        {
            camera.TransitionToState(camera.cameraClickedState);
        }
    }
}
