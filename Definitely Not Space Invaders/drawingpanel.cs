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
    public bool pointInPolygon(Point p,List<Point> poly) {
      bool inside=false;
      try {
        for(int i=0,j=poly.Count-1;i<poly.Count;j=i++) {
          if(((poly[i].Y>p.Y)!=(poly[j].Y>p.Y))&&(p.X<(poly[j].X-poly[i].X)*(p.Y-poly[i].Y)/(poly[j].Y-poly[i].Y)+poly[i].X))
            inside=!inside;
        }
      }
      catch(Exception E) {
        inside=false;
      }
      return inside;
    }
    public bool pointInPolygon(Point p,List<PointF> poly) {
      bool inside=false;
      try {
        for(int i=0,j=poly.Count-1;i<poly.Count;j=i++) {
          if(((poly[i].Y>p.Y)!=(poly[j].Y>p.Y))&&(p.X<(poly[j].X-poly[i].X)*(p.Y-poly[i].Y)/(poly[j].Y-poly[i].Y)+poly[i].X))
            inside=!inside;
        }
      }
      catch(Exception E) {
        inside=false;
      }
      return inside;
    }
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

        g.FillRectangle(b,0,0,this.Width,this.Height);//the background

        for(int x=0;x<stars.Count;x++)//render the stars
          stars[x].paint(g,this.Width,this.Height,time);

        for(int x=0;x<particles.Count;x++) {//render the enemy particles
          particles[x].render(g,this.Width,this.Height,time);
          if(particles[x].curLife<=0) {
            particles.RemoveAt(x);
            x--;
          }
        }

        for(int x=0;x<bullets.Count;x++) {//all enemy bullets
          bullets[x].render(g,this.Width,this.Height,time);
          if(pointInPolygon(new Point((int)(bullets[x].x+.5),(int)(bullets[x].y+.5)),player.verts)) {
            bullets[x].done=true;
            player.curHP--;
          }
          if(bullets[x].done) {
            bullets.RemoveAt(x);
            x--;
          }
        }

        for(int x=0;x<playerbullets.Count;x++) {//the player's bullets
          playerbullets[x].render(g,this.Width,this.Height,time);
          for(int y=0;y<enemies.Count;y++)
            if(pointInPolygon(new Point((int)(playerbullets[x].x+.5),(int)(playerbullets[x].y+.5)),
                              enemies[y].verts)) {
              playerbullets[x].done=true;
              enemies[y].curHP--;
            }
          if(playerbullets[x].done) {
            playerbullets.RemoveAt(x);
            x--;
          }
        }

        for(int x=0;x<enemies.Count;x++) {//render the enemies
          if(enemies[x].curHP<=0) {
            enemies[x].deathAnimation(ref particles);
            enemies.RemoveAt(x);
            x--;
          }
          else
            enemies[x].render(g,this.Width,this.Height,time,ref bullets);
        }

        player.render(g,this.Width,this.Height,time,ref playerbullets,mouseheld);//render the player


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
