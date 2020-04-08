//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class BulletFly : MonoBehaviour
{
	public int		damage;
	public float	speed;

	void Start()
	{
		GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector3.right * speed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
		{
			other.gameObject.GetComponent<WallHealth>().Damage(damage);
			Destroy(gameObject);
		}
	}
}
