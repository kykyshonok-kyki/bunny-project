//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class ActionButtonTurning : MonoBehaviour
{
	public GameObject actionButton;

	private Collider2D activeCollider;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Door")
		{
			actionButton.GetComponent<ActionButton>().Active(collision.gameObject);
			activeCollider = collision;
		}
		else if (collision.gameObject.tag == "Neutral")
		{
			Debug.Log("This works!");
			actionButton.GetComponent<ActionButton>().Active(collision.gameObject);
			activeCollider = collision;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		OnTriggerEnter2D(collision);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision == activeCollider)
			actionButton.SetActive(false);
	}
}
