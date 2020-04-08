//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class BulletFly : MonoBehaviour
{
	public int		damage;
	public float	speed;
	private Vector3	direction = new Vector3(1, 0, 0);

	void Start()
	{
		direction = transform.rotation * direction;
	}

	void Update()
	{
		transform.position = transform.position + direction * speed * Time.deltaTime;
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
