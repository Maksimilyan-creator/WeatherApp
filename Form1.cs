using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherForm : Form
    {
        private WeatherDatabase _weather;

        public WeatherForm()
        {
            InitializeComponent();

            _weather = new WeatherDatabase();
            _weather.Initialize();

            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            (WeatherDataGrid.DataSource as DataTable).DefaultView.RowFilter = $"CityName LIKE '%{textBox1.Text}%'";
        }
    }
}