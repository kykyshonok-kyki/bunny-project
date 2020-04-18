//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class DoorController : MonoBehaviour
{
	public int doorState;       //0 - закрыта, -1 - открыта влево или вниз, 1 - открыта вправо или вверх

	private float doorDefPos;

	private void Start()
	{
		if (doorState > 1)
			doorState = 1;
		else if (doorState < -1)
			doorState = -1;
		doorDefPos = transform.rotation.eulerAngles.z;
	}

	public void OpenDoor(Vector2 playerPos)
	{
		if (doorDefPos == 0)			//Вертикальная дверь с петлями сверху
		{
			if (playerPos.x > transform.position.x)
			{
				transform.Rotate(new Vector3(0, 0, -90));
				doorState = -1;
			}
			else
			{
				transform.Rotate(new Vector3(0, 0, 90));
				doorState = 1;
			}
		}
		else if (doorDefPos == 180)		//Вертикальная дверь с петлями снизу
		{
			if (playerPos.x > transform.position.x)
			{
				transform.Rotate(new Vector3(0, 0, 90));
				doorState = -1;
			}
			else
			{
				transform.Rotate(new Vector3(0, 0, -90));
				doorState = 1;
			}
		}
		else if (doorDefPos == 90)		//Горизонтальная дверь с петлями слева
		{
			if (playerPos.y > transform.position.y)
			{
				transform.Rotate(new Vector3(0, 0, -90));
				doorState = -1;
			}
			else
			{
				transform.Rotate(new Vector3(0, 0, 90));
				doorState = 1;
			}
		}
		else						     //Горизонтальная дверь с петлями справа
		{
			if (playerPos.y > transform.position.y)
			{
				transform.Rotate(new Vector3(0, 0, 90));
				doorState = -1;
			}
			else
			{
				transform.Rotate(new Vector3(0, 0, -90));
				doorState = 1;
			}
		}
	}

	public void CloseDoor()
	{
		transform.rotation = Quaternion.Euler(0, 0, doorDefPos);
		doorState = 0;
	}
}
