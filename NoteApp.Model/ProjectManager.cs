using System.IO;
using Newtonsoft.Json;
namespace NoteApp.Model
{
    /// <summary>
    /// Класс Сериализации, с помощью которого выполняется загрузка/выгрузка информации в формате JSON.
    /// </summary>
    public static class ProjectManager
    {
        public static void Serializer(Project project, string path)
        {
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(path + "/Note.nt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
        }
        
        public static Project Deserializer(string path)
        {
            //Создаём переменную, в которую поместим результат десериализации
            Project project = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (StreamReader sr = new StreamReader(path + "/Note.nt"))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                    project = (Project)serializer.Deserialize<Project>(reader);
                }
                return project;
            }
            catch
            {
                return new Project();
            }
        }
    }
}