using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCell
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int rows;
        private int columns;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            if (timer1.Enabled)
                return;

            numResolution.Enabled = false;
            numDensity.Enabled = false;

            resolution = (int)numResolution.Value;
            rows = pictureBox1.Height / resolution;
            columns = pictureBox1.Width / resolution;
            field = new bool[columns, rows];
            Random random = new Random();

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    field[i, j] = random.Next((int)numDensity.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);

            timer1.Start();
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;

            numResolution.Enabled = true;
            numDensity.Enabled = true;
            timer1.Stop();
        }

        private void NextGeneration()
        {
            graphics.Clear(Color.Black);

            var newField = new bool[columns, rows];

            for(int i = 0; i < columns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    var neighboursCount = CountNeighbours(i, j);
                    var hasLife = field[i, j];

                    if (!hasLife && neighboursCount == 3)
                        newField[i, j] = true;
                    else if(hasLife && (neighboursCount < 2 || neighboursCount > 3))
                        newField[i, j] = false;
                    else
                        newField[i, j] = field[i, j];

                    if(hasLife)
                        graphics.FillRectangle(Brushes.Crimson, i * resolution, j * resolution, resolution, resolution);
                    
                }
            }

            field = newField;

            pictureBox1.Refresh();
        }

        private int CountNeighbours(int x, int y)
        {
            int count = 0;

            for(int i = -1; i < 2;i++) 
            {
                for(int j = -1; j < 2; j++)
                {
                    var col = (x + i + columns) % columns;
                    var row = (y + j + rows) % rows;
                    var isSelfCheking = col == x && row == y;
                    var hasLife = field[col,row];
                    if(hasLife && !isSelfCheking)
                        count++;
                }
            }

            return count;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void bStart_Click(object sender, EventArgs e)
        {

            StartGame();
       
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
                return;

            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validationPassed = ValidateMousePosition(x, y);
                if (validationPassed)
                    field[x, y] = true;

            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validationPassed = ValidateMousePosition(x, y);
                if (validationPassed)
                    field[x, y] = false;

            }
        }

        private bool ValidateMousePosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < columns && y < rows;
        }
    }
}
