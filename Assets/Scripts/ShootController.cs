//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;

public class ShootController : MonoBehaviour
{
	private JoystickController	jContr;

	private GameObject	defBullet;
	private Vector2		bulletStart;
	private float		lastShootTime;

	private void	Start()
	{
		lastShootTime = -1;
		defBullet = GameObject.FindGameObjectWithTag("DefBullet");
		jContr = GameObject.FindGameObjectWithTag("ShootController").GetComponent<JoystickController>();
		defBullet.GetComponent<BulletFly>().enabled = false;
		defBullet.tag = "Bullet";
	}

	private void	FixedUpdate()
	{
		CharacterLookShoot();
	}

	private void	CharacterLookShoot()
	{
		float		action = jContr.GetJPointPos();
		Vector2		inputVector = jContr.GetVector();
		Quaternion	direction;

		if (inputVector.magnitude != 0 & action != 0)
		{
			direction = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, jContr.GetVector().normalized));
			transform.rotation = direction;
			if (action == 2)
				if (Time.time - lastShootTime >= 1)
				{
					lastShootTime = Time.time;
					bulletStart = transform.GetChild(0).GetComponent<Transform>().GetChild(0).GetComponent<Transform>().position;
					GameObject.Instantiate(defBullet, bulletStart, direction).GetComponent<BulletFly>().enabled = true;
				}
		}
	}
}
