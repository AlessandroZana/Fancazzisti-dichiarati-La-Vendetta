using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour 
{

	public int _hp;

	public bool _canShoot;
	// Use this for initialization
	void OnEnable () 
	{
		_canShoot = true;
		_hp = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Mouse1)) 
		{
			_canShoot = false;
			Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 2));
			transform.position = mouseWorldPoint;
		} 
		else 
		{
			_canShoot = true;
			transform.position = (Vector3.zero);	
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Obj") 
		{
			_hp = 0;
		}

		if (other.tag == "Enemy") 
		{
			_hp -= 1;
		}
	}


}
