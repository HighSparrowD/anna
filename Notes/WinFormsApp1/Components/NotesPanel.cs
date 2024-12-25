using WinFormsApp1.Models;

namespace WinFormsApp1.Components
{
    // New custom component
    public class NotesPanel : Panel
    {
        private NoteDetails _noteDetails { get; set; }
        
        private Panel _notesPanel;
        private List<CustomNote> _notes;

        public NotesPanel(NoteDetails noteDetails, List<CustomNote> notes) : base()
        {
            _noteDetails = noteDetails;
            _notes = notes;
        }

        protected override void InitLayout()
        {
            this.Width = 200;
            this.Height = 500;
            this.BackColor = Color.Aqua;
            _notesPanel = new Panel
            {
                Height = 460
            };

            // :D
            Initialize();
            
            var addButton = new Button
            {
                Text = "NEW",
                Location = new Point(0, 460),
                Width = 200,
                Height = 40
            };

            addButton.Click += (s, e) => { CreateNewNote(s!, e); };

            this.Controls.Add(_notesPanel);
            this.Controls.Add(addButton);

            base.InitLayout();
        }

        // Not overriden initialize, but our custom
        private void Initialize()
        {

            var y = 0;
            _notesPanel.Controls.Clear();

            foreach (var item in _notes)
            {
                var note = new Button
                {
                    Text = item.Title,
                    Location = new Point(0, y),
                    Width = this.Width
                };

                note.Click += (s, e) => { SetNoteDetails(s!, e, item); };

                _notesPanel.Controls.Add(note);

                y += 30;
            }
        }

        private void CreateNewNote(object sender, EventArgs args)
        {
            _notes.Add(new CustomNote
            {
                Title = $"MY note {_notes.Count + 1}",
                Text = string.Empty
            });

            Initialize();
        }

        private void SetNoteDetails(object sender, EventArgs args, CustomNote note) => _noteDetails.SetActiveNote(note);
    }
}
