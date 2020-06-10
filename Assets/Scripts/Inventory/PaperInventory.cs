using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Inventory
{
    public class PaperInventory
    {
        private const int INVENTORY_MAX_SIZE = 50;
        
        private List<PaperItem> InventoryItems = new List<PaperItem>();

        public bool AddItem(PaperItem itemToAdd)
        {
            if (InventoryItems.Count >= INVENTORY_MAX_SIZE) return false;
            
            InventoryItems.Add(itemToAdd);
            return true;
        }

        public bool RemoveItem(int itemIndex)
        {
            if (itemIndex == -1 || itemIndex >= InventoryItems.Count) return false;
            InventoryItems.RemoveAt(itemIndex);
            return true;
        }

        public bool RemoveItem(PaperItem itemToRemove)
        {
            var ItemIndex = InventoryItems.IndexOf(itemToRemove);
            return RemoveItem(ItemIndex);
        }

        public PaperItem GetItem(int itemIndex)
        {
            if (itemIndex == -1 || itemIndex >= InventoryItems.Count) throw new ArgumentOutOfRangeException("You tried to get item of index " + itemIndex + " and it is out of bounds");
            return InventoryItems[itemIndex];
        }

        public int GetInventoryCount()
        {
            return InventoryItems.Count;
        }
    }
}
