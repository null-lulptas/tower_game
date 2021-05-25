using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : Singleton<Master>
{
    public TowerBuyButton Button { get; private set; }

    public GameObject sellPanel;

    private Tower selectedTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TowerPick(TowerBuyButton twrButton)
    {        
        Button = twrButton;
    }

    public void TowerBuy()
    {
        
        Button = null;        
    }

    public void DeselectTower()
    {
        if(selectedTower != null)
        {
            selectedTower.Select();
        }
        selectedTower = null;
        sellPanel.SetActive(false);
    }

    public void SelectTower(Tower tower)
    {
        selectedTower = tower;
        selectedTower.Select();
        sellPanel.SetActive(true);
    }

    public void SellTower()
    {
        if(selectedTower != null)
        {
            selectedTower.GetComponentInParent<Tile_Location>().IsEmpty = true;
            Destroy(selectedTower.transform.gameObject);
            PlayerStats.money += 2;
            DeselectTower();
        }
    }
}
