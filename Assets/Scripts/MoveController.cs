//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class MoveController : MonoBehaviour
{
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

		if (inputVector.magnitude != 0 & curSpeed != 0)
		{
			if (curSpeed == 1)
				curSpeed = 2;
			else
				curSpeed = 6;
			curSpeed *= Time.deltaTime;
			transform.position = new Vector2(transform.position.x + inputVector.x * curSpeed, transform.position.y + inputVector.y * curSpeed);
		}
	}
}
