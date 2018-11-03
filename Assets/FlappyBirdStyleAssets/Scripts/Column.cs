using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

	private void OnTriggerExit2D (Collider2D other)
	{
		if (other.transform.CompareTag("Player")) 
		{
			GameControl.instance.BirdScored ();
		}
	}
}
