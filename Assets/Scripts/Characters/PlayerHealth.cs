//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int startHealth;
	public HealthBar healthBar;

	private int health;
	private int maxHealth;

	void Start()
	{
		enabled = false;
		health = startHealth;
		maxHealth = startHealth;
		healthBar.SetHelth(maxHealth, health);
	}

	public void ChangeHealth(int newMaxHealth)      //Вызывается при изменении максимального запаса здоровья у игрока
	{
		maxHealth = newMaxHealth;
	}

	public void Damage(int damage)       //Вызывается при получении урона или лечении игрока
	{
		health -= damage;
		if (health <= 0)
		{
			healthBar.SetHelth(maxHealth, 0);
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			gameObject.GetComponent<MoveController>().enabled = false;
			gameObject.GetComponent<ShootController>().enabled = false;
			gameObject.GetComponent<MoveController>().ChangePositionsBeforeClose();
		}
		else
		{
			if (health > maxHealth)
				health = maxHealth;
			healthBar.SetHelth(maxHealth, health);
		}
	}
}
