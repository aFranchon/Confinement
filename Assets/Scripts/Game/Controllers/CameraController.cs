using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Fields
    public float dragSpeed = 50;
    #endregion

    #region Finite State Machine
    private CameraBaseState currentState;

    public CameraBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly CameraClickedState cameraClickedState = new CameraClickedState();
    public readonly CameraNotClickedState cameraNotClickedState = new CameraNotClickedState();

    public void TransitionToState(CameraBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    #endregion

    #region Starting Object
    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(cameraNotClickedState);
    }
    #endregion

    #region Repetitive Methods
    // Update is called once per frame
    void LateUpdate()
    {
        currentState.LateUpdate(this);
    }
    #endregion

    #region Cursor Handling
    public void ChangeCursorVisibility(bool setVisible)
    {
        Cursor.visible = setVisible;
    }
    #endregion
}
