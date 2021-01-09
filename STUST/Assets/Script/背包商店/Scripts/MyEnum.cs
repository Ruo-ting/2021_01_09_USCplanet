using System.Collections;
using System.Collections.Generic;

public enum enumItemKind
{
    裝備=0,    // Equipment
    道具,    // Pros, 如藥水等
    服飾
}

public enum enumItemName
{
    // Equipment
    雞,
    花,
    香菇,
    // Pros
    藥水,
    塑膠寶箱,
    // Apparel
    頭髮, 
    染髮劑, 
    衣服,
    褲子,
    鞋子,
    變色瞳孔
}

public enum enumHairColor : int
{
    Red = 0,
    Green,
    Black,
    Brown
}

public enum enumEyesColor : int
{
    Red = 0,
    Green,
    Black,
    Brown
}

public enum enumWhoUse
{
    Anyone,
    Boy,
    Girl
}
