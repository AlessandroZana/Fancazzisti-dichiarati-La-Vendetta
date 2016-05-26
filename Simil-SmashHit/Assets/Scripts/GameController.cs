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
	public float _delayShield;
	public GameObject _shieldObject;

	public bool _gameover;

	private ShieldController _shield;


	// Use this for initialization

	void Start () 
	{
		GameObject ShieldObject = GameObject.FindGameObjectWithTag ("Shield");
		if (ShieldObject != null)
		{
			_shield = ShieldObject.GetComponent <ShieldController>();
		}

		_gameOverText.text = "";
		_restartText.text = "";
		_gameover = false;
	}

	void Update()
	{
		if (_shield._hp <= 0) 
		{
			_shield.enabled = false;
			_shield.transform.position = Vector3.zero;
			StartCoroutine (SpawnShield());
		}

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

		if (Input.GetMouseButtonDown(0) && !_gameover && _shield._canShoot)
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

	public IEnumerator SpawnShield()
	{
		yield return new WaitForSeconds (_delayShield);
		_shield.enabled = true;

	}
		
}
