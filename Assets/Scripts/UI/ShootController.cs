//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class ShootController : MonoBehaviour
{
	private JoystickController jContr;

	private GameObject defBullet;
	private Vector2 bulletStart;
	private float lastShootTime;
	private float fireRate;
	private Vector2 inputVector;

	private void Start()
	{
		GameObject gun;
		gun = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().GetChild(0).gameObject;

		lastShootTime = -1;
		defBullet = gun.GetComponent<GunConfig>().bullet;
		jContr = GameObject.FindGameObjectWithTag("ShootController").GetComponent<JoystickController>();
		fireRate = gun.GetComponent<GunConfig>().fireRate;
	}

	private void Update()
	{
		inputVector = jContr.GetVector();
	}
	
	private void FixedUpdate()
	{
		CharacterLookShoot();
	}

	private void CharacterLookShoot()
	{
		float action = jContr.GetJPointLevel();
		Quaternion direction;
		GameObject newBullet;

		if (inputVector.magnitude != 0 & action != 0)
		{
			direction = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, jContr.GetVector()));
			transform.rotation = direction;
			if (action == 2)
				if (Time.time - lastShootTime >= fireRate)
				{
					lastShootTime = Time.time;
					bulletStart = transform.GetChild(0).GetComponent<Transform>().GetChild(0).GetComponent<Transform>().position;
					newBullet = Instantiate(defBullet, bulletStart, direction);
					newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.rotation * Vector3.right * newBullet.GetComponent<BulletFly>().speed;
				}
		}
	}
}
