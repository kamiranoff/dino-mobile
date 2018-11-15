using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{


	[SerializeField] private GameObject[] clouds;
	[SerializeField] private GameObject[] collectables;

	private float _distanceBetweenClouds = 3f;

	private float _minX;
	private float _maxX;

	private float _lastCloudPositionY;
	private float _controlX;

	private GameObject _player;


	void SetMinAndMaxX()
	{
		
	}


}
