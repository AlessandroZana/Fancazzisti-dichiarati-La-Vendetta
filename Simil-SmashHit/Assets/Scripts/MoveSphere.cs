using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour {

	public float _speedSphere;

	private GameController _gameController;
	private Rigidbody _rb;
	public GameObject explosion;

	void Start () 
	{
		_rb = GetComponent<Rigidbody> ();
		_rb.velocity = transform.forward * _speedSphere;

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
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
