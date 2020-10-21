﻿using UnityEngine;
using System.Collections;

public class ObjectShooterWithLaserSound : MonoBehaviour
{
	[Header("Object creation")]

	public GameObject prefabToSpawn;

	// The key to press to create the objects/projectiles
	public KeyCode keyToPress = KeyCode.Space;

	[Header("Other options")]

	// The rate of creation, as long as the key is pressed
	public float creationRate = .5f;

	// The speed at which the object are shot along the Y axis
	public float shootSpeed = 5f;

	public Vector2 shootDirection = new Vector2(1f, 1f);

	public bool relativeToRotation = true;

	private float timeOfLastSpawn;

	// Will be set to 0 or 1 depending on how the GameObject is tagged
	private int playerNumber;

    // ADDED SETS UP AUDIO VARIABLE
    // private AudioClip shootSound;
    private AudioSource source;
    // private float vollowRange = .5f;
    // private float volhighRange = 1.0f;


    // Use this for initialization
    void Start ()
	{
		timeOfLastSpawn = -creationRate;

		// Set the player number based on the GameObject tag
		playerNumber = (gameObject.CompareTag("Player")) ? 0 : 1;

	}

    // ADDED VOID AWAKE
    private void Awake()
    {
        // GET AUDIO SOURCE
        source = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update ()
	{
		if(Input.GetKey(keyToPress)
		   && Time.time >= timeOfLastSpawn + creationRate)
		{
			Vector2 actualBulletDirection = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection) : shootDirection;

			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			newObject.transform.position = this.transform.position;
			newObject.transform.eulerAngles = new Vector3(0f, 0f, Utils.Angle(actualBulletDirection));
			newObject.tag = "Bullet";

			// ADDED CREATE AUDIO
			// source.PlayOneShot(shootSound, vol);
			source.Play();

			// push the created objects, but only if they have a Rigidbody2D
			Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
			if(rigidbody2D != null)
			{
				rigidbody2D.AddForce(actualBulletDirection * shootSpeed, ForceMode2D.Impulse);
			}

			// add a Bullet component if the prefab doesn't already have one, and assign the player ID
			BulletAttribute b = newObject.GetComponent<BulletAttribute>();
			if(b == null)
			{
				b = newObject.AddComponent<BulletAttribute>();
			}
			b.playerId = playerNumber;



			timeOfLastSpawn = Time.time;
		}
	}

	void OnDrawGizmosSelected()
	{
		if(this.enabled)
		{
			float extraAngle = (relativeToRotation) ? transform.rotation.eulerAngles.z : 0f;
			Utils.DrawShootArrowGizmo(transform.position, shootDirection, extraAngle, 1f);
		}
	}
}
