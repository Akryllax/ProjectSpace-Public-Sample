using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInventoryItem
{
    private int itemTypeID;
    private string itemName;
    private string itemDescription;

    public int ItemTypeID { get => itemTypeID;  }
    public string ItemDescription { get => itemDescription;  }
    public string ItemName { get => itemName;  }

    public BaseInventoryItem(int ItemID)
    {
        throw new NotImplementedException();
    }

    public BaseInventoryItem(int ItemID, string ItemName, string ItemDescription)
    {
        this.itemTypeID = ItemID;
        this.itemName = ItemName;
        this.itemDescription = ItemDescription;
    }
}
