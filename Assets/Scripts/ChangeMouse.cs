using UnityEngine;
using System.Collections;

public class ChangeMouse : MonoBehaviour 
{
	public Texture2D mouseNormal;
	public Texture2D mouseDown;
	void Awake ()
	{
		Cursor.SetCursor(mouseNormal,Vector2.zero,CursorMode.Auto);
	}

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if (Input.GetMouseButton(0))
			Cursor.SetCursor(mouseDown,Vector2.zero,CursorMode.Auto);
		else
			Cursor.SetCursor(mouseNormal,Vector2.zero,CursorMode.Auto);
			
	}
}
