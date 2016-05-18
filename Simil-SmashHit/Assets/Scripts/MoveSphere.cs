using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour {

	public float _speed;

	private GameController _gameController;

	void Start () 
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * _speed;

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("gameController");
		if (gameControllerObject != null)
		{
			_gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (_gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Obj") 
		{
			_gameController._numberOfSphere += 3;
			Destroy (other.gameObject);
		}
	}
}
