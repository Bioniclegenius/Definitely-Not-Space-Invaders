using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders
{
    class BossPentagon:enemycontainer
    {
      public BossPentagon(int scrWidth,int scrHeight) {
      x=scrWidth+r.Next(scrWidth/2,scrWidth);
      y=r.Next(20,scrHeight-20);
      ang=180;
      maxHP=5;
      curHP=maxHP;
    }
    public override void ai(int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul) {
      double spd=.070;
      if(x>-20)
        x-=spd*msPassed;
      else
        curHP=0;
    }
    public override void render(Graphics g,int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul) {
      ai(scrWidth,scrHeight,msPassed,ref bul);
      int rad=45;
      verts=new List<Point>();
      verts.Add(new Point((int)(x+rad*Math.Cos(ang*Math.PI/180) + .5),
                         (int)(y+rad*Math.Sin(ang*Math.PI/180)+.5)));
      verts.Add(new Point((int)(x + rad * Math.Cos((ang - 72) * Math.PI / 180) + .5),
                         (int)(y + rad * Math.Sin((ang - 72) * Math.PI / 180) + .5)));
      verts.Add(new Point((int)(x+rad*Math.Cos((ang-144)*Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin((ang-144)*Math.PI/180)+.5)));
      verts.Add(new Point((int)(x+rad*Math.Cos((ang+144)*Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin((ang+144)*Math.PI/180)+.5)));
      verts.Add(new Point((int)(x+rad*Math.Cos((ang+72) *Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin((ang+72)*Math.PI/180)+.5)));
      SolidBrush b=new SolidBrush(Color.FromArgb(190,0,190));
      g.FillPolygon(b,verts.ToArray());
    }
    public override void deathAnimation(ref List<particle> par) {
      if(x<=-20) {//no animation if it died by just moving offscreen
      }
      else {//animation if it was killed by the player
      }
    }
    public override void hit(double hitx,double hity,ref List<particle> par) {
      curHP--;
    }
  }
}
