
namespace System.Windows.Forms
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.ComponentModel;
	public class CZTableLayoutPanel : TableLayoutPanel
	{
        Dictionary<Control, List<Control>> mArrows = new Dictionary<Control, List<Control>>();
        Pen mPen = new Pen(Color.Gray);
        Brush b = new SolidBrush(Color.Gray);

        public void Add(Control from, Control to)
        {
            if (!mArrows.ContainsKey(from))
            {
                mArrows[from] = new List<Control>();
            }
            mArrows[from].Add(to);
        }

        public CZTableLayoutPanel()
        {
            //InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.UserPaint, true);
        }

        public CZTableLayoutPanel(IContainer container)
        {
            container.Add(this);
            //InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.UserPaint, true);
        }

          protected override void OnPaint(PaintEventArgs e)
          {
              base.OnPaint(e);
              Graphics g=e.Graphics;

              int margin=10;
              int arrow_length = 8;
              int arrow_width = 5;

              foreach (Control from_point in mArrows.Keys)
              {
                  List<Control> to_points = mArrows[from_point];
                  foreach (Control to_point in to_points)
                  {
                      int x1_offset = from_point.Width / 3;
                      int y1_offset = from_point.Height / 3+1;
                      int x2_offset = to_point.Width / 3;
                      int y2_offset = to_point.Width / 3+1;

                      //bool same_row = false;
                      //bool same_col = false;
                      if (from_point.Left+ margin< to_point.Left)
                      {
                          x2_offset = -x2_offset;
                      }
                      else if(from_point.Left > to_point.Left + margin)
                      {
                          x1_offset = -x1_offset;
                      }
                      else
                      {
                          x1_offset=x2_offset=0;
                          //same_col = true;
                      }
                      if (from_point.Top + margin < to_point.Top)
                      {
                          y2_offset = -y2_offset;
                      }
                      else if (from_point.Top > to_point.Top + margin)
                      {
                          y1_offset -= y1_offset;
                      }
                      else
                      {
                          y1_offset = y2_offset = 0;
                          //same_row = true;
                      }


                      int x1 = from_point.Left + from_point.Width / 2 + x1_offset;
                      int y1 = from_point.Top + from_point.Height / 2 + y1_offset;
                      int x2 = to_point.Left + to_point.Width / 2 + x2_offset;
                      int y2 = to_point.Top + to_point.Height / 2 + y2_offset;
                     
                      double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

                      if (distance < from_point.Width / 3 || distance < to_point.Width / 3) continue;
                      if (distance < arrow_length) continue;

                      g.DrawLine(mPen,
                         new Point(x1, y1),
                         new Point(x2, y2));

                      double ux = (x2 - x1) / distance;
                      double uy = (y2 - y1) / distance;

                      double x3 = x2 - ux * arrow_length;
                      double y3 = y2 - uy * arrow_length;

                      double x4 = x3 - uy * arrow_width;
                      double y4 = y3 + ux * arrow_width;

                      double x5 = x3 + uy * arrow_width;
                      double y5 = y3 - ux * arrow_width;

                      try
                      {
                          g.FillPolygon(b, new Point[] { new Point((int)x4, (int)y4), new Point((int)x2, (int)y2), new Point((int)x5, (int)y5) });
                      }
                      catch (Exception ex)
                      {
                          Console.WriteLine(ex.Message);
                      }
                  }
              }
          }


	}
}
