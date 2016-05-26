using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float _speedPlayer;
	public float _slowSpeed;
	public float _slowTime;


	private Rigidbody _rb;

	private ShieldController _shield;
	private GameController _gameController;
	// Use this for initialization
	void Start () 
	{
		_rb = GetComponent<Rigidbody> ();
		_rb.velocity = transform.forward * _speedPlayer;

		GameObject ShieldObject = GameObject.FindGameObjectWithTag ("Shield");
		if (ShieldObject != null)
		{
			_shield = ShieldObject.GetComponent <ShieldController>();
		}

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

		if (_gameController._gameover) 
		{
			_rb.velocity = Vector3.zero;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Obj") 
		{
			_gameController._numberOfSphere -= 10;
			Destroy (other.gameObject);
			_rb.velocity = transform.forward * _slowSpeed;
			StartCoroutine (SlowPlayer ());
		}

		if (other.tag == "Enemy") 
		{
			_gameController._numberOfSphere -= 5;
			if (_shield._canShoot == false) 
			{
				_shield._hp = 0;
			}
		}

	}

	IEnumerator SlowPlayer()
	{
		yield return new WaitForSeconds (_slowTime);
		_rb.velocity = transform.forward * _speedPlayer;
	}

}
