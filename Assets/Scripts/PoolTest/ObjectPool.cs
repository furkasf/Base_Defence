using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PoolTest
{
    public class ObjectPool<T>
    {
        #region Self Varaibles

        private readonly List<T> _pool;
        private readonly int _poolSize;
        private readonly bool _poolIsDynamic;
        private readonly Func<T> _objectFactory;
        private readonly Action<T> _putObjectToPoolBack;
        private readonly Action<T> _getObjectFromPool;

        #endregion

        public ObjectPool(List<T> pool, int poolSize, bool poolIsDynamic, Action<T> putObjectToPoolBack, Action<T> getObjectFromPool, Func<T> objectFactory)
        {
            _pool = pool;
            _poolSize = poolSize;
            _poolIsDynamic = poolIsDynamic;
            _objectFactory = objectFactory;
            _putObjectToPoolBack = putObjectToPoolBack;
            _getObjectFromPool = getObjectFromPool;
        }

        public T GetObject()
        {
            var result = default(T);

            if(_pool.Count > 0)
            {
                result = _pool[0];
                _pool.Remove(result);
            }

            else if(_poolIsDynamic)
            {
                result = _objectFactory();
                _getObjectFromPool(result);
            }

            return result;
        }

        public void ReturnObject(T _object)
        {
            _putObjectToPoolBack(_object);
            _pool.Add(_object);
        }



    }
}
