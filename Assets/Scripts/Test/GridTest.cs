using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Test
{
    public class GridTest : MonoBehaviour
    {
        public Stack<Transform> _stack = new Stack<Transform> ();
        public Transform _holder;
        public const int StackCap = 3;
        public int _stackOffsetY;
        public int _stackOffsetZ;

        private void Awake()
        {
            //_holder.position = new Vector3(_holder.position.x, _stackOffsetY, _stackOffsetZ);
        }

        private void AddStackToHolder(Transform o)
        {
            o.parent = _holder;
        }

        private void AddStack(Transform o)
        {
            AddStackToHolder(o);
            if(_stackOffsetY < StackCap)
            {
                _stack.Push(o);
                o.localPosition = new Vector3 (0, _stackOffsetY, _stackOffsetZ);
                _stackOffsetY++;
                return;
            }
            else if(_stackOffsetY >= StackCap)
            {
                _stack.Push(o);
                _stackOffsetY = 0;
                _stackOffsetZ++;
                o.localPosition = new Vector3(0, _stackOffsetY, _stackOffsetZ);
                _stackOffsetY++;
                return;
            }
        }

        private void RemoveStack()
        {
            Debug.Log("before pop : " + _stack.Count);
            Transform stack = _stack.Pop ();
            Debug.Log("after pop : " + _stack.Count);
            stack.gameObject.SetActive(false);//test purpose
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("StackContainer") && CompareTag("Player"))
            {
                RemoveStack();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Money"))
            {
                other.tag = null;
                AddStack(other.transform);
            }
        }
    }
}
