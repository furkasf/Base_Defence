using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GenericPoolSystem
{
    public class ObjectPool<T> : AbstractObjectPool

    {
        #region Self Variables

        private readonly Queue<T> _currentStock;
        private readonly bool _isDynamic;
        private readonly Func<T> _factoryMethod;
        private readonly Action<T> _turnOnCallback;
        private readonly Action<T> _turnOffCallback;

        #endregion Self Variables

        
        public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
        {
            _factoryMethod = factoryMethod;
            _isDynamic = isDynamic;

            _turnOffCallback = turnOffCallback;
            _turnOnCallback = turnOnCallback;

            _currentStock = new Queue<T>();

            for (var i = 0; i < initialStock; i++)
            {
                var o = _factoryMethod();
                _turnOffCallback(o);
                _currentStock.Enqueue(o);
                UnityEngine.Debug.Log("ss");
            }
        }

       
        public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, Queue<T> initialStock, bool isDynamic = true)
        {
            _factoryMethod = factoryMethod;
            _isDynamic = isDynamic;

            _turnOffCallback = turnOffCallback;
            _turnOnCallback = turnOnCallback;

            _currentStock = initialStock;
        }

        //get object from pool
        public T GetObject()
        {
            var result = default(T);
            if (_currentStock.Count > 0)
            {
                result = _currentStock.Dequeue();
                _turnOnCallback(result);
            }
            else if (_isDynamic)
            {
                result = _factoryMethod();
                _turnOnCallback(result);
            }

            return result;
        }

        //get active object and put in pool
        public void ReturnObject(T o)
        {
            _turnOffCallback(o);
            _currentStock.Enqueue(o);
        }

        public override int GetPoolCurrentSize() => _currentStock.Count;

    }
}