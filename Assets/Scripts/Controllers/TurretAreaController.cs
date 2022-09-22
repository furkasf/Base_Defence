﻿using Data.ValueObject;
using System.Collections;
using Interfaces;
using TMPro;
using UnityEngine;
using Enums;
using Managers;

namespace Assets.Scripts.Controllers
{
    public class TurretAreaController : MonoBehaviour, ISaveAble
    {
        public BuyStates State = BuyStates.Buyed;

        [SerializeField] GameObject turretPrefab;
        [SerializeField] GameObject turretBuyArea;
        [SerializeField] TMP_Text text;
        [SerializeField] TurretData data;

        private int _payedAmouth;

        private void Awake()
        {
            Init();
        }

        public void Load()
        {
            if(SaveAndLoadManager.CheackFileExist(gameObject.name))
            {
                data = (TurretData)SaveAndLoadManager.Load<TurretData>(gameObject.name);
                _payedAmouth = data.TurretAreaPayedAmouth;
                return;
            }
            else
            {
                Debug.Log("not save file founded");
                data = new TurretData();
            }
        }

        private void Save()
        {
            data.TurretAreaPayedAmouth = _payedAmouth;
            SaveAndLoadManager.Save(data, gameObject.name);
        }

        private void CheackTurretAreaIsAcrtive()
        {
            if(data.IsActive == false)
            {
                turretPrefab.SetActive(false);
                turretBuyArea.SetActive(true);
                text.text = (data.TurretAreaPrice - data.TurretAreaPayedAmouth).ToString();
            }
            else if(data.IsActive == true)
            {
                turretPrefab.SetActive(true);
                turretBuyArea.SetActive(false);
            }
        }

        private void BuyTurretArea(int payment)
        {
            if(payment >= data.TurretAreaPrice)
            {
                turretBuyArea.SetActive(false);
                turretPrefab.SetActive(true);
                data.IsActive = true;
                Save();
            }
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(data.IsActive && !data.TurretHasSolder && other.CompareTag("player"))
            {
                //move player to turret
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player") && !data.IsActive)
            {
                _payedAmouth++;
                Debug.Log(_payedAmouth);
                text.text = (data.TurretAreaPrice - _payedAmouth).ToString();
                BuyTurretArea(_payedAmouth);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("player") && !data.IsActive)
            {
                Save();
            }
        }

        private void Init()
        {
            Load();
            CheackTurretAreaIsAcrtive();
        }
    }
}