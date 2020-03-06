using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NoteApp.Model;
using NUnit.Framework;


namespace ProjectTests
{
    [TestFixture]
    internal class ProjectManagerTest
    {
        [Test(Description = "Проверка сериализации")]
        public void TestSaveToFile_CorrectValue()
        {
            var example = new Project { ListNote = new List<Note>() };
            Note note = new Note();
            note.Name = "Name";
            note.Text = "Text";
            note.Category = NoteCategory.Job;
            example.ListNote.Add(note);
            Note note1 = new Note();
            note1.Name = "Name";
            note1.Text = "Text";
            note1.Category = NoteCategory.Job;
            example.ListNote.Add(note1);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ProjectManager.Serializer(example, path);
            string fileName = path + "/Note.nt";
            var expected = File.ReadAllText(fileName);
            var actual = File.ReadAllText(fileName);

            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }
        [Test(Description = "Проверка десериализации")]
        public void TestLoadFromFile_CorrectValue()
        {
            var actual = new Project { ListNote = new List<Note>() };
            Note note = new Note();
            note.Name = "Name";
            note.Text = "Text";
            note.Category = NoteCategory.Job;
            actual.ListNote.Add(note);
            Note note1 = new Note();
            note1.Name = "Name";
            note1.Text = "Text";
            note1.Category = NoteCategory.Job;
            actual.ListNote.Add(note1);
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var expected = ProjectManager.Deserializer(path);
            for (int i = 0; i < actual.ListNote.Count; i++)
            {
                Assert.AreEqual(actual.ListNote[i].Name, expected.ListNote[i].Name,
               "Сравнение результата десериализованного обьекта и ожидаемого");

                Assert.AreEqual(actual.ListNote[i].Text, expected.ListNote[i].Text,
               "Сравнение результата десериализованного обьекта и ожидаемого");

                Assert.AreEqual(actual.ListNote[i].Category, expected.ListNote[i].Category,
               "Сравнение результата десериализованного обьекта и ожидаемого");
            }
        }
    }
}
