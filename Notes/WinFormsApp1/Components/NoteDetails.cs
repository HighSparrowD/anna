using WinFormsApp1.Models;

namespace WinFormsApp1.Components
{
    public class NoteDetails : Panel
    {
        public Panel ActionPanel { get; set; } = default!;
        public RichTextBox DetailTextBox { get; set; } = default!;

        private List<CustomNote> _notes;

        private CustomNote _activeNote;

        public NoteDetails(List<CustomNote> notes) : base()
        {
            _notes = notes;
            this.DetailTextBox = new RichTextBox();
        }

        protected override void InitLayout()
        {
            // No need to add this, but I want to be specific
            this.BackColor = Color.Khaki;
            this.Location = new Point(200, 0);
            this.Width = 616;
            this.Height = 500;


            this.DetailTextBox.BackColor = Color.LightGray;
            this.DetailTextBox.Location = new Point(0, 0);
            this.DetailTextBox.Width = this.Width;
            this.DetailTextBox.Height = 400;
            this.Controls.Add(this.DetailTextBox);

            this.ActionPanel = new Panel
            {
                BackColor = Color.Green,
                Location = new Point(0, 400),
                Width = this.Width,
                Height = 100
            };

            // TODO: Set correct locations and color AND add an event / or delete the button completely
            this.ActionPanel.Controls.Add(new Button 
            {
                Location = new Point(10, 10),
                Text = "NAHUJ VSE"
            });

            // TODO: Set correct locations and color
            var saveButton = new Button
            {
                Location = new Point(10, 30),
                Text = "Save",
            };

            saveButton.Click += (s, e) => { SaveAllNotes(s!, e); };
            this.DetailTextBox.TextChanged += (s, e) => { OnNoteChanged(s!, e); };

            this.ActionPanel.Controls.Add(saveButton);

            this.Controls.Add(this.ActionPanel);

            base.InitLayout();
        }

        public void SetActiveNote(CustomNote note)
        {
            _activeNote = note;
            DetailTextBox.Text = note.Text;
        }

        private void OnNoteChanged(object sender, EventArgs args)
        {
            _activeNote.Text = DetailTextBox.Text;
        }

        private void SaveAllNotes(object sender, EventArgs args) => Utils.Utils.SavedNotes(_notes);
    }
}
