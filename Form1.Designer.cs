using System.Drawing;
using System.Windows.Forms;

namespace Colormind
{
    partial class Form1
    {
        private Button button1;
        private Label label6;
        private Panel panel1, panel2, panel3, panel4, panel5;

        private void InitializeComponent()
        {
            button1 = new Button();
            label6 = new Label();
            
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();

            // Кнопка "Сгенерировать"
            button1.Text = "Сгенерировать";
            button1.Size = new Size(120, 30);
            button1.Location = new Point(10, 10);
            button1.Click += button1_Click;

            // Панели цветов
            int x = 10;
            int y = 50;
            
            Panel[] panels = { panel1, panel2, panel3, panel4, panel5 };
            for (int i = 0; i < 5; i++)
            {
                panels[i].Size = new Size(70, 70);
                panels[i].Location = new Point(x + i * 80, y);
                panels[i].BackColor = Color.Gray;
                panels[i].BorderStyle = BorderStyle.FixedSingle;
            }

            // Статус
            label6.Text = "Готов к работе";
            label6.Location = new Point(10, 140);
            label6.Size = new Size(300, 20);

            // Форма
            this.Text = "Colormind";
            this.Size = new Size(430, 210);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Добавляем на форму
            this.Controls.Add(button1);
            this.Controls.Add(label6);
            
            foreach (Panel p in panels) 
                this.Controls.Add(p);
        }
    }
}