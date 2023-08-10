using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SandwicheStoreProj
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization;

    namespace SandwicheStoreProj
    {
        public class SaveCatalog<T>
        {
            private List<T> items = new List<T>();
            string FileName {  get; set; }

            public SaveCatalog(string fileName) { FileName = fileName; }
            public void AddItem(T item)
            {
                Load();
                items.Add(item);
                Save();
            }
            public List<T> GetCatalog()
            {
                Load();
                return items;
            }

            public void Load()
            {
                try
                {
                    string fileName = GetCatalogFilePath();
                    if (File.Exists(fileName))
                    {
                        using (var stream = new FileStream(fileName, FileMode.Open))
                        {
                            var serializer = new DataContractSerializer(typeof(List<T>));
                            items.Clear();
                            items.AddRange((List<T>)serializer.ReadObject(stream));
                        }
                    }
                    else
                    {
                        Debug.WriteLine("File doesn't exist, handle accordingly");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error while loading the catalog: " + ex.Message);
                }
            }

            public void Save()
            {
                try
                {
                    string fileName = GetCatalogFilePath();
                    using (var stream = new FileStream(fileName, FileMode.Create))
                    {
                        var serializer = new DataContractSerializer(typeof(List<T>));
                        serializer.WriteObject(stream, items);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error while saving the catalog: " + ex.Message);
                }
            }
            private string GetCatalogFilePath()
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return Path.Combine(documentsPath, FileName);
            }
        }
    }
}