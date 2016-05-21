using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour 
{
	public float _speedShoot;

	private Rigidbody _rb;
	// Use this for initialization
	void Awake () 
	{
		_rb = GetComponent<Rigidbody> ();
		_rb.velocity = transform.forward * _speedShoot;
	}
	
	// Update is called once per frame
	void Update () 
	{
		_rb = GetComponent<Rigidbody> ();
		_rb.velocity = transform.forward * _speedShoot;

	}
}
