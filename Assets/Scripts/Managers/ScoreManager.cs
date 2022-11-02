using Assets.Scripts.Signals;
using Data.ValueObject;
using Interfaces;
using Managers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class ScoreManager : MonoBehaviour, ISaveAble
    {
        [SerializeField] private ScoreData data;
        [SerializeField] private TMP_Text money;
        [SerializeField] private TMP_Text diamond;

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
            ScoreSignals.Instance.onIncreaseMoney += OnIncreaseMoney;
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
            ScoreSignals.Instance.onIncreaseMoney -= OnIncreaseMoney;
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
                money.text = data.MoneyScore.ToString();
                diamond.text = data.DiomondScore.ToString();
            }
            else
            {
                data = new ScoreData();
                money.text = data.MoneyScore.ToString();
                diamond.text = data.DiomondScore.ToString();
            }
        }

        public void Save() => SaveAndLoadManager.Save(data, gameObject.name);

        private void OnIncreaseMoney(int count)
        {
            data.MoneyScore += count;
            money.text = data.MoneyScore.ToString();
        }

        private void OnDecreaseMoney()
        {
            data.MoneyScore -= 1;
            money.text = data.MoneyScore.ToString();
        }

        private void OnIncreaseDiamond(int count)
        {
            data.DiomondScore += count;
            diamond.text = data.DiomondScore.ToString();
        }

        private void OnDecreaseDiamond()
        {
            data.DiomondScore -= 1;
            diamond.text = data.DiomondScore.ToString();
        }

        private void OnIncreaseLevel() => data.Level += 1;

        private int OnGetLevel() => data.Level;

        private int OnGetMoney() => data.MoneyScore;

        private int OnGetDiamond() => data.DiomondScore;

        private ScoreData OnGetScoreData() => data;
    }
}