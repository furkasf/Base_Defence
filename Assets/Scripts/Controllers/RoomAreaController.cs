using Data.ValueObject;
using Interfaces;
using Managers;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class RoomAreaController : MonoBehaviour , ISaveAble
    {
        [SerializeField] RoomData data;
        [SerializeField] GameObject roomLock;
        [SerializeField] GameObject room;
        [SerializeField] GameObject roomUnlockArea;
        [SerializeField] TMP_Text text;

        private int _payedAmouth;

        private void Awake()
        {
            Init();
        }

        public void Load()
        {
            if (SaveAndLoadManager.CheackFileExist(gameObject.name))
            {
                data = (RoomData)SaveAndLoadManager.Load<RoomData>(gameObject.name);
                _payedAmouth = data.RoomPayedAmouth;
                return;
            }
            else
            {
                Debug.Log("not save file founded");
                data = new RoomData();
            }
        }

        private void Save()
        {
            data.RoomPayedAmouth = _payedAmouth;
            SaveAndLoadManager.Save(data, gameObject.name);
        }

        private void RoomIsOpened()
        {
            if(data.RoomPayedAmouth >= data.RoomCost)
            {
                room.SetActive(true);
                roomLock.SetActive(false);
                roomUnlockArea.SetActive(false);
                return;
            }
            else
            {
                room.SetActive(false);
                roomLock.SetActive(true);
                roomUnlockArea.SetActive(true);
                text.text = (data.RoomCost - data.RoomPayedAmouth).ToString();
            }
        }

        private void BuyRoom()
        {
            if(_payedAmouth >= data.RoomCost)
            {
                room.SetActive(true);
                roomLock.SetActive(false);
                roomUnlockArea.SetActive(false);
                Save();
                return;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                _payedAmouth++;
                text.text = (data.RoomCost - _payedAmouth).ToString();
                BuyRoom();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                Save();
            }
        }

        private void Init()
        {
            Load();
            RoomIsOpened();
        }
    }
}