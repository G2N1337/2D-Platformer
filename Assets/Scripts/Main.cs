/*
Code by G2N1337 for 2D Platformer with 3D or 2D branches
Original from: https://github.com/G2N1337/2D-Platformer
Creator: vk.com/yanduditsky
Copyright © 2017
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour {
	[Header("Контроллер")]
	public float x;
	public float y;
	public float speed;
	public float jumpSpeed;
	private int pickup;
	[Header("UI")]
	public Text text;
	[Header("Порталы")]
	public int sceneNumber;
	public int maxPickups;
	public GameObject portal;
	// Update is called once per frame
	void Start() {
		portal.SetActive (false);
		Cursor.visible = false;
	}
	void FixedUpdate () {
		x = Input.GetAxis ("Horizontal");
		y = Input.GetAxis ("Vertical");
		transform.position = new Vector2 (transform.position.x + x * speed * Time.deltaTime, transform.position.y);
		transform.position = new Vector2 (transform.position.x, transform.position.y + y * jumpSpeed * 2 * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Pickup") {
			pickup++;
			print (pickup);
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Portal") {
			SceneManager.LoadScene (sceneNumber);
		}
	}
	void Update() {
		// Portal spawn
		if (pickup == maxPickups) {
			portal.SetActive(true);
		}
		// Text
		text.text = "Очков у вас: "+pickup.ToString();
		// RESTART
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
