using UnityEngine;

public abstract class CameraBaseState
{
    public abstract void EnterState(CameraController camera);

    public abstract void LateUpdate(CameraController camera);
}
