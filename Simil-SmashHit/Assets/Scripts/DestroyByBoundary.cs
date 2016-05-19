using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	public float _speedBoundary;
	private Rigidbody _rb;
	void Start()
	{
		_rb = GetComponent<Rigidbody> ();
		_rb.velocity = transform.forward * _speedBoundary;

	}

	void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);
	}
}
