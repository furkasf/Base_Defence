using Assets.Scripts.Signals;
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
                Debug.Log(text.text);
                BuyNewWorker();
                return;
            }
            else
            {
                data = new TurretData();
                text.text = (data.TurretWorkerPrice - _payedAmouth).ToString();
                _payedAmouth = data.TurretWorkerPayedAmouth;
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

        public bool CheackTurretWorkerExist() => turretWoker.active;

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