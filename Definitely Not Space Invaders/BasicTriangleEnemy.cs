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
      rad=15;
    }
    public override void ai(int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul) {
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
    public override void render(Graphics g,int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul) {
      ai(scrWidth,scrHeight,msPassed,ref bul);
      List<Point> verts=new List<Point>();
      verts.Add(new Point((int)(x+rad*Math.Cos(ang*Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin(ang*Math.PI/180)+.5)));
      verts.Add(new Point((int)(x+rad*Math.Cos((ang-140)*Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin((ang-140)*Math.PI/180)+.5)));
      verts.Add(new Point((int)(x+rad*Math.Cos((ang+140)*Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin((ang+140)*Math.PI/180)+.5)));
      SolidBrush b=new SolidBrush(Color.FromArgb(0,192,63));
      g.FillPolygon(b,verts.ToArray());
    }
    public override void deathAnimation(ref List<particle> par) {
      if(x<=-20) {//no animation if it died by just moving offscreen
      }
      else {//animation if it was killed by the player
        for(int z=0;z<20;z++) {
          double velo=r.Next(750,1250);
          velo/=1000;
          par.Add(new particle(x,y,3,r.Next(0,360),velo,-velo/2000,500,0,192,63));
        }
        for(int z=0;z<5;z++) {
          double velo=r.Next(750,1250);
          velo/=1000;
          par.Add(new particle(x,y,3,r.Next(0,360),velo,-velo/2000,500,r.Next(0,7)));
        }
      }
    }
  }
}
