using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : slot
{
    
    public EquipmentType EquipmentType;
    protected void OnValidate()
    {
        
        //base.OnValidate();
        //gameObject.name = EquipmentType.ToString() + "Slot";
    }
}
