using UnityEngine;

public class MoveController : MonoBehaviour
{
	private JoystickController	jContr;

	public Transform playerTr;

	void Start()
	{
		playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		jContr = GameObject.FindGameObjectWithTag("MoveController").GetComponent<JoystickController>();
	}

	private void Update()
	{
		CharacterMove();
	}

	public void CharacterMove()
	{
		float	curSpeed = jContr.GetSpeed();
		Vector2 inputVector = jContr.GetVector();

		if (inputVector.magnitude != 0)
		{
			curSpeed *= Time.deltaTime;
			playerTr.position = new Vector2(playerTr.position.x + inputVector.x * curSpeed, playerTr.position.y + inputVector.y * curSpeed);
		}
	}
}
