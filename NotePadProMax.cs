using System.Drawing.Printing;

namespace Day36
{
    public partial class NotePadProMax : Form
    {

        float currentZoom = 1.0f;
        Font defaultFont;
        public NotePadProMax()
        {
            InitializeComponent();
            defaultFont = txtWords.Font;
            //this.FormBorderStyle = FormBorderStyle.None; // Removes the border and title bar
            //this.ControlBox = false;                     // Removes minimize, maximize, and close buttons
            //this.Text = string.Empty;
        }
        private string currentFilePath = "Untitled";
        private void NotePadProMax_Load(object sender, EventArgs e)
        {
            currentFilePath = "Untitled";
            this.Text = $"{currentFilePath} - NotePadProMax";
        }
        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWords.Clear();
            currentFilePath = "Untitled";
            this.Text = $"{currentFilePath} - NotePadProMax";
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Document|*.txt|All Files(*.*)|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                txtWords.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                currentFilePath = filePath;
                this.Text = $"{System.IO.Path.GetFileName(currentFilePath)} - NotePadProMax";
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "*.txt";
            saveFileDialog1.Filter = "Text documents|*.txt|All Files|*.*";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                txtWords.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                currentFilePath = filePath;
                this.Text = $"{System.IO.Path.GetFileName(currentFilePath)} - NotePadProMax";
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem.Name = "";
            saveFileDialog1.Filter = "Text documents|*.txt|All Files|*.*";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                txtWords.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                currentFilePath = filePath;
                this.Text = $"{System.IO.Path.GetFileName(currentFilePath)} - NotePadProMax";
            }
        }
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text documents (*.txt)|*.txt|All Files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtWords.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }
        }
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            PageSetupDialog pg = new PageSetupDialog();

            pg.Document = printDocument;
            pg.ShowDialog();
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWords.Undo();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWords.Redo();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWords.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWords.Copy();
        }
        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWords.Paste();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectionStart = txtWords.SelectionStart;
            int selectionLength = txtWords.SelectionLength;

            if (selectionLength > 0)
            {
                txtWords.Text = txtWords.Text.Remove(selectionStart, selectionLength);
                txtWords.SelectionStart = selectionStart;
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWords.SelectAll();
        }
        private void forntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = txtWords.Font;
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtWords.Font = fontDialog1.Font;
            }
        }
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentZoom += 0.1f;
            txtWords.Font = new Font(txtWords.Font.FontFamily, txtWords.Font.Size * 1.1f);
        }
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtWords.Font.Size > 2)
            {
                currentZoom -= 0.1f;
                txtWords.Font = new Font(txtWords.Font.FontFamily, txtWords.Font.Size / 1.1f);
            }
        }
        private void restoreDefultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWords.Font = defaultFont;
            currentZoom = 1.0f;
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBarToolStripMenuItem.Checked = !statusBarToolStripMenuItem.Checked;
            if (statusBarToolStripMenuItem.Checked)
            {
                txtWords.AcceptsTab = true;
            }
            else
            {
                txtWords.AcceptsTab = false;
            }
        }
        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            wordToolStripMenuItem.Checked = !wordToolStripMenuItem.Checked;
            if (wordToolStripMenuItem.Checked)
            {
                txtWords.WordWrap = true;
            }
            else
            {
                txtWords.WordWrap = false;
            }
        }
    }
}
