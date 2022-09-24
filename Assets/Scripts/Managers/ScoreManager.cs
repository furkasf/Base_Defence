using Assets.Scripts.Signals;
using Data.ValueObject;
using Interfaces;
using Managers;
using Signals;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class ScoreManager : MonoBehaviour, ISaveAble
    {
        [SerializeField] private ScoreData data;

        private void Awake()
        {
            Load();
        }


        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onIncreaseMoney += OnIncreaseLevel;
            ScoreSignals.Instance.onDecreaseMoney += OnDecreaseMoney;
            ScoreSignals.Instance.onIncreaseDiamond += OnIncreaseDiamond;
            ScoreSignals.Instance.onDecreaseDiamond += OnDecreaseDiamond;
            ScoreSignals.Instance.onIncreaseLevel += OnIncreaseLevel;
            ScoreSignals.Instance.onSave += Save;
            ScoreSignals.Instance.onGetMoney += OnGetMoney;
            ScoreSignals.Instance.onGetDiamond += OnGetDiamond;
            ScoreSignals.Instance.onGetLevel += OnGetLevel;
            ScoreSignals.Instance.onGetScoreData += OnGetScoreData;
        }

        private void UnsubscribeEvents()
        {

            ScoreSignals.Instance.onIncreaseMoney -= OnIncreaseLevel;
            ScoreSignals.Instance.onDecreaseMoney -= OnDecreaseMoney;
            ScoreSignals.Instance.onIncreaseDiamond -= OnIncreaseDiamond;
            ScoreSignals.Instance.onDecreaseDiamond -= OnDecreaseDiamond;
            ScoreSignals.Instance.onIncreaseLevel -= OnIncreaseLevel;
            ScoreSignals.Instance.onSave -= Save;
            ScoreSignals.Instance.onGetMoney -= OnGetMoney;
            ScoreSignals.Instance.onGetDiamond -= OnGetDiamond;
            ScoreSignals.Instance.onGetLevel -= OnGetLevel;
            ScoreSignals.Instance.onGetScoreData -= OnGetScoreData;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion Event Subscription

        public void Load()
        {
            if (SaveAndLoadManager.CheackFileExist(gameObject.name))
            {
                data = (ScoreData)SaveAndLoadManager.Load<ScoreData>(gameObject.name);

            }
            else
            {
                data = new ScoreData();
            }
        }

        public void Save() => SaveAndLoadManager.Save(data, gameObject.name);

        private void OnIncreaseMoney() => data.MoneyScore += 1;
        private void OnDecreaseMoney() => data.MoneyScore -= 1;
        private void OnIncreaseDiamond() => data.DiomondScore += 1;
        private void OnDecreaseDiamond() => data.DiomondScore -= 1;
        private void OnIncreaseLevel() => data.Level += 1;

        private int OnGetLevel() => data.Level;
        private int OnGetMoney() => data.MoneyScore;
        private int OnGetDiamond() => data.DiomondScore;

        private ScoreData OnGetScoreData() => data;
    }
}