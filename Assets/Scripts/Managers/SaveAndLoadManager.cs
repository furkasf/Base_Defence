using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Keys;

namespace Managers
{
    public static class SaveAndLoadManager
    {

        public static Dictionary<string, object> SaveDatas;

        //write funtion wihch delete all save file in direrctory
        public static void RemoveAllFile()
        {
            if(SaveDatas == null)
            {
                Debug.Log("there is mo save file in directory");
            }
            foreach(var key in SaveDatas.Keys)
            {
                File.Delete(Application.persistentDataPath + "/" + key);
            }
        }

        public static void RemoveFile(string fileName)
        {
            foreach (var key in SaveDatas.Keys)
            {
                if(fileName == key)
                {
                    File.Delete(Application.persistentDataPath + "/" + key);
                    return;
                }
            }
            Debug.Log("there is mo save file in directory");
        }

        public static void GetAllSaveFile()
        {
            string[] files = Directory.GetFiles(Application.persistentDataPath);
            foreach (string file in files)
            {
                SaveDatas.Add(file, Load<SaveAbleParams>(file));
            }
        }

        public static bool CheackFileExist(string fileName) => File.Exists(Application.persistentDataPath + "/" + fileName);

        public static void Save(object saveFile)
        {
            var bf = new BinaryFormatter();
            var fs = File.Create(Application.persistentDataPath + "/GoatSave.g");
            bf.Serialize(fs, saveFile);
            fs.Close();
        }


        public static void Save(object saveFile, string fileName)
        {
            var bf = new BinaryFormatter();
            var fs = File.Create(Application.persistentDataPath + "/" + fileName);
            bf.Serialize(fs, saveFile);
            fs.Close();
        }

        public static void Save(object saveFile, string path, string fileName)
        {
            var bf = new BinaryFormatter();
            var fs = File.Create(path + fileName);
            bf.Serialize(fs, saveFile);
            fs.Close();
        }

        public static T Load<T>()
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(Application.persistentDataPath + "/GoatSave.g", FileMode.Open);
            T result = (T)bf.Deserialize(fs);
            fs.Close();
            return result;
        }

        public static T Load<T>(string fileName)
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);
            T result = (T)bf.Deserialize(fs);
            fs.Close();
            return result;
        }

      
        public static T Load<T>(string path, string fileName)
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(path + fileName, FileMode.Open);
            T result = (T)bf.Deserialize(fs);
            fs.Close();
            return result;
        }
    }
   

}