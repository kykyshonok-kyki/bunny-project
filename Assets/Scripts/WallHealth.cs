//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class WallHealth : MonoBehaviour
{
	public int		startHealth;
	public Sprite	spriteSt1;
	public Sprite	spriteSt2;
	public Sprite	spriteSt3;
	public Sprite	spriteSt4;

	private int		maxHealth;
	private int		health;
	private int		healthSt2;
	private int		healthSt3;
	private int		healthSt4;
	private bool	ifDestroyable;

	private void	Start()
	{
		enabled = false;
		if (startHealth == -1)
			ifDestroyable = false;
		else
		{
			ifDestroyable = true;
			maxHealth = startHealth;
			health = startHealth;
			healthSt4 = startHealth / 4;
			healthSt3 = healthSt4 * 2;
			healthSt2 = healthSt4 * 3;
		}
	}

	public void	ChangeHealth(int newMaxHealth)
	{
		maxHealth = newMaxHealth;
		health = newMaxHealth;
		healthSt4 = newMaxHealth / 4;
		healthSt3 = healthSt4 * 2;
		healthSt2 = healthSt4 * 3;
	}

	public int	Damage(int damage)
	{
		if (ifDestroyable)
		{
			Sprite curSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

			health -= damage;
			if (health <= 0)
				Destroy(gameObject);
			else if (health <= healthSt4)
			{
				if (curSprite != spriteSt4)
					gameObject.GetComponent<SpriteRenderer>().sprite = spriteSt4;
			}
			else if (health <= healthSt3)
			{
				if (curSprite != spriteSt3)
					gameObject.GetComponent<SpriteRenderer>().sprite = spriteSt3;
			}
			else if (health <= healthSt2)
			{
				if (curSprite != spriteSt2)
					gameObject.GetComponent<SpriteRenderer>().sprite = spriteSt2;
			}
			else if (curSprite != spriteSt1)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = spriteSt1;
				if (health > maxHealth)
					health = maxHealth;
			}
			return health;
		}
		return 0;
	}
	
	public bool	IfDestroyable()
	{
		return ifDestroyable;
	}
}
