using System.Data;

namespace graph
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
            Init();
        }

        Bitmap map = new Bitmap(100,100);
        Graphics graphics;

        Pen pen = new Pen(Color.Black, 3f);

        array_point points = new array_point(2);

       
        private void drawButton_Click(object sender, EventArgs e)
        {
            
            points.resetPoint();
            graphics.Clear(pictureBox.BackColor);
       

            for (int x = -1 * (map.Width/2); x < map.Width/2;x++)
            {
                var y = new DataTable().Compute(replaceX(textBox.Text, x), null);
                points.setPoint((int) x+ (map.Width/2), ( (-1 *(int)y) +( map.Height/2)));
               
                if(points.getCountPoints() >= 2)graphics.DrawLines(pen, points.getPoints());
            }

            

            pictureBox.Image = map;
            
        }
        private void Init() 
        {
            
            

            map = new Bitmap(this.Width, this.Height);
            graphics = Graphics.FromImage(map);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
       
        }

        private void GraphForm_Resize(object sender, EventArgs e)
        {
            map = new Bitmap(this.Width, this.Height);
            graphics = Graphics.FromImage(map);
        }


        private string replaceX(string str, int count) 
        {
            string result = "";
            foreach (char chr in str) 
            {
                if (chr == 'x' || chr == 'X') result += count;
                else result += chr;
            }
            return result;
        }


        private class array_point
        {
            private int index = 0;
            private Point[] Points;

            public array_point(int size)
            {
                if (size <= 0) size = 2;
                Points = new Point[size];
            }
            public void setPoint(int x, int y)
            {
                if (index >= Points.Length) index = 0;
                Points[index] = new Point(x, y);
                index++;
            }
            public void resetPoint()
            {
                index = 0;
                Points = new Point[2];
            }
            public int getCountPoints() { return index; }

            public Point[] getPoints() { return Points; }
        }
    }
}