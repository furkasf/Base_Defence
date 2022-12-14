using Assets.Scripts.Data.ValueObject.LevelData.BaseData;
using Assets.Scripts.Signals;
using Enums;
using Managers;
using Signals;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers.MoneyWorker
{
    public class MoneyWorkerShopController : MonoBehaviour
    {
        [SerializeField] private Transform MoneyWorkerSpawnArea;
        [SerializeField] private MoneyWorkerData data;
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
                data = (MoneyWorkerData)SaveAndLoadManager.Load<MoneyWorkerData>(gameObject.name + ScoreSignals.Instance.onGetLevel().ToString());
                _totalCreatedWorkerCount = data.TotalExistMoneyWorker;
                _payedAmouth = data.MoneyWorkerStackCapacity;
                GetSavedWorker();
                text.text = (data.MoneyWorkerCost - _payedAmouth).ToString();
                return;
            }
            else
            {
                data = new MoneyWorkerData();
                text.text = (data.MoneyWorkerCost - _payedAmouth).ToString();
            }
        }

        private void Save()
        {
            data.TotalExistMoneyWorker = _totalCreatedWorkerCount;
            data.MoneyWorkerPayedAmount = _payedAmouth;
            SaveAndLoadManager.Save(data, gameObject.name + ScoreSignals.Instance.onGetLevel().ToString());
            text.text = (data.MoneyWorkerCost - _payedAmouth).ToString();
        }

        private void BuyNewWorker()
        {
            if (_payedAmouth >= data.MoneyWorkerCost)
            {
                _totalCreatedWorkerCount++;
                _payedAmouth = 0;
                GameObject worker = PoolSignals.onGetObjectFormPool(PoolAbleType.MoneyWorker.ToString());
                worker.transform.SetParent(MoneyWorkerSpawnArea);
                worker.transform.position = MoneyWorkerSpawnArea.position;
                Save();
            }
        }

        private void GetSavedWorker()
        {
            for (int i = 0; i < _totalCreatedWorkerCount; i++)
            {
                GameObject worker = PoolSignals.onGetObjectFormPool(PoolAbleType.MoneyWorker.ToString());
                worker.transform.SetParent(MoneyWorkerSpawnArea);
                worker.transform.position = MoneyWorkerSpawnArea.position;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && ScoreSignals.Instance.onGetMoney() > 0)
            {
                _timer += Time.smoothDeltaTime;
                if(_timer > 0.01f)
                {
                    _payedAmouth++;
                    text.text = (data.MoneyWorkerCost - _payedAmouth).ToString();
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