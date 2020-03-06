using Newtonsoft.Json;
using System;

namespace NoteApp.Model
{
    /// <summary>
    /// Класс заметки.
    /// </summary>
    public class Note
    {
        private string _name = "Без имени";
        private NoteCategory _category;
        private string _text;
        private DateTime _dateCreate = DateTime.Now;
        private DateTime _dateChange = DateTime.Now;

        /// <summary>
        /// Методы set и get для поля _name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 50)
                {
                    _name = value;
                    _dateChange = DateTime.Now;
                }
                else
                {
                    throw new ArgumentException("value.Length > 50");
                }
            }
        }

        /// <summary>
        /// Методы set и get для поля _category.
        /// </summary>
        public NoteCategory Category
        {
            get
            {
                return _category;
            }
            set
            {
                try
                {
                    _category = value;
                    _dateChange = DateTime.Now;
                }
                catch
                {
                    throw new ArgumentOutOfRangeException("Category falled");
                }
            }
        }
        /// <summary>
        /// Методы set и get для поля _text.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                _dateChange = DateTime.Now;
            }
        }
        /// <summary>
        /// Методы set и get для поля DateCreate.
        /// </summary>
        [JsonProperty]
        public DateTime DateCreate
        {
            get
            {
                return _dateCreate;
            }
            private set
            {
                if (value.Year < 2014)
                    value = DateTime.Now;
                _dateCreate = value;
            }
        }
        /// <summary>
        /// Методы set и get для поля _dateChange.
        /// </summary>
        [JsonProperty]
        public DateTime DateChange
        {
            get
            {
                return _dateChange;
            }
            private set
            {
                if (value.Year < 2014)
                    value = DateTime.Now;
                _dateChange = value;
            }
        }
    }
}