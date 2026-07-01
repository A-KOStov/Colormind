using System;
using System.Drawing;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Colormind
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.Items.Add("default");
            comboBox1.Items.Add("ui");
            comboBox1.SelectedIndex = 0;

            label1.Click += Label_Click;
            label2.Click += Label_Click;
            label3.Click += Label_Click;
            label4.Click += Label_Click;
            label5.Click += Label_Click;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                string model = comboBox1.SelectedItem?.ToString() ?? "default";
                string json = "{\"model\":\"" + model + "\",\"input\":[\"N\",\"N\",\"N\",\"N\",\"N\"]}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://colormind.io/api/", content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (!jsonResponse.StartsWith("{"))
                {
                    MessageBox.Show("Ошибка: сервер вернул не JSON. Попробуй модель default");
                    return;
                }

                using JsonDocument doc = JsonDocument.Parse(jsonResponse);
                JsonElement root = doc.RootElement;
                JsonElement result = root.GetProperty("result");

                Panel[] panels = { panel1, panel2, panel3, panel4, panel5 };
                System.Windows.Forms.Label[] labels = { label1, label2, label3, label4, label5 };

                for (int i = 0; i < 5; i++)
                {
                    int r = result[i][0].GetInt32();
                    int g = result[i][1].GetInt32();
                    int b = result[i][2].GetInt32();

                    panels[i].BackColor = Color.FromArgb(r, g, b);

                    string hex = "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
                    labels[i].Text = hex;
                    labels[i].ForeColor = Color.Black;
                }

                label6.Text = "Палитра сгенерирована! Модель: " + model;
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

        private void Label_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = sender as System.Windows.Forms.Label;
            if (label != null && !string.IsNullOrEmpty(label.Text))
            {
                Clipboard.SetText(label.Text);
                label6.Text = "Скопирован цвет " + label.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hex = "";
            System.Windows.Forms.Label[] labels = { label1, label2, label3, label4, label5 };

            for (int i = 0; i < labels.Length; i++)
            {
                if (!string.IsNullOrEmpty(labels[i].Text))
                {
                    hex += labels[i].Text + " ";
                }
            }

            if (string.IsNullOrEmpty(hex.Trim()))
            {
                MessageBox.Show("Сначала сгенерируйте палитру!");
                return;
            }

            Clipboard.SetText(hex.Trim());
            label6.Text = "Скопирована вся палитра: " + hex.Trim();
        }
    }
}
