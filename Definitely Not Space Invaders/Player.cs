using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders
{
  public class Player{
    public int curHP, maxHP;
    public double x, y, ang;
    public List<PointF> origVerts;
    public List<particle> particles;
    int timestamp;
    Random r=new Random();
    int goalx,goaly;
    public Player(int scrWidth,int scrHeight) {
      x = 20;
      y = scrHeight/2;
      goalx=(int)(x);
      goaly=(int)(y);
      ang=0;
      maxHP=20;
      curHP=maxHP;
      timestamp=0;
      origVerts=new List<PointF>();
      particles=new List<particle>();
      origVerts.Add(new PointF(8,0));
      origVerts.Add(new PointF(7,1));
      origVerts.Add(new PointF(1,1));
      origVerts.Add(new PointF(-1,3));
      origVerts.Add(new PointF(-4,3));
      origVerts.Add(new PointF(-6,5));
      origVerts.Add(new PointF(3,5));
      origVerts.Add(new PointF(3,6));
      origVerts.Add(new PointF(-7,6));
      origVerts.Add(new PointF(-7,1));
      origVerts.Add(new PointF(-8,1));
      origVerts.Add(new PointF(-8,-1));
      origVerts.Add(new PointF(-7,-1));
      origVerts.Add(new PointF(-7,-6));
      origVerts.Add(new PointF(3,-6));
      origVerts.Add(new PointF(3,-5));
      origVerts.Add(new PointF(-6,-5));
      origVerts.Add(new PointF(-4,-3));
      origVerts.Add(new PointF(-1,-3));
      origVerts.Add(new PointF(1,-1));
      origVerts.Add(new PointF(7,-1));
      origVerts.Add(new PointF(8,0));
    }
    public void ai(int scrWidth,int scrHeight,long msPassed) {
      double moveang=Math.Atan2(goaly-y,goalx-x);
      double playerspd=0.300;
      double moverad=10;
      if(Math.Sqrt(Math.Pow(goalx-x,2)+Math.Pow(goaly-y,2))>moverad) {
        x+=playerspd*msPassed*Math.Cos(moveang);
        y+=playerspd*msPassed*Math.Sin(moveang);
      }
    }
    public void render(Graphics g,int scrWidth,int scrHeight,long msPassed) {
      ai(scrWidth,scrHeight,msPassed);
      List<PointF> verts=new List<PointF>();
      timestamp+=(int)(msPassed);
      int partSpawnTime=30;
      if(timestamp>partSpawnTime) {
        int rcol=0,gcol=0,bcol=0;
        switch(r.Next(0,7)) {
          case 0:
            rcol=255;
            gcol=0;
            bcol=0;
            break;
          case 1:
            rcol=255;
            gcol=127;
            bcol=0;
            break;
          case 2:
            rcol=255;
            gcol=255;
            bcol=0;
            break;
          case 3:
            rcol=0;
            gcol=255;
            bcol=0;
            break;
          case 4:
            rcol=0;
            gcol=255;
            bcol=255;
            break;
          case 5:
            rcol=0;
            gcol=0;
            bcol=255;
            break;
          case 6:
            rcol=255;
            gcol=0;
            bcol=255;
            break;
        }
        float velocity=r.Next(750,1500);
        velocity/=1000;
        particles.Add(new particle(x-8,y,3,r.Next(160,200),velocity,velocity/100,100,rcol,gcol,bcol));
        timestamp-=partSpawnTime;
      }
      for(int z=0;z<origVerts.Count;z++) {
        verts.Add(new PointF((float)(2*origVerts[z].X+x),(float)(2*origVerts[z].Y+y)));
            //(float)(2*origVerts[z].X*Math.Cos(ang*Math.PI/180)-2*origVerts[z].Y*Math.Sin(ang*Math.PI/180)+x),
            //(float)(2*origVerts[z].X*Math.Sin(ang*Math.PI/180)+2*origVerts[z].Y*Math.Cos(ang*Math.PI/180)+y)));
      }
      for(int z=0;z<particles.Count;z++) {
        particles[z].render(g,scrWidth,scrHeight,msPassed);
        if(particles[z].curLife<=0) {
          particles.RemoveAt(z);
          z--;
        }
      }
      SolidBrush b=new SolidBrush(Color.FromArgb(255,255,255));
      g.FillPolygon(b,verts.ToArray());
    }
    public void deathAnimation() {
    }
    public void mousemove(int mx,int my) {
      goalx=mx;
      goaly=my;
    }
  }
}
