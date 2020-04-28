//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.UI;

public class CharactersHelpShowing : MonoBehaviour
{
	private bool isUsing;
	private bool isFirstPhase;
	private Color color;
	private float stayTime;

	private void Start()
	{
		color = transform.GetComponent<Text>().color;
		color.a = 0;
		transform.GetComponent<Text>().color = color;
		isUsing = false;
		isFirstPhase = true;
		enabled = false;
	}

	public void Show(float pos)
	{
		if (!isUsing)
		{
			isUsing = true;
			enabled = true;
			transform.localPosition = new Vector2(transform.localPosition.x, pos);
			color.a = 0.001f;
		}
	}

	private void Update()
	{
		float a;

		if (isFirstPhase)
		{
			if (color.a < 1f)
			{
				a = Time.deltaTime * 1f;
				if (color.a + a > 1f)
					color.a = 1f;
				else
					color.a += a;
				transform.GetComponent<Text>().color = color;
			}
			else
			{
				stayTime = 0f;
				isFirstPhase = false;
			}
		}
		else if (stayTime + Time.deltaTime < 3f)
			stayTime += Time.deltaTime;
		else
		{
			if (color.a > 0f)
			{
				a = Time.deltaTime * 1f;
				if (color.a - a < 0f)
					color.a = 0f;
				else
					color.a -= a;
				transform.GetComponent<Text>().color = color;
			}
			else
			{
				isUsing = false;
				isFirstPhase = true;
				enabled = false;
			}
		}
	}
}
