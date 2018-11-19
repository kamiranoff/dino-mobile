using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;
    [SerializeField] private GameObject[] collectables;

    private float _distanceBetweenClouds = 3f;

    private float _minX;
    private float _maxX;

    private float _lastCloudPositionY;
    private int _controlX;

    private GameObject _player;


    private void Awake()
    {
        _controlX = 0;
        SetMinAndMax();
        CreateClouds();
        _player = GameObject.Find("Player");
    }

    private void Start()
    {
        PositionPlayer();
    }

    void SetMinAndMax()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector3 bounds = Camera.main.ScreenToWorldPoint(screenSize);
        _maxX = bounds.x - 0.5f;
        _minX = -bounds.x + 0.5f;
    }

    void CreateClouds()
    {
        Shuffle(clouds);

        float positionY = 0f;

        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;

            if (_controlX == 0)
            {
                temp.x = Random.Range(0.0f, _maxX);
                _controlX = 1;
            }
            else if (_controlX == 1)
            {
                temp.x = Random.Range(0.0f, _minX);
                _controlX = 2;
            }
            else if (_controlX == 2)
            {
                temp.x = Random.Range(1.0f, _maxX);
                _controlX = 3;
            }
            else if (_controlX == 3)
            {
                temp.x = Random.Range(-1.0f, _minX);
                _controlX = 0;
            }

            _lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= _distanceBetweenClouds;
        }
    }

    void Shuffle(GameObject[] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    void PositionPlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < darkClouds.Length; i++)
        {
            if (Math.Abs(darkClouds[i].transform.position.y) < 0.001)
            {
                Vector3 t = darkClouds[i].transform.position;

                darkClouds[i].transform.position = new Vector3(clouds[0].transform.position.x,
                    clouds[0].transform.position.y, clouds[0].transform.position.z);

                clouds[0].transform.position = t;
            }
        }

        Vector3 cloudPosition = clouds[0].transform.position;
        for (int i = 0; i < clouds.Length; i++)
        {
            if (cloudPosition.y < clouds[i].transform.position.y)
            {
                cloudPosition = clouds[i].transform.position;
            }
        }

        cloudPosition.y += 1.8f;
        _player.transform.position = cloudPosition;
    }
}