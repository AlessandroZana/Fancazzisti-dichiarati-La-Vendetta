using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public GameObject _shot;
	public Transform _spawnShoot;
	public float _shootDelay;

	public Transform _player;
	public Transform _backMarker;
	public Transform _frontMarker;

	private bool _start;


	// Use this for initialization
	void Start () 
	{
		_start = true;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (transform.position.z <= _frontMarker.position.z) 
		{
			transform.LookAt (_player);
			if (_start == true) 
			{
				StartCoroutine (Shoot ());
				_start = false;
			}
		} 
	}

	IEnumerator Shoot()
	{
		while (transform.position.z >= _backMarker.position.z) 
		{
			Instantiate (_shot, _spawnShoot.position, _spawnShoot.rotation);
			yield return new WaitForSeconds (_shootDelay);
		}
	}

}
