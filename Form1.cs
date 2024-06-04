using System.IO;
using System.Xml.Serialization;
namespace Notatnik2
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;
        private bool isDarkMode = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();
        }

        private void NewFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    MessageBox.Show("You need to save first");
                }
                else
                {
                    this.richTextBox1.Text = string.Empty;
                    this.Text = "Untitled";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void SaveFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text file (*.txt) | *.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                        this.Text = saveFileDialog.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("The File can not be empty");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void OpenFile()
        {
            try
            {
                openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while trying to open this file");
            }
            finally
            {
                openFileDialog = null;
            }
        }
        private void SaveFileAs()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text file (*.txt) | *.txt! | All Files (*.*) | *.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                        this.Text = saveFileDialog.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("The File can not be empty");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void ColorMode()
        {
            isDarkMode = !isDarkMode;
            if (isDarkMode)
            {
                this.BackColor = Color.DimGray;
                this.ForeColor = Color.White;

                foreach (Control control in this.Controls)
                {
                    control.BackColor = Color.DimGray;
                    control.ForeColor = Color.White;
                }
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;

                foreach (Control control in this.Controls)
                {
                    control.BackColor = Color.White;
                    control.ForeColor = Color.Black;
                }
            }
        }
        private void FileExit()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    SaveFile();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void FileFont()
        {
            try
            {
                fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Font = fontDialog.Font;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void Bigger()
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size + 2);
        }
        private void Smaller()
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size - 2);
        }
        private void FileBack()
        {
            richTextBox1.Undo();
        }
        private void FileCut()
        {
            richTextBox1.Cut();
        }
        private void FileCopy()
        {
            richTextBox1.Copy();
        }
        private void FilePaste()
        {
            richTextBox1.Paste();
        }
        private void FileSelectAll()
        {
            richTextBox1.SelectAll();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileExit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileFont();
        }

        private void notepadStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorMode();
        }

        private void biggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bigger();
        }
        private void smallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Smaller();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileBack();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileCut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileCopy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilePaste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSelectAll();
        }
    }
}
