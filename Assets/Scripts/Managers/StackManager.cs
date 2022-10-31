using Assets.Scripts.Signals;
using DG.Tweening;
using Signals;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
    public enum StackType
    {
        Ammo, Money
    }

    public class StackManager
    {
        public Stack<Transform> _stack = new Stack<Transform>();
        public Transform _holder;
        public const int StackCap = 5;
        private readonly StackType type;
        public float _stackOffsetY = 0.2f;
        public float _stackOffsetZ;

        public StackManager(Transform holder, StackType type)
        {
            _holder = holder;
            this.type = type;
            _stackOffsetZ = _holder.localPosition.z;
        }

        private void GetData()
        {
            if(type == StackType.Money)
            {

            }
        }

        public StackManager(Transform holder)
        {
            _holder = holder;
        }

        private void AddStackToHolder(Transform o)
        {
            o.parent = _holder;
            _stack.Push(o);
            Debug.Log("stack count" + _stack.Count);
            o.localPosition = new Vector3(0, _stackOffsetY, _stackOffsetZ);
            o.localRotation = new Quaternion(0, 0, 0, 0);
            if (type == StackType.Money)
            {
                o.localRotation = new Quaternion(-90, -90, 0, 0);
            }
           
        }

        public void AddStack(Transform o)
        {
            if(type == StackType.Money)
            {
                o.GetComponent<Rigidbody>().isKinematic = true;
            }
            if (_stack.Count % StackCap != 0)
            {
                o.tag = "Untagged";
                _stackOffsetY += (type == StackType.Ammo) ?o.localScale.y : 0.2f;
                AddStackToHolder(o);
                return;
            }
            else
            {
                o.tag = "Untagged";
                _stackOffsetY = 0.2f;
                _stackOffsetZ += o.localScale.z;
                AddStackToHolder(o);
                return;
            }
        }

        public void RemoveAllStack()
        {
            if (_stack.Count == 0) return;
            if (type == StackType.Money) ScoreSignals.Instance.onIncreaseMoney(_stack.Count);

            while (_stack.Count > 0)
            {
                Transform value = _stack.Pop();
                value.DOLocalMove(new Vector3(Random.Range(-2f, 2f), 0.75f, Random.Range(-2f, 2f)), .8f).SetEase(Ease.OutBack);
                value.DOLocalRotate(Vector3.zero, 0.1f);
                value.DOLocalMove(new Vector3(0, 0.75f, 0), 0.5f).SetDelay(1f).OnComplete(() =>
                {
                    value.tag = type.ToString();
                    PoolSignals.onPutObjectBackToPool(value.gameObject, type.ToString());
                });
            }

            ResetOffsets();
        }

        public void RemoveAllStack(Action<Transform> add)
        {
            Debug.Log("remoce stack");
            Debug.Log("stack count " +_stack.Count);

            if (_stack.Count == 0) return;

            while (_stack.Count > 0)
            {
                Transform value = _stack.Pop();
                Debug.Log("remoce stack");
                Debug.Log("Value name" + value.name);
                value.tag = type.ToString();
                add(value);
            }


            ResetOffsets();
        }

        public void ResetOffsets()
        {
            _stackOffsetY = 0.2f;
            _stackOffsetZ = _holder.localPosition.z;
        }
    }
}