using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : Singleton<TowerManager> {
    private TowerButton towerButtonPressed;

    public void selectedTower(TowerButton towerSelected)
    {
        towerButtonPressed = towerSelected;
        Debug.Log("Pressed: " + towerButtonPressed.gameObject);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
