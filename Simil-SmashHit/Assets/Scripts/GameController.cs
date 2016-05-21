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
	public bool _gameover;
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private Vector3 Spawn;



	// Use this for initialization

	void Start () 
	{


		StartCoroutine (SpawnWaves());
		_gameOverText.text = "";
		_restartText.text = "";
		_gameover = false;
	}

	void Update()
	{
		
		GameObject spawnObject = GameObject.FindGameObjectWithTag ("spawn");
		if (spawnObject != null)
		{
			Spawn = spawnObject.GetComponent <Transform>().position;
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

		if (Input.GetMouseButtonDown(0) && !_gameover)
		{
			_numberOfSphere--;
			Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,5));
			Instantiate (_sphere, mouseWorldPoint, transform.rotation);
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds(startWait);

		while (true) {

			for (int i = 0; i < hazardCount; i++)
			{

				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x),Spawn.y ,Spawn.z );

				Instantiate (hazard, spawnPosition, Quaternion.identity);

				yield return new WaitForSeconds (spawnWait);

			}

			yield return new WaitForSeconds (waveWait);

		}
	}

	public void GameOver()
	{
		_gameOverText.text = "GAME OVER";
		_restartText.text = "Press R to restart";
	}
		
}



