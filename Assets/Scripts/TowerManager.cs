using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager : Singleton<TowerManager> {
    private TowerButton towerButtonPressed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            //worldPoint is the position of the mouse click.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            /* Ray Cast involves intersecting a ray with the object in an environment.
             * The ray cast tells you what objects in the environment the ray runs into.
             * and may return additional information as well, such as intersection point
             */
            //Finding the worldPoint of where we click, from Vector2.zero (which is buttom left corner)
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            placeTower(hit);
        }
	}

   
    public void selectedTower(TowerButton towerSelected)
    {
        towerButtonPressed = towerSelected;
        //Debug.Log("Pressed: " + towerButtonPressed.gameObject);
    }

    //Place new tower on the mouse click location
    public void placeTower(RaycastHit2D hit)
    {
        //If the pointer is not over the Tower Button GameObject && the tower button has been pressed
        //Created new tower at the click location
        if(!EventSystem.current.IsPointerOverGameObject() && towerButtonPressed != null)
        {
            GameObject newTower = Instantiate(towerButtonPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
        }
    }
}
