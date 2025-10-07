using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace TextBoxFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Word Document";
                openFileDialog.Filter = "Word Documents (*.docx)|*.docx|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            string filePath = txtFilePath.Text;

            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Please select a Word document first.", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool textboxFound = CheckForTextBox(filePath);

            lblResult.Text = textboxFound ? "✅ TextBox found in the document." : "❌ No TextBox found.";
            lblResult.ForeColor = textboxFound ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        // Word Interop Logic

        private bool CheckForTextBox(string filePath)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document doc = null;
            bool found = false;
            int textboxCount = 0;
            List<string> textboxDetails = new List<string>();

            try
            {
                doc = wordApp.Documents.Open(filePath, ReadOnly: true);

                foreach (Word.Section section in doc.Sections)
                {
                    foreach (Word.WdHeaderFooterIndex headerType in new[]
                    {
                Word.WdHeaderFooterIndex.wdHeaderFooterPrimary,
                Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage,
                Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages
            })
                    {
                        Word.HeaderFooter header = section.Headers[headerType];

                        if (header != null)
                        {
                            // 1️⃣ Floating shapes
                            foreach (Word.Shape shape in header.Shapes)
                            {
                                if ((Microsoft.Office.Core.MsoTriState)shape.TextFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
                                {
                                    textboxCount++;
                                    found = true;
                                    string content = shape.TextFrame.TextRange.Text;
                                    float left = shape.Left;
                                    float top = shape.Top;
                                    textboxDetails.Add($"TextBox #{textboxCount}:\nContent: {content}\nPosition: Left={left}, Top={top}");
                                }
                            }

                            // 2️⃣ Inline shapes
                            Word.Range headerRange = header.Range;
                            foreach (Word.Shape shape in headerRange.ShapeRange)
                            {
                                if ((Microsoft.Office.Core.MsoTriState)shape.TextFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
                                {
                                    textboxCount++;
                                    found = true;
                                    string content = shape.TextFrame.TextRange.Text;
                                    float left = shape.Left;
                                    float top = shape.Top;
                                    textboxDetails.Add($"TextBox #{textboxCount}:\nContent: {content}\nPosition: Left={left}, Top={top}");
                                }
                            }
                        }
                    }
                }

                if (found)
                {
                    string name0 = "Priyanshu";
                    string greet = "Hello World";
                    string name1 = "Piyush";
                    string passion1 = "Athletics";
                    string passion2 = "Running";
                    string message = $"✅ Total TextBoxes Found: {textboxCount}\n\n" + string.Join("\n\n", textboxDetails);
                    MessageBox.Show(message, "TextBox Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ No TextBox found in the document.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                doc?.Close(false);
                wordApp.Quit();
            }

            return found;
        }



    }
}
