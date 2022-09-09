using System;
using System.Collections.Generic;
using UnityEngine;

namespace GenericPoolSystem
{
    public class ObjectPool<T> : AbstractObjectPool

    {
        #region Self Variables

        private readonly List<T> _currentStock;
        private readonly bool _isDynamic;
        private readonly Func<T> _factoryMethod;
        private readonly Action<T> _turnOnCallback;
        private readonly Action<T> _turnOffCallback;

        #endregion Self Variables

        /// <summary>
        ///we set our datas from constructor for read to set our pools
        /// </summary>
        /// <param name="factoryMethod">whick use to construct object</param>
        /// <param name="turnOnCallback">activate passive object </param>
        /// <param name="turnOffCallback">disactive active object</param>
        /// <param name="initialStock">start initial size pool for in start</param>
        /// <param name="isDynamic">use to set that list is resize able or not</param>
        public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
        {
            _factoryMethod = factoryMethod;
            _isDynamic = isDynamic;

            _turnOffCallback = turnOffCallback;
            _turnOnCallback = turnOnCallback;

            _currentStock = new List<T>();

            for (var i = 0; i < initialStock; i++)
            {
                var o = _factoryMethod();
                _turnOffCallback(o);
                _currentStock.Add(o);
            }
        }

        //initialize pool with given list
        public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, List<T> initialStock, bool isDynamic = true)
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
                result = _currentStock[0];
                // _turnOnCallback(result);
                _currentStock.RemoveAt(0);
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
            _currentStock.Add(o);
        }
    }

    class Genetic<K, F>
    {
        K getdedault(K data)
        {
            var rsult = default(K);
            rsult = (data != null) ? data : default(K);
            return rsult;
        }
    }
}