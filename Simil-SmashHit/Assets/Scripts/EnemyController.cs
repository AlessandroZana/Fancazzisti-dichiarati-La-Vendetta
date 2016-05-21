using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public GameObject _shot;
	public Transform _spawnShoot;
	public float _shootDelay;

	public Transform _target;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (Shoot ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(_target);
	}

	IEnumerator Shoot()
	{
		while (true) 
		{
			Instantiate (_shot, _spawnShoot.position, _spawnShoot.rotation);
			yield return new WaitForSeconds (_shootDelay);
		}
	}
}
