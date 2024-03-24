using System;
using System.Collections.Generic;

namespace Utility
{
    public class PooledItem<T>
    {
        public T Item;
        public bool IsUsed;
    }
    
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new();

        public T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> pooledItem = pooledItems.Find(item => !item.IsUsed);
                if (pooledItem != null)
                {
                    pooledItem.IsUsed = true;
                    return pooledItem.Item;
                }
            }

            return CreateNewItem();
        }

        private T CreateNewItem()
        {
            PooledItem<T> pooledItem = new PooledItem<T>();
            pooledItem.Item = CreateItem();
            pooledItem.IsUsed = true;
            pooledItems.Add(pooledItem);
            return pooledItem.Item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException("Child class not implemented!");
        }

        public void ReturnItem(T Item)
        {
            PooledItem<T> pooledItem = pooledItems.Find(item => item.Equals(Item));
            pooledItem.IsUsed = false;
        }
    }
}