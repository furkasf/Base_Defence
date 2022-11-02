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
        public float _stackOffsetY;
        public float _stackOffsetZ;
        public float _offsety;
        public float _offsetz;

        public StackManager(Transform holder, StackType type)
        {
            _holder = holder;
            this.type = type;
            _stackOffsetZ = _holder.localPosition.z;
            SetoffSets();
        }

        private void SetoffSets()
        {
            if(type == StackType.Money)
            {
                _stackOffsetY = 0.2f;
                _stackOffsetZ = 0.1f;
                return;
            }
            if (type == StackType.Ammo)
            {
                _stackOffsetY = 0.55f;
                _stackOffsetZ = 0.5f;
                return;
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

            o.localPosition = new Vector3(0, _offsety, _offsetz);
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
                o.GetComponent<BoxCollider>().enabled = false;
            }
            if (_stack.Count % StackCap != 0)
            {
                o.tag = "Untagged";
                _offsety += _stackOffsetY;
                AddStackToHolder(o);
                return;
            }
            else
            {
                o.tag = "Untagged";
                _offsety = 0;
                _offsetz += _stackOffsetZ;
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
                value.DOLocalMove(new Vector3(Random.Range(-2f, 2f), 0.75f, Random.Range(-2f, 2f)), .02f).SetEase(Ease.OutBack);
                value.DOLocalRotate(Vector3.zero, 0.02f);
                value.DOLocalMove(new Vector3(0, 0.75f, 0), 0.2f).OnComplete(() =>
                {
                    value.tag = type.ToString();
                    PoolSignals.onPutObjectBackToPool(value.gameObject, type.ToString());
                });
            }

            ResetOffsets();
        }

        public void RemoveAllStack(Action<Transform> add)
        {

            if (_stack.Count == 0) return;

            while (_stack.Count > 0)
            {
                Transform value = _stack.Pop();
                value.tag = type.ToString();
                add(value);
            }

            ResetOffsets();
        }

        public void ResetOffsets()
        {
            _offsety = 0;
            _offsetz = 0;
        }
    }
}