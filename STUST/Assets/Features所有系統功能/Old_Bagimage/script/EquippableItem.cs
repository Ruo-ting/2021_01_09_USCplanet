using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType 
{
    Helment,
    Chest,
    Gloves,
    Boot,
    Weapon1,
    Weapon2,
    Accessory1,
    Accessory2,

}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int StrengthBonus;
    public int AgilityBonus;
    public int IntelligenceBonus;
    public int VitalityBonus;
    [Space]
    public float StrengthParcentBonus;
    public float AgilityParcentBonus;
    public float IntelligenceParcentBonus;
    public float VitalityParcentBonus;
    [Space]
    public EquipmentType EquipmentType;
}
