using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public Color[] Availablecolors;
    public SpriteRenderer Sprite;

    private int _currentIndex = 0;

    private void Awake()
    {
        //Called when GameObject is activated first time

        Debug.Log("Awake");
        if (Sprite == null)
        {
            Sprite = GetComponent<SpriteRenderer>();
        }

        if (Availablecolors.Length <= 0)
        {
            Debug.Log("No Colors");
        }
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Start");
    }
	
	// Update is called once per frame
	void Update () {
        // Run every frame
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sprite.color = Availablecolors[_currentIndex];
            _currentIndex++;
            if (_currentIndex == Availablecolors.Length)
            {
                _currentIndex = 0;
            }
        }
        Debug.Log("Update");
    }

    private void FixedUpdate()
    {
        // Run 50 times/sec
        Debug.Log("FixedUpdate");
    }

    private void OnDestroy()
    {
        // Called just before object is destroyed 
        Debug.Log("OnDestroy");
    }
}
