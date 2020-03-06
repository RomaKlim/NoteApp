using System;
using System.Windows.Forms;
using NoteApp.Model;
namespace NoteApp.UI
{
    /// <summary>
    /// Форма для работы с текущей заметкой.
    /// </summary>
    public partial class AddEditNoteForm : Form
    {
        public Note NewNote;

        /// <summary>
        ///Инициализация формы
        /// </summary>
        public AddEditNoteForm(Note ImportNote)
        {
            InitializeComponent();
            foreach (var note in Enum.GetValues(typeof(NoteCategory)))
            {
                ComboBoxCategory.Items.Add(note);
            }
            NewNote = ImportNote;
            TextBoxName.Text = NewNote.Name;
            TextBoxNote.Text = NewNote.Text;
            ComboBoxCategory.SelectedItem = NewNote.Category;
            CreatedDateNote.Value = NewNote.DateCreate;
            ChangedDateNote.Value = NewNote.DateChange;
        }

        /// <summary>
        /// Кнопка ОК.
        /// </summary>
        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                NewNote.Name = TextBoxName.Text;
                NewNote.Text = TextBoxNote.Text;
                NewNote.Category = (NoteCategory)ComboBoxCategory.SelectedItem;
                Close();
            }
            catch
            {
                DialogResult result = MessageBox.Show(
                "Длина имени не может быть больше 50 символов",
                NewNote.Name,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                NewNote.Name = "Non correct";
            }
        }

        /// <summary>
        /// Кнопка Cancel.
        /// </summary>
        private void Cancel_Click(object sender, EventArgs e)
        {
            NewNote = null;
            Close();
        }
         /// <summary>
         /// Вывод сообщения об ошибке, при вводе имени больше 50
         /// </summary>
        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            if(TextBoxName.TextLength>50)
            {
                DialogResult result = MessageBox.Show(
                "Длина имени не может быть больше 50 символов",
                NewNote.Name,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                TextBoxName.Text = "Non correct";
            }
        }
    }
}