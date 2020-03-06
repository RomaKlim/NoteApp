using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NoteApp.Model;

namespace NoteApp.UI
{
    /// <summary>
    /// Главная форма.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// _project - список заметок.
        /// lenghtEnum - длина перечисления.
        /// path - путь сохранения.
        /// </summary>
        private Project _project;
        private int lenghtEnum = 0;
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// инициализация лавная форма.
        /// </summary>
        public MainForm()
        {
            _project = ProjectManager.Deserializer(path);
            InitializeComponent();
            this.KeyPreview = true;
            foreach (var category in Enum.GetValues(typeof(NoteCategory)))
            {
                ComboBoxCategory.Items.Add(category);
            }
            ComboBoxCategory.Items.Add("All");
            foreach (var note in _project.ListNote.ToArray())
            {
                NoteListBox.Items.Add(note.Name);
            }
            foreach (int i in NoteCategory.GetValues(typeof(NoteCategory)))
                lenghtEnum = i;
            int j = _project.CurrentNote;
            ComboBoxCategory.SelectedIndex = lenghtEnum + 1;
            if (j>=0)
            {
                NoteListBox.SelectedIndex = j;
                WriteInterface();
            }
        }

        /// <summary>
        /// Получение выбранной заметки.
        /// </summary>
        private Note GetSelectedNote()
        {
            int nameIndex = NoteListBox.SelectedIndex;
            if (nameIndex<0)
                throw new ArgumentOutOfRangeException("Dont selected Note from ListBox-name");
            Note selectedNote = null;
            int categoryIndex = ComboBoxCategory.SelectedIndex;
            if (categoryIndex == -1 || categoryIndex == lenghtEnum + 1)
            {
                selectedNote = _project.ListNote[nameIndex];
                _project.CurrentNote = _project.ListNote.IndexOf(selectedNote);
            }
            else
            {
                List<Note> listNoteCategory = new List<Note>();
                foreach (Note note in _project.ListNote.ToArray())
                {
                    if (note.Category == (NoteCategory)categoryIndex)
                        listNoteCategory.Add(note);
                }
                selectedNote = listNoteCategory[nameIndex];
                _project.CurrentNote = _project.ListNote.IndexOf(selectedNote);
            }
            if (selectedNote == null)
                throw new ArgumentOutOfRangeException("selectedNote = null");
            ProjectManager.Serializer(_project, path);
            return selectedNote;
        }

        /// <summary>
        /// Отчищение интерфейса.
        /// </summary>
        private void ClearInterface()
        {
            NoteListBox.Items.Clear();
            CurrentCategoryNote.Text = "";
            CreateDateLabel.Text = "";
            ModifiedDateLabel.Text = "";
            NameLabel.Text = "Заметка";
            NoteTextBox.Text="";
            _project.CurrentNote = -1;
            ProjectManager.Serializer(_project, path);
        }

        /// <summary>
        /// Заполнение интерфейса.
        /// </summary>
        public void WriteInterface()
        {
            Note selectedNote = null;
            int nameIndex = NoteListBox.SelectedIndex;
            if (nameIndex > -1)
            {
                selectedNote = GetSelectedNote();
                CurrentCategoryNote.Text = selectedNote.Category.ToString();
                CreateDateLabel.Value = selectedNote.DateCreate;
                ModifiedDateLabel.Value = selectedNote.DateChange;
                NoteTextBox.Text = "";
                NoteTextBox.Text=selectedNote.Text;
                NameLabel.Text = selectedNote.Name;
            }
        }

        /// <summary>
        /// Кнопка добавить.
        /// </summary>
        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            AddEditNoteForm addEditNote = new AddEditNoteForm(new Note());
            DialogResult result = addEditNote.ShowDialog();
            if (result == DialogResult.OK)
            {
                _project.ListNote.Add(addEditNote.NewNote);
                if ((int)addEditNote.NewNote.Category==ComboBoxCategory.SelectedIndex || lenghtEnum + 1 == ComboBoxCategory.SelectedIndex)
                    NoteListBox.Items.Add(addEditNote.NewNote.Name);
                ProjectManager.Serializer(_project, path);
                ComboBoxCategory.SelectedIndex = ComboBoxCategory.SelectedIndex;
            }
        }

        /// <summary>
        /// Кнопка редактировать.
        /// </summary>
        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex != -1)
            {
                AddEditNoteForm addEditNote = new AddEditNoteForm(GetSelectedNote());
                DialogResult result = addEditNote.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _project.ListNote = _project.SortedListNote();
                    ClearInterface();
                    ProjectManager.Serializer(_project, path);
                }
                ComboBoxCategory_SelectedIndexChanged(sender, e);
            }
        }

        /// <summary>
        /// Кнопка Удалить.
        /// </summary>
        private void pictureBoxRemove_Click(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex != -1)
            {
                _project.ListNote.Remove(GetSelectedNote());
                ClearInterface();
                ComboBoxCategory_SelectedIndexChanged(sender, e);
            }
        }

        /// <summary>
        /// Кнопка Выбора категории.
        /// </summary>
        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndexCategory = ComboBoxCategory.SelectedIndex;
            ClearInterface();
            if (selectedIndexCategory != -1 && selectedIndexCategory < lenghtEnum + 1)
            {
                foreach (var note in _project.ListNote.ToArray())
                {
                    if (note.Category == (NoteCategory)selectedIndexCategory)
                        NoteListBox.Items.Add(note.Name);
                }
            }
            else
            {
                foreach (var note in _project.ListNote.ToArray())
                    NoteListBox.Items.Add(note.Name);
            }
        }

        /// <summary>
        /// Кнопка Выбора заметки.
        /// </summary>
        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WriteInterface();
        }

        /// <summary>
        /// Кнопка выхода.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Кнопка добавить заметку.
        /// </summary>
        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxAdd_Click(sender, e);
        }

        /// <summary>
        /// Кнопка изменить заметку.
        /// </summary>
        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxEdit_Click(sender, e);
        }

        /// <summary>
        /// Кнопка удалить заметку.
        /// </summary>
        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex != -1)
            {
                pictureBoxRemove_Click(sender, e);
            }
        }

        /// <summary>
        /// Кнопка вызова About.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// реакция на горячие клавиши.
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (NoteListBox.SelectedIndex != -1)
                {
                    DialogResult result = MessageBox.Show(
                    "Удалить заметку?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                        pictureBoxRemove_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                Close();
            }
        }
    }
}
