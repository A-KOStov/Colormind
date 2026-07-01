using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Colormind
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                string json = "{\"model\":\"default\",\"input\":[\"N\",\"N\",\"N\",\"N\",\"N\"]}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://colormind.io/api/", content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                using JsonDocument doc = JsonDocument.Parse(jsonResponse);
                JsonElement root = doc.RootElement;
                JsonElement result = root.GetProperty("result");

                Panel[] panels = { panel1, panel2, panel3, panel4, panel5 };

                for (int i = 0; i < 5; i++)
                {
                    int r = result[i][0].GetInt32();
                    int g = result[i][1].GetInt32();
                    int b = result[i][2].GetInt32();
                    
                    panels[i].BackColor = Color.FromArgb(r, g, b);
                }

                label6.Text = "Готово!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                button1.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}