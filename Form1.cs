using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
          //(WeatherDataGrid.DataSource as DataTable).DefaultView.RowFilter = $"CityName LIKE '%{textBox1.Text}%'";
          WeatherDataGrid.DataSource = _weather.Weathers.Where(u => u.CityName == textBox1.Text).ToList();
            if (textBox1.Text == "")
            {
                WeatherDataGrid.DataSource = _weather.Weathers.ToList();
            }
        }

        private void Example()
        {
            //List<IntWeather> vs = new List<IntWeather> { new IntWeather("Абакан"), new IntWeather("Черногорск") };
            ////То, что выводится в DataGridView
            //WeatherDataGrid.DataSource = vs.ToList();

            ////поиск
            //WeatherDataGrid.DataSource = vs.Where(u => u.DigitName.Contains(textBox1.Text)).ToList();
        }
    }
}