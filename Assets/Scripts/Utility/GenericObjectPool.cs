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
        public List<PooledItem<T>> pooledItems = new();

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
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreateItem();
            newItem.IsUsed = true;
            pooledItems.Add(newItem);
            return newItem.Item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException("Child class not implemented!");
        }

        public void ReturnItem(T item)
        {
            PooledItem<T> pooledItem = pooledItems.Find(i=>i.Item.Equals(item));
            pooledItem.IsUsed = false;
        }
    }
}