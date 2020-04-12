//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class MoveController : MonoBehaviour
{
	private JoystickController jContr;

	public Camera cam;
	public GameObject healthBar;
	public float walkSpeed;
	public float runSpeed;
	private Vector2 inputVector;

	private void Start()
	{
		jContr = GameObject.FindGameObjectWithTag("MoveController").GetComponent<JoystickController>();
	}

	private void Update()
	{
		inputVector = jContr.GetVector();
	}

	private void FixedUpdate()
	{
		CharacterMove();
	}

	private void LateUpdate()
	{
		cam.GetComponent<Transform>().position = transform.position;
		healthBar.GetComponent<Transform>().position = new Vector2(transform.position.x, transform.position.y + 0.7f);
	}

	public void ChangePositionsBeforeClose()
	{
		LateUpdate();
	}

	private void CharacterMove()
	{
		float curSpeed = jContr.GetJPointLevel();

		if (curSpeed == 1)
			curSpeed = walkSpeed;
		else if (curSpeed == 2)
			curSpeed = runSpeed;
		GetComponent<Rigidbody2D>().velocity = inputVector * curSpeed;
	}
}
