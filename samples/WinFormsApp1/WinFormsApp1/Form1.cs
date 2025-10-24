namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Assuming you have a RichTextBox control named 'richTextBox1' on your form
            string htmlContent = "<h1>Hello!</h1><p>This is <b>HTML</b> content.</p>";

            // Convert HTML to RTF
            // This requires a helper function or library to perform the conversion
            // For simple HTML, you might be able to do a basic conversion manually or find a small utility.
            // For complex HTML, a dedicated library like HtmlAgilityPack and a custom RTF converter would be needed.

            // Example (simplified - for full HTML to RTF conversion, more robust logic is required):
            //richTextBox1.Rtf = HtmlToRtfConverter.Convert(htmlContent);

            // For demonstration with basic text, you can set the Text property directly,
            // but it won't render HTML tags as formatted text.
            richTextBox1.Rtf = htmlContent;
        }
    }
}
