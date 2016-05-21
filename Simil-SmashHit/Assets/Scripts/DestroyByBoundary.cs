using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
	public GameObject _Player;
	private Vector3 _offset;
	// Use this for initialization
	void Start () 
	{
		_offset = transform.position - _Player.transform.position;

	}

	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = _Player.transform.position + _offset;

	}


	void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);
	}
}
