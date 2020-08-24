//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
	public GameObject canvas;
	public Toggle shootToggle;

	private JoystickController jContr;

	private GameObject defBullet;
	private Vector2 bulletStart;
	private float lastShootTime;
	private float fireRate;
	private Vector2 inputVector;

	private void Start()
	{
		GameObject gun;
		gun = gameObject.GetComponent<Transform>().GetChild(0).gameObject;

		lastShootTime = -1;
		defBullet = gun.GetComponent<GunConfig>().bullet;
		if (PlayerPrefs.GetInt("View control type", 0) == 0)
			jContr = GameObject.FindGameObjectWithTag("ShootController").GetComponent<JoystickController>();
		fireRate = gun.GetComponent<GunConfig>().fireRate;
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("View control type", 0) == 0)
			inputVector = jContr.GetVector();
		else if (PlayerPrefs.GetInt("View control type") == 1)
			inputVector = canvas.GetComponent<TouchShootController>().GetVector();
	}

	private void FixedUpdate()
	{
		if (PlayerPrefs.GetInt("View control type", 0) == 0)
			JoystickShoot();
		else if (PlayerPrefs.GetInt("View control type") == 1)
			ScreenLook();
	}

	private void ScreenLook()
	{
		Quaternion direction;
		GameObject newBullet;

		if (inputVector.magnitude != 0)
		{
			direction = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, inputVector));
			transform.rotation = direction;
			if (shootToggle.isOn)
				if (Time.time - lastShootTime >= fireRate)
				{
					lastShootTime = Time.time;
					bulletStart = transform.GetChild(0).GetComponent<Transform>().GetChild(0).GetComponent<Transform>().position;
					newBullet = Instantiate(defBullet, bulletStart, direction);
					newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.rotation * Vector2.right * newBullet.GetComponent<BulletFly>().speed;
				}
		}
	}

	private void JoystickShoot()
	{
		float action = jContr.GetJPointLevel();
		Quaternion direction;
		GameObject newBullet;

		if (inputVector.magnitude != 0 & action != 0)
		{
			direction = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, inputVector));
			transform.rotation = direction;
			if (action == 2)
				if (Time.time - lastShootTime >= fireRate)
				{
					lastShootTime = Time.time;
					bulletStart = transform.GetChild(0).GetComponent<Transform>().GetChild(0).GetComponent<Transform>().position;
					newBullet = Instantiate(defBullet, bulletStart, direction);
					newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.rotation * Vector2.right * newBullet.GetComponent<BulletFly>().speed;
				}
		}
	}
}
