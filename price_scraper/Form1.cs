using System.Diagnostics;
using MaterialSkin;
using MaterialSkin.Controls;
using OfficeOpenXml;
using price_scraper.Core;
using price_scraper.Core.Web;
using System.Windows.Forms;

namespace price_scraper
{
    public partial class Form1 : MaterialForm
    {
        public ExcelPackage? ExcelFile { get; private set; }
        public List<string> Products { get; private set; }
        public int WorksheetIndex { get; private set; }
        public int ProductsPerPage { get; private set; }
        public int PageIndex { get; private set; }
        public string Currency { get; private set; }
        public Form1()
        {
            InitializeComponent();

            var skinManager = MaterialSkinManager.Instance;
            skinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500,
                Accent.LightGreen200, TextShade.WHITE);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.AddFormToManage(this);
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            var products = new List<Query> { new Query("cma2550", "PLN", 20, 1) };

            var jkx = new ScrapingHandler(Convert.ToInt32(Math.Ceiling(Math.Sqrt(products.Count))));

            var result = await jkx.PerformScraping(products);

            result.ForEach(r => MessageBox.Show($"{r.QueriedName}\n{r.TmeName}\n{r.OriginalName}\n{r.Description}\n{r.PriceData}\n{r.Stock}\n{r.QuantityType}"));
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx; *.xlsm)|*.xlsx;*.xlsm|All Files (*.*)|*.*";
            openFileDialog.Title = "Select an Excel File";
            openFileDialog.Multiselect = false;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                var file = new FileInfo(openFileDialog.FileName);
                ExcelFile = new ExcelPackage(file);

                fileStatusLabel.Text = $"Loaded: {file.Name}";

                //Show avaiable worksheets
                var worksheets = ReadWorksheetNames();
                EnableAndSetItems(worksheets, comboBoxWorksheet);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IEnumerable<string> ReadWorksheetNames()
        {
            if (ExcelFile == null) throw new InvalidOperationException();

            return ExcelFile.Workbook.Worksheets.Select(worksheet => worksheet.Name).ToList();
        }

        private static IEnumerable<string> ReadColumnRange(ExcelWorksheet worksheet)
        {
            var result = new List<string>();

            var col = 1;
            const int row = 1;

            while (!string.IsNullOrEmpty(worksheet.Cells[row, col].Text))
            {
                result.Add(GetExcelColumnName(col));
                col++;
            }

            return result;
        }

        private static string GetExcelColumnName(int columnNumber)
        {
            var columnName = "";

            while (columnNumber > 0)
            {
                var remainder = (columnNumber - 1) % 26;
                var character = (char)('A' + remainder);
                columnName = character + columnName;
                columnNumber = (columnNumber - 1) / 26;
            }

            return columnName;
        }

        private static void EnableAndSetItems(IEnumerable<string> items, ComboBox input)
        {
            input.Enabled = true;
            input.DataSource = items;
        }

        private static void EnableControl(Control comboBox) => comboBox.Enabled = true;

        private void comboBoxWorksheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chosenWorksheet = comboBoxWorksheet.SelectedIndex;

            Debug.Assert(ExcelFile != null, nameof(ExcelFile) + " != null");
            var columns = ReadColumnRange(ExcelFile.Workbook.Worksheets[chosenWorksheet]);

            EnableAndSetItems(columns, comboBoxProductColumn);
        }
    }
}