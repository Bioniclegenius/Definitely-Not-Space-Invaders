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
    public List<enemycontainer> enemies;
    public drawingpanel(int dimx=100,int dimy=100) {
      this.Size=new Size(dimx,dimy);
      this.Location=new Point(0,0);
      this.DoubleBuffered=true;
      this.Paint+=new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
      this.MouseMove+=new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
      stars=new List<star>();
      enemies=new List<enemycontainer>();
      for(int x=0;x<50.0*Math.Sqrt(dimx*dimy)/100;x++)
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
          stars[x].paint(g,this.Width,this.Height,time);
        for(int x=0;x<enemies.Count;x++) {
          enemies[x].render(g,this.Width,this.Height,time);
          if(enemies[x].curHP<=0) {
            enemies[x].deathAnimation();
            enemies.RemoveAt(x);
            x--;
          }
        }
        if(lasttime%10000<time)
          enemies.Add(new BasicTriangleEnemy(this.Width,this.Height));
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
