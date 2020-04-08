//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class MoveController : MonoBehaviour
{
	public Camera	camera;

	private JoystickController	jContr;

	private void	Start()
	{
		jContr = GameObject.FindGameObjectWithTag("MoveController").GetComponent<JoystickController>();
	}

	private void	Update()
	{
		CharacterMove();
	}

	private void	CharacterMove()
	{
		float	curSpeed = jContr.GetJPointPos();
		Vector2 inputVector = jContr.GetVector();
		Vector2	newPos;

		if (inputVector.magnitude != 0 & curSpeed != 0)
		{
			if (curSpeed == 1)
				curSpeed = 2;
			else
				curSpeed = 6;
			curSpeed *= Time.deltaTime;
			newPos = new Vector2(transform.position.x + inputVector.x * curSpeed, transform.position.y + inputVector.y * curSpeed);
			transform.position = newPos;
			camera.transform.position = newPos;
		}
	}
}
