using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : Singleton<Master>
{
    public TowerBuyButton Button { get; private set; }

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
}
