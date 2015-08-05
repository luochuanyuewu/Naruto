using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	private bool isEnable = false;
	private Vector3 initialPos;

	void Start () 
	{
		initialPos = transform.position;
		EventManager.StartListening("OnGameStart",OnGameStartHandler);
		EventManager.StartListening("OnGameReStart",OnGameReStartHandler);
		EventManager.StartListening("OnGameOver",OnGameOverHandler);
	}

	IEnumerator OnMouseDown ()
	{
		if (isEnable)
		{
			Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);
			Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenSpace.z));
			while (Input.GetMouseButton(0))
			{
				Vector3 curScreenSpace = new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenSpace.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
				
				if (curPosition.x > 7)
					curPosition.x = 7;
				if (curPosition.x < 0)
					curPosition.x = 0;
				if (curPosition.y > 0)
					curPosition.y = 0;
				if (curPosition.y < -5)
					curPosition.y = -5;
				transform.position = curPosition;
				yield return new WaitForFixedUpdate();


			}

		}

	}

	//事件处理器,当游戏中某种事件被触发的时候才会发生.
	#region
	void OnGameStartHandler ()
	{
		isEnable = true;
	}
	void OnGameReStartHandler ()
	{
		isEnable = true;
		transform.position = initialPos;
	}

	void OnGameOverHandler ()
	{
		isEnable = false;
	}
	#endregion
}
