using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick_move : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	public Transform	player;
	private Image		joystick;
	private Image		jPoint;
	private Vector2		inputVector;

	private void Start()
	{
		joystick = GetComponent<Image>();
		jPoint = transform.GetChild(0).GetComponent<Image>();
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
		{
			pos.x = pos.x / joystick.rectTransform.sizeDelta.x;
			pos.y = pos.y / joystick.rectTransform.sizeDelta.y;
			Debug.Log(pos);
			inputVector.x = pos.x * 2 - 1;
			inputVector.y = pos.y * 2 - 1;

			if (inputVector.magnitude > 1)
				inputVector = inputVector.normalized;

			jPoint.rectTransform.anchoredPosition = new Vector2 (inputVector.x * joystick.rectTransform.sizeDelta.x / 2, inputVector.y * joystick.rectTransform.sizeDelta.y / 2);
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
}