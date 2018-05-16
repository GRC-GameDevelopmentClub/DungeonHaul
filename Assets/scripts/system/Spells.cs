using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "D.H./Spell Info")]
public class Spells : ScriptableObject {

    public string spName = "Spell Name";
    public string spDesc = "Spell Lore";

    public Sprite thumbnail;

    public GameObject atkPref;

    public int mPCost = 1;

}
