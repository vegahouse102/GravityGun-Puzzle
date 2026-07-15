using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputGetter: MonoBehaviour
{
	public PlayerInput Input { get;private set; }

	private void Awake()
	{
		Input = new PlayerInput();
	}

	private void OnEnable()
	{
		Input.Enable();
	}

	private void OnDisable()
	{
		Input.Disable();
	}

	//private void Update()
	//{
	//	Vector2 move = Input.Player.Move.ReadValue<Vector2>();

	//	if (Input.Player.Jump.WasPressedThisFrame())
	//	{
			
	//	}

	//	if (Input.Player.Grab.IsPressed())
	//	{
			
	//	}

	//	if (Input.Player.Fire.WasPressedThisFrame())
	//	{
			
	//	}
	//}

}
