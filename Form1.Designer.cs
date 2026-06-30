using System.Drawing;
using System.Windows.Forms;

namespace практика
{
    partial class Form1
    {
        private Button button1;
        private Button button2;
        private Label label6;
        private Panel panel1, panel2, panel3, panel4, panel5;
        private Label label1, label2, label3, label4, label5;

        private void InitializeComponent()
        {
            // Создаем элементы
            button1 = new Button();
            button2 = new Button();
            label6 = new Label();
            
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();

            // Кнопка "Сгенерировать"
            button1.Text = "Сгенерировать";
            button1.Size = new Size(120, 30);
            button1.Location = new Point(10, 10);
            button1.Click += button1_Click;

            // Кнопка "Копировать"
            button2.Text = "Копировать";
            button2.Size = new Size(120, 30);
            button2.Location = new Point(140, 10);
            button2.Click += button2_Click;

            // Панели цветов (5 штук)
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

            // Метки для HEX кодов
            Label[] labels = { label1, label2, label3, label4, label5 };
            for (int i = 0; i < 5; i++)
            {
                labels[i].AutoSize = true;
                labels[i].Location = new Point(x + i * 80, y + 75);
                labels[i].Font = new Font("Consolas", 8);
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

            // Добавляем всё на форму
            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(label6);
            
            foreach (Panel p in panels) 
                this.Controls.Add(p);
            foreach (Label l in labels) 
                this.Controls.Add(l);
        }
    }
}