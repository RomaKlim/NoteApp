using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoteApp.Model
{
    public class ProjectManager
    {
        // Путь в папку "Документы".
        public static string PathToDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\NoteApp.notes";

        public static void SaveToFile(ListNotes listNotes, string fileTitle)
        {
            JsonSerializer serializer = new JsonSerializer();
            //Открытие потока
            using (StreamWriter sw = new StreamWriter(fileTitle))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаём объек для сериализации
                serializer.Serialize(writer, (ListNotes)listNotes);
            }
        }

        public static ListNotes Load(string fileTitle)
        {
            ListNotes notes = new ListNotes();
            //Создаём экземпляр сериализатора.
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути.
            using (StreamReader sr = new StreamReader(fileTitle))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию 
                var noteList = (ListNotes)serializer.Deserialize<ListNotes>(reader);
                notes = noteList;
            }

            return notes;
        }
    }
}