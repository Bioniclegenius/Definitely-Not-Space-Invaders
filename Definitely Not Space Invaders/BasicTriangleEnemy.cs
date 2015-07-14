using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders {
  public class BasicTriangleEnemy:enemycontainer {
    public BasicTriangleEnemy(int scrWidth,int scrHeight) {
      x=scrWidth+r.Next(scrWidth/2,scrWidth);
      y=r.Next(20,scrHeight-20);
      ang=180;
      maxHP=3;
      curHP=maxHP;
    }
    public override void ai(int scrWidth,int scrHeight,long msPassed) {
      double spd=.050;
      if(x>-20)
        x-=spd*msPassed;
      else
        curHP=0;
    }
    public override void render(Graphics g,int scrWidth,int scrHeight,long msPassed) {
      ai(scrWidth,scrHeight,msPassed);
      int rad=15;
      Point[] verts=new Point[3];
      verts[0]=new Point((int)(x+rad*Math.Cos(ang*Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin(ang*Math.PI/180)+.5));
      verts[1]=new Point((int)(x+rad*Math.Cos((ang-140)*Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin((ang-140)*Math.PI/180)+.5));
      verts[2]=new Point((int)(x+rad*Math.Cos((ang+140)*Math.PI/180)+.5),
                         (int)(y+rad*Math.Sin((ang+140)*Math.PI/180)+.5));
      SolidBrush b=new SolidBrush(Color.FromArgb(0,192,63));
      g.FillPolygon(b,verts);
    }
    public override void deathAnimation() {
      if(x<=-20) {//no animation if it died by just moving offscreen
      }
      else {//animation if it was killed by the player
      }
    }
  }
}
