using System;
using NoteApp.Model;
using NUnit.Framework;

namespace NoteTests
{
    [TestFixture] // Для того чтобы VS и adapter могли отличить простой класс от класса тестов.
    class NoteTests
    {
        /// <summary>
        /// Unit тест для проверки геттера Name в классе Note.
        /// </summary>
        /// 
        [Test(Description = "Позитивный тест геттера Name")]
        public void TestTitleGet_CorrectValue()
        {
            var expected = "Заголовок";
            var note = new Note();
            note.Name = expected;
            var actual = note.Name;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильный заголовок.");
        }

        [Test(Description = "Позитивный тест cеттера Name")]
        public void TestTitleSet_CorrectValue()
        {
            var expected = "Заголовок_заметки";
            var note = new Note();
            note.Name = "Заголовок_заметки";
            note.Name = expected;
            Assert.AreEqual(expected, note.Name, "Cеттер Name  устанавливает неправильное значение.");
        }
        [Test(Description = "Позитивный тест cеттера Text")]
        public void TestTextSet_CorrectValue()
        {
            var expected = "Text";
            var note = new Note();
            note.Name = "Text";
            note.Name = expected;
            Assert.AreEqual(expected, note.Name, "Cеттер Text  устанавливает неправильное значение.");
        }
        [Test(Description = "Позитивный тест геттера Text")]
        public void TestText_CorrectValue()
        {
            var expected = "Text";
            var note = new Note();
            note.Name = expected;
            var actual = note.Name;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильный Text.");
        }
        [Test(Description = "Позитивный тест геттера Name")]
        public void TestCategoryGet_CorrectValue()
        {
            var expected = NoteCategory.Job;
            var note = new Note();
            note.Category = expected;
            var actual = note.Category;

            Assert.AreEqual(expected, actual, "Геттер Category возвращает неправильный заголовок.");
        }
        [Test(Description = "Позитивный тест cеттера Category")]
        public void TestCategorySet_CorrectValue()
        {
            var expected = NoteCategory.Job;
            var note = new Note();
            note.Category = NoteCategory.Job;
            note.Category = expected;
            Assert.AreEqual(expected, note.Category, "Cеттер Category  устанавливает неправильное значение.");
        }
        [Test(Description = "Проверка исключения сеттера Name")]
        public void TestSurnameSet_CorrectValue()
        {
            var wrongName = "NameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameNameName";
            var note = new Note();
            Assert.Throws<ArgumentException>(
                () => { note.Name = wrongName; },
                "-");
        }
    }
}