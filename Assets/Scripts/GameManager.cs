using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static float score = 0f;



	void Start () 
	{
		EventManager.StartListening("OnGameStart",OnGameStartHandler);
		EventManager.StartListening("OnGameOver",OnGameOverHandler);
		EventManager.StartListening("OnGameReStart",OnGameReStartHandler);
		Time.timeScale = 1f;
	}
	
	void Update () 
	{
		score += Time.deltaTime;
	}

	void OnGameStartHandler()
	{
		score = 0;
	}

	void OnGameOverHandler()
	{
		score = 0;	
		
	}

	void OnGameReStartHandler()
	{
		score = 0;		
		
	}
}
