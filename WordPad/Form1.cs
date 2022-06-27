using System.Text.RegularExpressions;

namespace WordPad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Font
            List<FontFamily> fontFamilies = new List<FontFamily>();
            System.Drawing.FontFamily[] families = new

               System.Drawing.Text.InstalledFontCollection().Families;
            foreach (FontFamily family in families)
            {
                comboBox1.Items.Add(family.Name);
            }
            comboBox1.SelectedItem = "Calibri";
            // Size
            List<int> size = new List<int>() { };
            for (int i = 8; i < 73; i++)
            {
                comboBox2.Items.Add(i);
            }
            comboBox2.SelectedItem = 11;
            // Color

            foreach (var prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                    comboBox3.Items.Add(prop.Name);
            }
            comboBox3.SelectedItem = "Black";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open File";
            openFileDialog1.Filter = "All files (*.*)|*.*| Text Files (*.txt) |*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
            this.Text = openFileDialog1.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.Filter = "All files (*.*)|*.*| Text Files (*.txt) |*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
            this.Text = saveFileDialog1.FileName;
        }

        private void pageSetupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SelectionFont = new Font(comboBox1.SelectedItem.ToString(), richTextBox1.Font.Size);
            }
            catch
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //richTextBox1.SelectionFont = new Font(comboBox1.SelectedItem.ToString(),comboBox2.SelectedItem);
            float fontSize;

            try
            {
                if (float.TryParse(comboBox2.SelectedItem.ToString(), out fontSize))

                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font.Name, fontSize, richTextBox1.Font.Style, GraphicsUnit.Point);
                }
            }
            catch
            {

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Font f = richTextBox1.SelectionFont;

            comboBox1.SelectedItem = f.Name;

            comboBox2.SelectedItem = (int)f.Size;
            if (richTextBox1.SelectionAlignment == HorizontalAlignment.Left)
            {

                button4.BackColor = Color.DeepSkyBlue;
                button5.BackColor = Color.LightGray;
                button6.BackColor = Color.LightGray;
            }
            else if (richTextBox1.SelectionAlignment == HorizontalAlignment.Right)
            {
                button4.BackColor = Color.LightGray;
                button5.BackColor = Color.LightGray;
                button6.BackColor = Color.DeepSkyBlue;
            }
            else if (richTextBox1.SelectionAlignment == HorizontalAlignment.Center)
            {
                button4.BackColor = Color.LightGray;
                button5.BackColor = Color.DeepSkyBlue;
                button6.BackColor = Color.LightGray;
            }
            this.Text = "*WordPad";
        }
        bool bold = false;
        bool italic = false;
        bool underline = false;
        private void button1_Click(object sender, EventArgs e)
        {
            bold = true;
            Font f = richTextBox1.SelectionFont;
            if (!richTextBox1.SelectionFont.Bold && italic == false && underline == false)
            {
                button1.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.LightGray;
                button3.BackColor = Color.LightGray;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Bold);
            }
            else if (!richTextBox1.SelectionFont.Bold && italic == true && bold == true && underline == false)
            {
                button1.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.LightGray;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Bold | FontStyle.Italic);
            }
            else if (!richTextBox1.SelectionFont.Bold && italic == true && underline == true && bold == true)
            {
                button1.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            }
            else if (!richTextBox1.SelectionFont.Bold && italic == false && underline == true && bold == true)
            {
                button1.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.LightGray;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Bold | FontStyle.Underline);
            }
            else
            {
                bold = false;
                button1.BackColor = Color.LightGray;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Regular);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            underline = true;
            Font f = richTextBox1.SelectionFont;
            if (!richTextBox1.SelectionFont.Underline && bold == false && italic == false)
            {
                button1.BackColor = Color.LightGray;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.LightGray;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Underline);
            }
            else if (!richTextBox1.SelectionFont.Underline && italic == true && underline == true && bold == true)
            {
                button1.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            }
            else if (!richTextBox1.SelectionFont.Underline && italic == true && underline == true && bold == false)
            {
                button1.BackColor = Color.LightGray;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Italic | FontStyle.Underline);
            }
            else if (!richTextBox1.SelectionFont.Underline && italic == true && underline == false && bold == false)
            {
                button1.BackColor = Color.LightGray;
                button2.BackColor = Color.LightGray;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Italic | FontStyle.Bold);
            }
            else if (!richTextBox1.SelectionFont.Underline && italic == false && underline == true && bold == true)
            {
                button1.BackColor = Color.LightGray;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.LightGray;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Bold | FontStyle.Underline);
            }
            else
            {
                underline = false;
                button2.BackColor = Color.LightGray;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Regular);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            italic = true;
            Font f = richTextBox1.SelectionFont;
            if (!richTextBox1.SelectionFont.Italic && bold == false && underline == false)
            {
                button1.BackColor = Color.LightGray;
                button2.BackColor = Color.LightGray;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Italic);
            }
            else if (!richTextBox1.SelectionFont.Italic && italic == true && underline == true && bold == true)
            {
                button1.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            }
            else if (!richTextBox1.SelectionFont.Italic && italic == true && underline == true && bold == false)
            {
                button1.BackColor = Color.LightGray;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Italic | FontStyle.Underline);
            }
            else if (!richTextBox1.SelectionFont.Italic && italic == true && underline == false && bold == false)
            {
                button1.BackColor = Color.LightGray;
                button2.BackColor = Color.LightGray;
                button3.BackColor = Color.DeepSkyBlue;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Italic | FontStyle.Bold);
            }
            else if (!richTextBox1.SelectionFont.Italic && italic == false && underline == true && bold == true)
            {
                button1.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.LightGray;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Bold | FontStyle.Underline);
            }
            else
            {
                italic = false;
                button3.BackColor = Color.LightGray;
                richTextBox1.SelectionFont = new Font(f, FontStyle.Regular);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^1-9");
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text) || regex.IsMatch(textBox2.Text))
                {
                    throw new NullReferenceException("Filename is uncorrect");
                }
                else
                {
                    if (File.Exists(textBox2.Text))
                    {
                        File.AppendAllText($"{textBox2.Text}", richTextBox1.Text);
                    }
                    else
                        File.WriteAllText($"{textBox2.Text}", richTextBox1.Text);
                    //MessageBox.Show($"Document write to {textBox2.Text} file");
                    this.Text = "(" + textBox2.Text + ")";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void load_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(textBox1.Text))
                {
                    throw new NullReferenceException($"{textBox1.Text} filename does not exist!");
                }
                else
                {
                    richTextBox1.Text = File.ReadAllText(textBox1.Text);
                    this.Text = "(" + textBox1.Text + ")";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }        

        private void comboBox3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }
    }
}