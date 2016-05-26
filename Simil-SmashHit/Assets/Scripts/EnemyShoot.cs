using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour 
{
	public float _speedShoot;

	private Rigidbody _rb;
	// Use this for initialization

	// Update is called once per frame
	void  FixedUpdate () 
	{
		_rb = GetComponent<Rigidbody> ();
		_rb.velocity = transform.forward * _speedShoot;

	}
}
