using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor :  MonoBehaviour
{
	/*private SpriteRenderer rend;
	public Sprite handCursor;
	public Sprite nomalCursor;

	// public GameObject clickEffect;	// animation
	// public float timeBtwSpawn= 0.1f;*/

	void Start()
	{
		Cursor.visible = true;
		//end = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if(Input.GetMouseButton(0) ^  Input.GetMouseButton(1))
		{
			Cursor.visible = false;
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.nearClipPlane));
			transform.position = worldPosition;
			//Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//transform.position = cursorPos;
		}
		else if(Input.GetMouseButtonUp(0) ^  Input.GetMouseButtonUp(1))
		{
			Cursor.visible = true;
		}
		

		/*if(Input.GetMouseButtonDown(0))
		{
			rend.sprite = handCursor;
			// Instantiate(clickEffect, transform.position, Quaternion.identity);
		}
		else if(Input.GetMouseButtonUp(0))
		{
			rend.sprite = nomalCursor;
		}*/
	}
}