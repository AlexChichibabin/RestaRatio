using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    [SerializeField] private CharacterMovement m_TargetCharacterMovement;
    [SerializeField] private ThirdPersonCamera m_TargetCamera;

    [SerializeField] private Vector3 m_AimingOffset;

    [SerializeField] private Vector3 DefaultOffset;

	public InputAction move;

	void OnEnable() => move.Enable();
	void OnDisable() => move.Disable();

	private void Start()
    {
        LockMouse();
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void UnLockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
		m_TargetCharacterMovement.TargetDirectionControl = move.ReadValue<Vector2>();
		
        //m_TargetCamera.RotationControl = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (m_TargetCharacterMovement.TargetDirectionControl != Vector3.zero || m_TargetCharacterMovement.IsAiming == true)
        {
            m_TargetCamera.IsRotateTarget = true;
        }
        else m_TargetCamera.IsRotateTarget = false;
        Debug.Log(move.ReadValue<Vector2>());

        /*if (Input.GetButtonDown("Jump"))
            m_TargetCharacterMovement.Jump();

        if (Input.GetKey(KeyCode.LeftControl)) m_TargetCharacterMovement.Crouch();
        else m_TargetCharacterMovement.UnCrouch();

        if (Input.GetKey(KeyCode.LeftShift)) m_TargetCharacterMovement.Sprint();
        if (Input.GetKeyUp(KeyCode.LeftShift)) m_TargetCharacterMovement.UnSprint();

        if (Input.GetMouseButton(1))
        {
            m_TargetCharacterMovement.Aiming();
            m_TargetCamera.SetTargetOffset(m_AimingOffset);
            m_TargetCamera.SetFov(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            m_TargetCharacterMovement.UnAiming();
            m_TargetCamera.SetDefaultOffset();
            m_TargetCamera.SetFov(false);
        }*/
    }
    public void AssignCamera(ThirdPersonCamera camera)
    {
        m_TargetCamera = camera;
        m_TargetCamera.IsRotateTarget = false;
        m_TargetCamera.SetTargetOffset(DefaultOffset);
        m_TargetCamera.SetTarget(m_TargetCharacterMovement.transform);
    }
}
