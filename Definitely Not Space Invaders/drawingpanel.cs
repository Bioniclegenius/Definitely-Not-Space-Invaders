using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Definitely_Not_Space_Invaders {
  public class drawingpanel:Panel {
    public List<star> stars;
    public System.Diagnostics.Stopwatch st=new System.Diagnostics.Stopwatch();
    public long lasttime;
    public drawingpanel(int dimx=100,int dimy=100) {
      this.Size=new Size(dimx,dimy);
      this.Location=new Point(0,0);
      this.DoubleBuffered=true;
      this.Paint+=new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
      this.MouseMove+=new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
      stars=new List<star>();
      for(int x=0;x<70.0*dimx/100;x++)
        stars.Add(new star(dimx,dimy));
      st.Start();
      lasttime=st.ElapsedMilliseconds;
      Invalidate();
    }
    public void PaintEvent(object sender,PaintEventArgs e) {
      SolidBrush b=new SolidBrush(Color.FromArgb(0,0,0));
      Graphics g=e.Graphics;
      long time=st.ElapsedMilliseconds-lasttime;
      lasttime+=time;
      if(time!=0) {
        g.FillRectangle(b,0,0,this.Width,this.Height);
        for(int x=0;x<stars.Count;x++)
          stars[x].paint(g,time);
      }
      Invalidate();
    }
    public void MouseMoveEvent(object sender,MouseEventArgs m) {
      int mouseX=m.X;
      int mouseY=m.Y;
      //do whatever you so wish with this information, the mouse X and Y coordinates
    }
  }
}
