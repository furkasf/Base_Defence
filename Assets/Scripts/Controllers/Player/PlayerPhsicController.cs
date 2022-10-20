﻿using Assets.Scripts.Managers;
using Assets.Scripts.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerPhsicController : MonoBehaviour
    {
        [SerializeField] private PlayerManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Hostage"))
            {
                HostageSignals.Instance.onAddStack(other.transform);
                Debug.Log("hostageIncluded to list");
            }
            if (other.CompareTag("MineArea"))
            {
                HostageSignals.Instance.onClearStack();
            }
        }
    }
}