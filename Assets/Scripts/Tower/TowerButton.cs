using UnityEngine;

public class TowerButton : MonoBehaviour {
    [SerializeField]
    private Tower towerObject;
    [SerializeField]
    private Sprite dragSprite;
    [SerializeField]
    private int towerPrice;

    public Tower TowerObject
    {
        get { return towerObject; }
    }

    public Sprite DragSprite
    {
        get { return dragSprite; }
    }

    public int TowerPrice
    {
        get { return towerPrice; }
    }
}
