using UnityEngine;

namespace Script
{
    public class ItemCollected: MonoBehaviour
    {
        private string _itemName;
        private int _itemID;
        private int _itemCount;

        public string getItemName()
        {
            return _itemName;
        }
        public int getItemID()
        {
            return _itemID;
        }
        public int getItemCount()
        {
            return _itemCount;
        }
    }
}