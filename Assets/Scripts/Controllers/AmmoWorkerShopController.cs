using Assets.Scripts.Signals;
using Data.ValueObject;
using Interfaces;
using Managers;
using Enums;
using Signals;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class AmmoWorkerShopController : MonoBehaviour, ISaveAble
    {
        [SerializeField] private Transform ammoWorkerSpawnArea;
        [SerializeField] private AmmoWorkerData data;
        [SerializeField] private TMP_Text text;

        private int _totalCreatedWorkerCount = 0;//by default
        private int _payedAmouth;
        private float _timer;

        private void Start()
        {
            Init();
        }

        public void Load()
        {
            if (SaveAndLoadManager.CheackFileExist(gameObject.name))
            {
                data = (AmmoWorkerData)SaveAndLoadManager.Load<AmmoWorkerData>(gameObject.name + ScoreSignals.Instance.onGetLevel().ToString());
                _totalCreatedWorkerCount = data.TotalExistMoneyWorker;
                _payedAmouth = data.AmmoWorkerpayedAmount;
                GetSavedWorker();
                text.text = (data.AmmoWorkerCost - _payedAmouth).ToString();
                return;
            }
            else
            {
                data = new AmmoWorkerData();
                text.text = (data.AmmoWorkerCost - _payedAmouth).ToString();
            }
        }

        private void Save()
        {
            data.TotalExistMoneyWorker = _totalCreatedWorkerCount;
            data.AmmoWorkerpayedAmount = _payedAmouth;
            SaveAndLoadManager.Save(data, gameObject.name + ScoreSignals.Instance.onGetLevel().ToString());
            text.text = (data.AmmoWorkerCost - _payedAmouth).ToString();
        }

        private void BuyNewWorker()
        {
            if (_payedAmouth >= data.AmmoWorkerCost)
            {
                _totalCreatedWorkerCount++;
                _payedAmouth = 0;
                GameObject worker = PoolSignals.onGetObjectFormPool(PoolAbleType.AmmoWorker.ToString());
                //worker.transform.SetParent(ammoWorkerSpawnArea);
                worker.transform.position = ammoWorkerSpawnArea.position;
                Save();
            }
        }

        private void GetSavedWorker()
        {
            for(int i =0; i < _totalCreatedWorkerCount; i++)
            {
                GameObject worker = PoolSignals.onGetObjectFormPool(PoolAbleType.AmmoWorker.ToString());
                worker.transform.SetParent(ammoWorkerSpawnArea);
                worker.transform.position = ammoWorkerSpawnArea.position;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && ScoreSignals.Instance.onGetMoney() > 0)
            {
                _timer += Time.smoothDeltaTime;
                if(_timer > .01f)
                {
                    _payedAmouth++;
                    text.text = (data.AmmoWorkerCost - _payedAmouth).ToString();
                    ScoreSignals.Instance.onDecreaseMoney();
                    BuyNewWorker();
                    _timer = 0;
                }
                
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