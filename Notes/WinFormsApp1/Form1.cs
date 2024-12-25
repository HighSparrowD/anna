using WinFormsApp1.Components;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    // TODO: Set right colors, google it, u can set those via RGB or HEX
    // TODO: Deal with a delete button (NoteDetail.cs)
    // TODO: Make _notesPanel scrolable, again google it. (NotesPanel.cs)
    public partial class Form1 : Form
    {
        // Private variables, does not have getter and setter
        private NotesPanel _notesPanel;
        private NoteDetails _notesDetails;

        // TODO: add json parse
        private List<CustomNote> _notes = new List<CustomNote>
            {
                new CustomNote
                {
                    Title = "MY note 1",
                    Text = "I want to smoke so fucking much"
                },

                new CustomNote
                {
                    Title = "MY note 2",
                    Text = "I want to sleep so fucking much"
                }
            };

        public Form1()
        {
            // Load saved notes
            LoadNotes();

            _notesDetails = new NoteDetails(_notes);
            _notesPanel = new NotesPanel(_notesDetails, _notes);

            // Adding our custom component
            Controls.Add(_notesPanel);
            Controls.Add(_notesDetails);
            InitializeComponent();
        }

        private void LoadNotes()
        {
            try
            {
                _notes = Utils.Utils.ReadSavedNotes();
            }
            catch (Exception)
            {
                _notes = new List<CustomNote>();
            }
        }
    }
}
