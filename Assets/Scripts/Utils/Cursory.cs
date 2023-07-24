using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursory :  MonoBehaviour
{
	private SpriteRenderer rend;

	void Start()
	{
		Cursor.visible  = false;
		rend = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// transform.position = Vector2.MoveTowards(transform.position, amera.main.ScreenToWorldPoint(cursorPose), 100 * Time.deltaTime);
		transform.position = cursorPos;
	}
}