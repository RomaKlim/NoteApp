using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp.UI;
using NoteApp.Model;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture] // Для того чтобы VS и adapter могли отличить простой класс от класса тестов.
    class NoteTests
    {
        /// <summary>
        /// Unit тест для проверки геттера Name в классе Note.
        /// </summary>
        /// 
        [Test(Description = "Позитивный тест геттера Tittle")]
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

        [Test(Description = "Негативный тест cеттера Name, присваивание более 50 значений.")]
        public void TestTitleSet_BadValue()
        {
            var wrongTitle = "NameNameNameNameNameNameNameNameNameNameNameNameName";
            var note = new Note();
            note.Name = wrongTitle;
            Assert.Throws<ArgumentException>(
                () => { note.Name = wrongTitle; }, "Должно возникать исключение, если значение длинее 50 символов.");
        }
    }
}