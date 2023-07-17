using MaterialSkin;
using MaterialSkin.Controls;
using price_scraper.Core;
using price_scraper.Core.Web;

namespace price_scraper
{
    public partial class Form1 : MaterialForm
    {
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
            var products = new List<Query> { new Query("12frdsdsdsdsdsdsdsd0", "PLN", 20, 1) };

            var jkx = new ScrapingHandler(products.Count);

            var result = await jkx.PerformScraping(products);

            MessageBox.Show(result.Count.ToString());
        }
    }
}