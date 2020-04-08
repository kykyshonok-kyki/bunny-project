//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	private const float	secondActionScale = 0.85f;
	private const float deadzoneScale = 0.25f;

	private Image	joystick;
	private Image	jPoint;
	private Vector2	inputVector;
	private float	JPointPos;

	private void	Start()
	{
		joystick = GetComponent<Image>();
		jPoint = transform.GetChild(1).GetComponent<Image>();
		transform.GetChild(0).GetComponent<Image>().rectTransform.localScale = new Vector2(secondActionScale, secondActionScale);
	}

	public void		OnDrag(PointerEventData eventData)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
		{
			pos.x = pos.x / joystick.rectTransform.sizeDelta.x;
			pos.y = pos.y / joystick.rectTransform.sizeDelta.y;
			inputVector.x = pos.x * 2 - 1;
			inputVector.y = pos.y * 2 - 1;

			if (inputVector.magnitude > 1)
				inputVector = inputVector.normalized;
			jPoint.rectTransform.anchoredPosition = new Vector2 (inputVector.x * joystick.rectTransform.sizeDelta.x / 2, inputVector.y * joystick.rectTransform.sizeDelta.y / 2);
			if (inputVector.magnitude < deadzoneScale)
				JPointPos = 0;
			else if (inputVector.magnitude < secondActionScale)
				JPointPos = 1;
			else
				JPointPos = 2;
			inputVector = inputVector.normalized;
		}
	}

	public void		OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
	}

	public void		OnPointerUp(PointerEventData eventData)
	{
		inputVector = Vector2.zero;
		jPoint.rectTransform.anchoredPosition = inputVector;
	}

	public float	GetJPointPos()
	{
		return (JPointPos);
	}

	public Vector2	GetVector()
	{
		return (inputVector);
	}
}
