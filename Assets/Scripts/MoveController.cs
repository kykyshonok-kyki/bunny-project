//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class MoveController : MonoBehaviour
{
	public Camera	cam;

	private JoystickController	jContr;

	private void	Start()
	{
		jContr = GameObject.FindGameObjectWithTag("MoveController").GetComponent<JoystickController>();
	}

	private void	FixedUpdate()
	{
		CharacterMove();
	}

	private void	LateUpdate()
	{
		cam.GetComponent<Transform>().position = transform.position;
	}

	private void	CharacterMove()
	{
		float	curSpeed = jContr.GetJPointLevel();
		Vector2 inputVector = jContr.GetVector();

		if (curSpeed == 1)
			curSpeed = 2;
		else if (curSpeed == 2)
			curSpeed = 6;
		GetComponent<Rigidbody2D>().velocity = inputVector * curSpeed;
	}
}
