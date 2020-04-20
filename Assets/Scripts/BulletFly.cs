//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class BulletFly : MonoBehaviour
{
	public int damage;
	public float speed;

	void Start()
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
		{
			other.gameObject.GetComponent<WallHealth>().Damage(damage);
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "Player" | other.gameObject.tag == "Teammate" | other.gameObject.tag == "Neutral" | other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<PlayerHealth>().Damage(damage);
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "Door")
		{
//			other.gameObject.GetComponent<PlayerHealth>().Damage(damage);
			Destroy(gameObject);
		}
	}
}
