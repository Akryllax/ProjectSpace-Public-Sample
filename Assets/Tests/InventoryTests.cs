using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InventoryTests
    {
        DefaultPlayerInventory inv;
        BaseInventoryItem item1 = new BaseInventoryItem(1, "ITEM 1", "TEST ITEM 1");
        BaseInventoryItem item2 = new BaseInventoryItem(1, "ITEM 2", "TEST ITEM 2");
        BaseInventoryItem item3 = new BaseInventoryItem(1, "ITEM 3", "TEST ITEM 3");

        [Test]
        public void Inventory_AddingItems_Ok()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            
            //Init objects
            var go = new GameObject();
            inv = go.AddComponent<DefaultPlayerInventory>();
            inv.Awake();

            //Correclty created
            Assert.IsNotNull(inv);

            //Initial size 0
            Assert.AreEqual(0, inv.InventoryCapacity);

            //Set capacity to 10
            inv.SetCapacity(10);
            Assert.AreEqual(10, inv.InventoryCapacity);

            //Add 1 item
            inv.AddItem(item1);
            Assert.AreEqual(1, inv.GetCount());

            //Add 2 items
            inv.AddItem(item2);
            inv.AddItem(item3);
            Assert.AreEqual(3, inv.GetCount());

            //Remove 1 item
            Assert.IsTrue(inv.RemoveItem(1));

            //Get correct count
            Assert.AreEqual(2, inv.GetCount());
        }

         [Test]
         public void Inventory_GetItem_Ok()
        {
            Assert.AreEqual("ITEM 2", inv.GetItem(0).ItemName);
        }

        [Test]
        public void Inventory_RemoveItem_Ok()
        {
            int originalCount = inv.GetCount();

            Assert.IsNotNull(inv.DropItem(item1));
            Assert.AreEqual(originalCount - 1, inv.GetCount());
        }
    }
}
