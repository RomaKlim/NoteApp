using System.Collections.Generic;
using System.Linq;

namespace NoteApp.Model
{
    public class Project
    {
        /// <summary>
        /// Tекущая заметка.
        /// </summary>
        private int _currentNote = -1;

        /// <summary>
        /// Cписок заметка.
        /// </summary>
        private List<Note> _listNote = new List<Note>();

        /// <summary>
        /// Свойство текущей заметки
        /// </summary>
        public int CurrentNote
        {
            get
            {
                return _currentNote;
            }
            set
            {
                _currentNote = value;
            }
        }

        /// <summary>
        /// Свойство лсита заметок.
        /// </summary>
        public List<Note> ListNote
        {
            get
            {
                return _listNote;
            }
            set
            {
                _listNote = value;
            }
        }

        /// <summary>
        ///     Сортировка списка заметок.
        /// </summary>
        public List<Note> SortedListNote()
        {
            IEnumerable<Note> sortListNote = this.ListNote.OrderBy(note => note.DateChange);
            return sortListNote.ToList();
        }
    }
}