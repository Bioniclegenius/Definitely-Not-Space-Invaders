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
    public List<bullet> bullets;
    public List<bullet> playerbullets;
    public List<particle> particles;
    public Player player;
    public bool mouseheld=false;
    public drawingpanel(int dimx=100,int dimy=100) {
      this.Size=new Size(dimx,dimy);
      this.Location=new Point(0,0);
      this.DoubleBuffered=true;
      this.Paint+=new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
      this.MouseMove+=new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
      this.MouseDown+=new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
      this.MouseUp+=new System.Windows.Forms.MouseEventHandler(this.MouseUpEvent);
      stars=new List<star>();
      enemies=new List<enemycontainer>();
      bullets=new List<bullet>();
      playerbullets=new List<bullet>();
      particles=new List<particle>();
      player = new Player(dimx, dimy);
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
        for(int x=0;x<bullets.Count;x++) {
          bullets[x].render(g,this.Width,this.Height,time);
          if(bullets[x].done) {
            bullets.RemoveAt(x);
            x--;
          }
        }
        for(int x=0;x<playerbullets.Count;x++) {
          playerbullets[x].render(g,this.Width,this.Height,time);
          if(playerbullets[x].done) {
            playerbullets.RemoveAt(x);
            x--;
          }
        }
        for(int x=0;x<enemies.Count;x++) {
          enemies[x].render(g,this.Width,this.Height,time,ref bullets);
          if(enemies[x].curHP<=0) {
            enemies[x].deathAnimation(ref particles);
            enemies.RemoveAt(x);
            x--;
          }
        }
        player.render(g,this.Width,this.Height,time,ref playerbullets,mouseheld);
        if(player.curHP<=0) {
          player.deathAnimation();
        }
        if(lasttime%10000<time)
          enemies.Add(new BasicTriangleEnemy(this.Width,this.Height));
      }
      Invalidate();
    }
    public void MouseMoveEvent(object sender,MouseEventArgs m) {
      int mouseX=m.X;
      int mouseY=m.Y;
      player.mousemove(mouseX,mouseY);
      //do whatever you so wish with this information, the mouse X and Y coordinates
    }
    public void MouseDownEvent(object sender,MouseEventArgs m) {//if the user is pressing the mouse button
      mouseheld=true;
    }
    public void MouseUpEvent(object sender,MouseEventArgs m) {//if the user has released the mouse button
      mouseheld=false;
    }
  }
}
