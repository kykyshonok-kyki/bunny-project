using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamage : MonoBehaviour
{
	public int		health;
	public Sprite	spriteSt2;
	public Sprite	spriteSt3;

	private int maxHealth;

	private void	Start()
	{
		maxHealth = health;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			Damage(1);
			Destroy(other);
		}
	}

	private void	Damage(int damage)
	{
		health -= damage;
		if (health < 0)
			Destroy(gameObject);
		else if (health < maxHealth / 3 * 2)
			if (health < maxHealth / 3)
				gameObject.GetComponent<SpriteRenderer>().sprite = spriteSt3;
			else
				gameObject.GetComponent<SpriteRenderer>().sprite = spriteSt2;
	}
}
