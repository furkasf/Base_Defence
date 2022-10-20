﻿using Assets.Scripts.Signals;
using Data.ValueObject;
using Interfaces;
using Managers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers.Turret
{
    public class TurretSaveController : MonoBehaviour, ISaveAble
    {

        [SerializeField] private GameObject turretWoker;
        [SerializeField] private GameObject turretBuyArea;
        [SerializeField] private TurretData data;
        [SerializeField] private TMP_Text text;

        private bool _turretWorkerIsExist;
        private int _payedAmouth;

        private void Start()
        {
            Init();
        }

        public void Load()
        {
            if (SaveAndLoadManager.CheackFileExist(gameObject.name))
            {
                data = (TurretData)SaveAndLoadManager.Load<TurretData>(gameObject.name + ScoreSignals.Instance.onGetLevel().ToString());
                _turretWorkerIsExist = data.TurretWorkerPayedAmouth >= data.TurretWorkerPrice;
                _payedAmouth = data.TurretWorkerPayedAmouth;

                text.text = (data.TurretWorkerPrice - _payedAmouth).ToString();
                BuyNewWorker();
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
            data.TurretWorkerPayedAmouth = _payedAmouth;
            SaveAndLoadManager.Save(data, gameObject.name + ScoreSignals.Instance.onGetLevel().ToString());
            text.text = (data.TurretWorkerPrice - _payedAmouth).ToString();
        }

        private void BuyNewWorker()
        {
            if (_payedAmouth >= data.TurretWorkerPrice)
            {
                turretWoker.SetActive(true);
                data.TurretHasSolder = true;
                _turretWorkerIsExist = true;
                Save();
                turretBuyArea.SetActive(false);
            }
        }

        public bool CheackTurretWorkerExist() => _turretWorkerIsExist;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && ScoreSignals.Instance.onGetMoney() > 0)
            {
                _payedAmouth++;
                text.text = (data.TurretWorkerPrice - _payedAmouth).ToString();
                BuyNewWorker();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Save();
            }
        }

        private void Init()
        {
            Load();
        }
    }
}