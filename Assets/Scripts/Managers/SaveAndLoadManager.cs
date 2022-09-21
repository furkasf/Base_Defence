using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FrameworkGoat
{
    public static class SaveAndLoadManager
    {
        
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
            var fs = File.Create(Application.persistentDataPath + "/"+ fileName);
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
            var fs = File.Open(Application.persistentDataPath + "/"+ fileName, FileMode.Open);
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