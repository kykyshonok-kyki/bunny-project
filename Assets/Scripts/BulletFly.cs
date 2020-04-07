using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
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
}
