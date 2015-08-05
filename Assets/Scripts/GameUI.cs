using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour 
{
	public GameObject newGamePanel;
	public GameObject gameOverPanel;
	public GameObject scoreHub;
	

	void Start () 
	{
		EventManager.StartListening("OnGameStart",OnGameStartHandler);
		EventManager.StartListening("OnGameOver",OnGameOverHandler);	
		EventManager.StartListening("OnGameReStart",OnGameReStartHandler);	
		
	}
	
	void Update () 
	{
		scoreHub.GetComponent<Text>().text = "你坚持了:" + ((int)GameManager.score).ToString() + "秒";	
	}
	
	public void StartGame ()
	{
		EventManager.TriggerEvent("OnGameStart");
	}

	public void ReStartGame ()
	{
		EventManager.TriggerEvent("OnGameReStart");
		
	}
	public void QuitGame ()
	{
		Application.Quit();
	}

	public void OpenWebsite ()
	{
		Application.OpenURL("www.doyourgame.com");
	}




	void OnGameStartHandler ()
	{
		newGamePanel.SetActive(false);
		gameOverPanel.SetActive(false);
		scoreHub.SetActive(true);
	}

	void OnGameReStartHandler ()
	{
		newGamePanel.SetActive(false);
		gameOverPanel.SetActive(false);
		scoreHub.SetActive(true);
	}
	void OnGameOverHandler ()
	{
		newGamePanel.SetActive(false);
		gameOverPanel.SetActive(true);
		scoreHub.SetActive(false);
		gameOverPanel.transform.FindChild("FinalScore").GetComponent<Text>().text = "你只坚持了:" + ((int)GameManager.score).ToString() + "秒";
		
	}
}
