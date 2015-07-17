using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders {
  public class BasicTriangleEnemy:enemycontainer {
    public int counter;
    public int rad;
    public BasicTriangleEnemy(int scrWidth,int scrHeight) {
      x=scrWidth+r.Next(30,scrWidth);
      y=r.Next(20,scrHeight-20);
      ang=180;
      maxHP=3;
      curHP=maxHP;
      counter=0;
      origVerts=new List<List<PointF> >();
      colors=new List<Color>();
      origVerts.Add(new List<PointF>());
      rad=15;
      origVerts[0].Add(new PointF(
                             (float)(rad),
                             (float)(0)));
      origVerts[0].Add(new PointF(
                             (float)(rad*Math.Cos(140*Math.PI/180)),
                             (float)(rad*Math.Sin(140*Math.PI/180))));
      origVerts[0].Add(new PointF(
                             (float)(rad*Math.Cos(220*Math.PI/180)),
                             (float)(rad*Math.Sin(220*Math.PI/180))));
      colors.Add(Color.FromArgb(0,196,63));
    }
    public override void ai(int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul,ref List<particle> par) {
      double spd=.050;
      if(x>-20)
        x-=spd*msPassed;
      else
        curHP=0;
      counter+=(int)(msPassed);
      int bulSpawnTime=1000;
      if(counter>=bulSpawnTime) {
        bul.Add(new bullet(x+rad*Math.Cos(ang*Math.PI/180),y+rad*Math.Sin(ang*Math.PI/180),ang));
        counter-=bulSpawnTime;
      }
    }
    public override void deathAnimation(ref List<particle> par) {
      if(x<=-20) {//no animation if it died by just moving offscreen
      }
      else {//animation if it was killed by the player
        for(int z=0;z<20;z++) {
          double velo=r.Next(500,900);
          velo/=1000;
          par.Add(new particle(x,y,2,r.Next(0,360),velo,-velo/2000,500,0,192,63));
        }
        for(int z=0;z<5;z++) {
          double velo=r.Next(750,1250);
          velo/=1000;
          par.Add(new particle(x,y,2,r.Next(0,360),velo,-velo/2000,500,r.Next(0,7)));
        }
      }
    }
    public override void hit(double hitx,double hity,int num,ref List<particle> par) {
      for(int z=0;z<r.Next(2,6);z++) {
        double velo=r.Next(500,900);
        velo/=1000;
        par.Add(new particle(hitx,hity,2,r.Next(0,360),velo,-velo/2000,500,colors[num].R,colors[num].G,colors[num].B));
      }
      curHP--;
    }
  }
}
