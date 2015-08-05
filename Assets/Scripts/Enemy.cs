using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public float speed = 1f;
	public float xDirection = 1;
	public float yDirection = 1;

	public float timeChangeRate = 5f;
	[SerializeField]
	private float speedStep = 0.1f;
	

	private Vector3 initialPos;
	private bool isEnable = false;
	private float timeCounter = 0;
	

	void Start () 
	{
		initialPos = transform.position;
		EventManager.StartListening("OnGameStart",OnGameStartHandler);
		EventManager.StartListening("OnGameReStart",OnGameReStartHandler);
		EventManager.StartListening("OnGameOver",OnGameOverHandler);
		timeCounter = 0;
		

	}
	
	void Update () 
	{
		if (!isEnable)
			return;
		transform.Translate(Vector3.left * Time.deltaTime * speed * xDirection);
		transform.Translate(Vector3.up * Time.deltaTime * speed * yDirection);	

		timeCounter += Time.deltaTime;
		if (timeCounter >= timeChangeRate)
		{
			speed += speedStep;
			timeCounter = 0f;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (!isEnable)
			return;
		if (other.gameObject.tag == "Player")
		{
			xDirection = -xDirection;yDirection = -yDirection;
			EventManager.TriggerEvent("OnGameOver");
			
		}
//		if (other.gameObject.tag == "Enemy" && other.gameObject != gameObject)
//		{
//			xSpeed = -xSpeed;ySpeed = -ySpeed;
//		}
	}


	public void SetDirection (string axis)
	{
		if (axis == "h")
		{
			xDirection = -xDirection;
		}
		if (axis == "v")
		{
			yDirection = -yDirection;
		}
	}

	//事件处理器,当游戏中某种事件被触发的时候才会发生.
	#region
	void OnGameStartHandler ()
	{
		isEnable = true;
		timeCounter = 0f;
		speed = 1f;
		
	}
	void OnGameReStartHandler ()
	{
		transform.position = initialPos;
		isEnable = true;
		timeCounter = 0f;
		speed = 1f;
		
		
	}
	
	void OnGameOverHandler ()
	{
		isEnable = false;
		timeCounter = 0f;
		speed = 1f;
		
		
	}
	#endregion


}
