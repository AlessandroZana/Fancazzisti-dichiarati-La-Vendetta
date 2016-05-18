using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public GameObject _sphere;
	public int _numberOfSphere;
	public Text _sphereText;
	public Text _gameOverText;
	public Text _restartText;


	// Use this for initialization
	private bool _gameover;

	void Start () 
	{
		_gameOverText.text = "";
		_restartText.text = "";
		_gameover = false;
		_numberOfSphere = 10;
	}

	void Update()
	{
		_sphereText.text = "SPHERE: " + _numberOfSphere;

		if (Input.GetKeyDown (KeyCode.R) && _gameover) 
		{
			SceneManager.LoadScene ("Main");
		}


		if (_numberOfSphere == 0) 
		{
			_gameover = true;
			if (_gameover) 
			{
				GameOver ();
			}
		}

		if (Input.GetMouseButtonDown(0) && !_gameover)
		{
			_numberOfSphere--;
			Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,5));
			Instantiate (_sphere, mouseWorldPoint, transform.rotation);
		}
	}

	public void GameOver()
	{
		_gameOverText.text = "GAME OVER";
		_restartText.text = "Press R to restart";
	}
		
}
