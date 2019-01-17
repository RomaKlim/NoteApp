using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Model
{
    /// <summary>
    /// Перечень всех записок.
    /// </summary>
    public class ListNotes
    {
        public List<Note> Notes;

        public Note LastSelectedNote = null;

        public ListNotes()
        {
            Notes = new List<Note>();
        }

        public void Sort()
        {
            Notes.Sort((a, b) => b.LastChangeTime.CompareTo(a.LastChangeTime));
        }

        public List<Note> Sort(int category)
        {
            Sort();
            if (category >= 0)
            {
                return Notes.FindAll(a => a.Category == (NoteCategory)category);
            }
            return Notes;
        }
    }


}
