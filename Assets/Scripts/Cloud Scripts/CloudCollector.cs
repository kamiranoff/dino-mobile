using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D target)
	{
		if (target.CompareTag("Cloud") || target.CompareTag("Deadly"))
		{
			target.gameObject.SetActive(false);
		}
	}

}
