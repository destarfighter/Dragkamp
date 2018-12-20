using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[System.Serializable]
public class PlayerInfo : System.Object
{
    // Properties
    public GUID PlayerID { get; set; }

    public int Health { get; set; }
    public int Gold { get; set; }

    public int MaxWorkerPopulation {get; set;}
    public int MaxMilitaryPopulation { get; set; }

    public int AmountOfWorkers { get; set; }

    // Multipliers, atk, def, cost etc
    //...

    // Units
    // A list of all accumulated units, not currently in use.
    public List<object> PassiveUnits { get; set; }
    // A list of all units currently sent out too battle. 
    public List<object> ActiveUnits { get; set; }

    // Permanent Buildings
    public object TownCenter { get; set; }
    public object Mine { get; set; }
    public object Wall { get; set; }
    public object Tower { get; set; }
    public object Outpost { get; set; }

    // Dynamic Buildings
    public List<object> DynamicBuildings { get; set; }

    // Level Specific Buildings
    public List<object> LevelBuildings { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
