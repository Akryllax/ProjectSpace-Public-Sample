using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInventoryHolder : MonoBehaviour
{
    private int m_InventoryCapacity;
    private List<BaseInventoryItem> m_Items;

    public int InventoryCapacity { get => m_InventoryCapacity; }
    protected List<BaseInventoryItem> LItems { get => m_Items; }

    public void Awake()
    {
        m_Items = new List<BaseInventoryItem>();
    }

    public bool AddItem(BaseInventoryItem item)
    {
        bool wasAdded = false;
        if(m_Items.Count < m_InventoryCapacity)
        {
            this.m_Items.Add(item);
            wasAdded = true;
        }

        return wasAdded;
    }

    public bool RemoveItem(int ItemTypeID)
    {
        BaseInventoryItem item = null;

        foreach (var i in m_Items)
        {
            if(i.ItemTypeID == ItemTypeID)
            {
                item = i;
                break;
            }
        }

        if(item != null)
        {
            m_Items.Remove(item);
            return true;
        } else
        {
            return false;
        }
    }

    public bool RemoveItem(BaseInventoryItem item)
    {
        return DropItem(item) != null;
    }

    public BaseInventoryItem DropItem(BaseInventoryItem item)
    {
        BaseInventoryItem result = null;

        foreach(var i in m_Items)
        {
            if(i.ItemTypeID == item.ItemTypeID)
            {
                result = i;
                break;
            }
        }

        if(result != null)
        {
            m_Items.Remove(result);
        }

        return result;
    }

    public void SetCapacity(int Capacity)
    {
        int oldCapacity = this.m_InventoryCapacity;
        this.m_InventoryCapacity = Capacity;

        if (oldCapacity != Capacity)
        {
            ResizeInventory();
        }
    }

    public void ResizeInventory()
    {
        if(m_Items.Count > m_InventoryCapacity )
        {
            m_Items.RemoveRange(m_InventoryCapacity - 1, m_Items.Count - m_InventoryCapacity);
        }
    }

    public List<BaseInventoryItem> GetItemList()
    {
        return m_Items;
    }

    public int GetCount()
    {
        return m_Items.Count;
    }

    public BaseInventoryItem GetItem(int ItemIndex)
    {
        BaseInventoryItem item = null;

        if(ItemIndex < m_Items.Count)
        {
            item = m_Items[ItemIndex];
        }

        return item;
    }
}
