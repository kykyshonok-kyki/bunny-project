using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick_move : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	public Transform	playerTr;
	private Image		joystick;
	private Image		jPoint;
	private Vector2		inputVector;

	private float	speed;

	private void Start()
	{
		playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		joystick = GetComponent<Image>();
		jPoint = transform.GetChild(0).GetComponent<Image>();
	}

	private void Update()
	{
		CharacterMove();
	}

	public void OnDrag(PointerEventData eventData)
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
			if (inputVector.magnitude < 0.1)
				speed = 0;
			else if (inputVector.magnitude < 0.9)
				speed = 2;
			else
				speed = 6;
			inputVector = inputVector.normalized;
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		inputVector = Vector2.zero;
		jPoint.rectTransform.anchoredPosition = inputVector;
	}

	public void CharacterMove()
	{
		float	curSpeed;

		if (inputVector.magnitude != 0)
		{
			curSpeed = speed * Time.deltaTime;
			playerTr.position = new Vector2(playerTr.position.x + inputVector.x * curSpeed, playerTr.position.y + inputVector.y * curSpeed);
		}
	}
}