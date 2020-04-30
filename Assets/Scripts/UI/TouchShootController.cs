//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.EventSystems;

public class TouchShootController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	private Vector2 lookVector;
	private bool isWork;

	private void Start()
	{
		isWork = false;
		lookVector = new Vector2(0, 0);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (isWork)
		{
			lookVector = eventData.pointerCurrentRaycast.screenPosition - new Vector2(Screen.width / 2, Screen.height / 2);
			lookVector = lookVector.normalized;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		lookVector = new Vector2(0, 0);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		string objectName = eventData.pointerCurrentRaycast.gameObject.name;

		if (objectName != "MoveJoystick" & objectName != "CharactersList" & objectName != "Action" & objectName != "MainMenu" & objectName != "ShootToggle")
		{
			isWork = true;
			OnDrag(eventData);
		}
	}

	public Vector2 GetVector()
	{
		return lookVector;
	}
}
