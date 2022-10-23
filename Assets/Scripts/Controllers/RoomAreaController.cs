using Assets.Scripts.Signals;
using Data.ValueObject;
using Interfaces;
using Managers;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class RoomAreaController : MonoBehaviour , ISaveAble
    {
        [SerializeField] private RoomData data;
        [SerializeField] private GameObject room;
        [SerializeField] private GameObject roomUnlockArea;
        [SerializeField] private TMP_Text text;

        private Renderer _renderer;
        private int _payedAmouth;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            Init();
        }

        public void Load()
        {
            if (SaveAndLoadManager.CheackFileExist(gameObject.name + ScoreSignals.Instance.onGetLevel().ToString()))
            {
                data = (RoomData)SaveAndLoadManager.Load<RoomData>(gameObject.name + ScoreSignals.Instance.onGetLevel().ToString());
                _payedAmouth = data.RoomPayedAmouth;
                return;
            }
            else
            {
                data = new RoomData();
            }
        }

        private void Save()
        {
            data.RoomPayedAmouth = _payedAmouth;
            SaveAndLoadManager.Save(data, gameObject.name + ScoreSignals.Instance.onGetLevel().ToString()) ;
        }

        private void RoomIsOpened()
        {
            if(data.RoomPayedAmouth >= data.RoomCost)
            {
                room.SetActive(true);
                roomUnlockArea.SetActive(false);
                return;
            }
            else
            {
                room.SetActive(false);
                roomUnlockArea.SetActive(true);
                text.text = (data.RoomCost - data.RoomPayedAmouth).ToString();
            }
        }

        private void BuyRoom()
        {
            if(_payedAmouth >= data.RoomCost)
            {
                room.SetActive(true);
                roomUnlockArea.SetActive(false);
                Save();
                return;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player") && ScoreSignals.Instance.onGetMoney() > 0)
            {
                _payedAmouth++;
                text.text = (data.RoomCost - _payedAmouth).ToString();
                RadianFillAnimation();
                BuyRoom();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                ResetRadianFill(); ;
                Save();
            }
        }

        private void RadianFillAnimation()
        {
            float filletAmount = 360 - (data.RoomPayedAmouth * 360 / data.RoomCost);
            _renderer.material.DOFloat(filletAmount, "_Arc2", 0.05f);
        }

        private void ResetRadianFill()
        {
            _renderer.material.SetFloat("_Arc2", 360);
        }
        private void Init()
        {
            Load();
            RoomIsOpened();
        }
    }
}