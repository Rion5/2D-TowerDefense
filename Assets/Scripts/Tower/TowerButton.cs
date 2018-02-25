using UnityEngine;

public class TowerButton : MonoBehaviour {
    [SerializeField]
    private GameObject towerObject;

    public GameObject TowerObject
    {
        get { return towerObject; }
    }
}
