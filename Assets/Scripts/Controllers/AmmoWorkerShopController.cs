using Assets.Scripts.Signals;
using Data.ValueObject;
using Interfaces;
using Managers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class AmmoWorkerShopController : MonoBehaviour, ISaveAble
    {
        [SerializeField] private GameObject workerBuyArea;
        [SerializeField] private AmmoWorkerData data;
        [SerializeField] private TMP_Text text;

        private int _totalCreatedWorkerCount = 0;//by default
        private int _payedAmouth;

        public void Load()
        {
            if (SaveAndLoadManager.CheackFileExist(gameObject.name))
            {
                data = (AmmoWorkerData)SaveAndLoadManager.Load<AmmoWorkerData>(gameObject.name + ScoreSignals.Instance.onGetLevel().ToString());
                _totalCreatedWorkerCount = data.TotalExistMoneyWorker;
                _payedAmouth = data.AmmoWorkerpayedAmount;
                text.text = (data.AmmoWorkerCost - _payedAmouth).ToString();
                return;
            }
            else
            {
                Debug.Log("not save file founded");
                data = new AmmoWorkerData();
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
                //get worker from pool
                Save();
            }
        }

        private void ReplaceExistedWorker()
        {
            if (_totalCreatedWorkerCount > 0)
            {
                //spawn workers from pool
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && ScoreSignals.Instance.onGetMoney() > 0)
            {
                _payedAmouth++;
                text.text = (data.AmmoWorkerCost - _payedAmouth).ToString();
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
            ReplaceExistedWorker();
        }
    }
}