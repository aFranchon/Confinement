using UnityEngine;

public class CameraClickedState : CameraBaseState
{
    public override void EnterState(CameraController camera)
    {
        camera.ChangeCursorVisibility(false);
    }

    public override void LateUpdate(CameraController camera)
    {
        if (Input.GetAxis("Fire1") == 0)
        {
            camera.TransitionToState(camera.cameraNotClickedState);
        }

        var lastPosition = camera.transform.position;

        float speed = camera.dragSpeed * Time.deltaTime;
        Camera.main.transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed, 0, Input.GetAxis("Mouse Y") * speed);

        if  (    
                camera.transform.position.x > 100 || camera.transform.position.x < -100 ||
                camera.transform.position.z > 100 || camera.transform.position.z < -100
            )
        {
            camera.transform.position = lastPosition;
        }
    }

}
