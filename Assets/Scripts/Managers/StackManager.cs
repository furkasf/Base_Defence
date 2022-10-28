using Assets.Scripts.Signals;
using DG.Tweening;
using Enums;
using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public float _stackOffsetZ = 0;

        public StackManager(Transform holder, StackType type)
        {
            _holder = holder;
            this.type = type;
        }

        private void AddStackToHolder(Transform o)
        {
            o.parent = _holder;
            _stack.Push(o);
            o.localPosition = new Vector3(0, _stackOffsetY, _stackOffsetZ);
            o.localRotation = new Quaternion(0, 0, 0, 0);
        }

        public void AddStack(Transform o)
        {
            Debug.Log("oofset : " + _stackOffsetY);
            if (_stack.Count % StackCap != 0)
            {
                o.tag = "Untagged";
                AddStackToHolder(o);
                _stackOffsetY += o.localScale.y;
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

        public void ResetOffsets()
        {
            _stackOffsetY = 0.2f;
            _stackOffsetZ = 0;
        }
    }
}