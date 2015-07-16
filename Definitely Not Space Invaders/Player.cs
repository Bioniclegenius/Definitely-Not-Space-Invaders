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
    public List<List<PointF> > origVerts;
    public List<particle> particles;
    public List<List<PointF> > verts;
    public int timestamp;
    public int bulTimer;
    public int bulCooldown;
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
      origVerts=new List<List<PointF> >();
      particles=new List<particle>();
      origVerts.Add(new List<PointF>());
      origVerts[0].Add(new PointF(16,0));
      origVerts[0].Add(new PointF(14,2));
      origVerts[0].Add(new PointF(2,2));
      origVerts[0].Add(new PointF(-2,6));
      origVerts[0].Add(new PointF(-8,6));
      origVerts[0].Add(new PointF(-12,10));
      origVerts[0].Add(new PointF(6,10));
      origVerts[0].Add(new PointF(6,12));
      origVerts[0].Add(new PointF(-14,12));
      origVerts[0].Add(new PointF(-14,2));
      origVerts[0].Add(new PointF(-16,2));
      origVerts[0].Add(new PointF(-16,-2));
      origVerts[0].Add(new PointF(-14,-2));
      origVerts[0].Add(new PointF(-14,-12));
      origVerts[0].Add(new PointF(6,-12));
      origVerts[0].Add(new PointF(6,-10));
      origVerts[0].Add(new PointF(-12,-10));
      origVerts[0].Add(new PointF(-8,-6));
      origVerts[0].Add(new PointF(-2,-6));
      origVerts[0].Add(new PointF(2,-2));
      origVerts[0].Add(new PointF(14,-2));
      origVerts[0].Add(new PointF(16,0));
      bulCooldown=0;
      bulTimer=500;
    }
    public void ai(int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul,bool mousedown) {
      double moveang=Math.Atan2(goaly-y,goalx-x);
      double playerspd=0.300;
      double moverad=10;
      if(Math.Sqrt(Math.Pow(goalx-x,2)+Math.Pow(goaly-y,2))>moverad) {
        x+=playerspd*msPassed*Math.Cos(moveang);
        y+=playerspd*msPassed*Math.Sin(moveang);
      }
      if(bulCooldown>0)
        bulCooldown-=(int)(msPassed);
      if(mousedown&&bulCooldown<=0) {
        bulCooldown+=bulTimer;
        bul.Add(new bullet(x+6,y-11,0));
        bul.Add(new bullet(x+6,y+11,0));
      }
      else if(bulCooldown<0)
        bulCooldown=0;
    }
    public void render(Graphics g,int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul,bool mousedown) {
      ai(scrWidth,scrHeight,msPassed,ref bul,mousedown);
      verts=new List<List<PointF> >();
      timestamp+=(int)(msPassed);
      int partSpawnTime=30;
      if(timestamp>partSpawnTime) {
        float velocity=r.Next(750,1500);
        velocity/=1000;
        particles.Add(new particle(x-8,y,2,r.Next(160,200),velocity,-velocity/500,500,r.Next(0,7)));
        timestamp-=partSpawnTime;
      }
      for(int z=0;z<particles.Count;z++) {
        particles[z].render(g,scrWidth,scrHeight,msPassed);
        if(particles[z].curLife<=0) {
          particles.RemoveAt(z);
          z--;
        }
      }
      SolidBrush b=new SolidBrush(Color.FromArgb(255,255,255));
      for(int t=0;t<origVerts.Count;t++) {
        verts.Add(new List<PointF>());
        for(int z=0;z<origVerts[t].Count;z++) {
          verts[t].Add(new PointF(
              (float)(origVerts[t][z].X*Math.Cos(ang*Math.PI/180)-origVerts[t][z].Y*Math.Sin(ang*Math.PI/180)+x),
              (float)(origVerts[t][z].X*Math.Sin(ang*Math.PI/180)+origVerts[t][z].Y*Math.Cos(ang*Math.PI/180)+y)));
        }
        b.Color=Color.FromArgb(255,255,255);
        g.FillPolygon(b,verts[t].ToArray());
      }
      Font f=new Font("Segoi UI",10);
      g.DrawString(Convert.ToString(curHP)+"/"+Convert.ToString(maxHP),f,b,new PointF(5,5));
    }
    public void deathAnimation() {
    }
    public void hit(double hitx,double hity,int num,ref List<particle> par) {
      curHP--;
    }
    public void mousemove(int mx,int my) {
      goalx=mx;
      goaly=my;
    }
  }
}
