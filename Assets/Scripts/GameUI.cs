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

		scoreHub.GetComponent<Text>().text = "You hold this game for " + ((int)GameManager.score).ToString() + " seconds,keep moving!";	
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
		Application.OpenURL("http://www.luochuanyuewu.com");
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
		gameOverPanel.transform.Find("FinalScore").GetComponent<Text>().text = "You only hold this game for " + ((int)GameManager.score).ToString() + " sceonds.Play again?";
		
	}
}
