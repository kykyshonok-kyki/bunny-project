//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class HealthBar : MonoBehaviour
{
	private void Start()
	{
		enabled = false;
	}

	public void SetHelth(int maxHealth, int health)
	{
		if (health <= 0)
			SetBarScale(0);
		else
			SetBarScale((float) health / maxHealth);
	}

	private void SetBarScale(float hpInPercents)
	{
		transform.GetChild(0).localScale = new Vector2(hpInPercents, 1);
		transform.GetChild(0).localPosition = new Vector2((hpInPercents - 1) / 4, 0);
	}
}
