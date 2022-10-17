using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Test
{
    public class StackManager
    {
        public Stack<Transform> _stack = new Stack<Transform>();
        public Transform _holder;
        public const int StackCap = 10;
        public int _stackOffsetY;
        public int _stackOffsetZ;

        public StackManager(Transform holder)
        {
            _holder = holder;
        }

        private void AddStackToHolder(Transform o)
        {
            o.parent = _holder;
        }

        public void AddStack(Transform o)
        {
            AddStackToHolder(o);
            if (_stackOffsetY < StackCap)
            {
                o.tag = "Untagged";
                _stack.Push(o);
                o.localPosition = new Vector3(0, _stackOffsetY, _stackOffsetZ);
                _stackOffsetY++;
                return;
            }
            else if (_stackOffsetY >= StackCap)
            {
                o.tag = "Untagged";
                _stack.Push(o);
                _stackOffsetY = 0;
                _stackOffsetZ++;
                o.localPosition = new Vector3(0, _stackOffsetY, _stackOffsetZ);
                _stackOffsetY++;
                return;
            }
        }

        public void RemoveStack()
        {

            if (_stack.Count == 0) return;
            Transform stack = _stack.Pop();
            if (_stackOffsetY == 0)
            {
                _stackOffsetY = StackCap - 1;
                _stackOffsetZ--;
                stack.gameObject.SetActive(false);//test purpose
                return;
            }
            _stackOffsetY--;
            stack.gameObject.SetActive(false);//test purpose
        }

        public void RemoveAllStack()
        {
            foreach(var stack in _stack)
            {
                if (_stack.Count == 0) return;
                Transform _transform = _stack.Pop();
                if (_stackOffsetY == 0)
                {
                    _stackOffsetY = StackCap - 1;
                    _stackOffsetZ--;
                    _transform.gameObject.SetActive(false);//test purpose
                    return;
                }
                _stackOffsetY--;
                _transform.gameObject.SetActive(false);//test purpose
            }
            _stackOffsetZ = 0;
            _stackOffsetY = 0;


        }

        

    }
}