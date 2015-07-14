using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders
{
    class Player:playerContainer{
    public Player(int scrWidth,int scrHeight) {
        x = 20;
        y = scrHeight/2 + 10;
      ang=180;
      maxHP=20;
      curHP=maxHP;
    }
    public override void ai(int scrWidth,int scrHeight,long msPassed) {
      double spd=0;
      if(x>-20)
        x-=spd*msPassed;
      else
        curHP=0;
    }
    public override void render(Graphics g,int scrWidth,int scrHeight,long msPassed) {
      ai(scrWidth,scrHeight,msPassed);
      int rad=25;
      Point[] verts=new Point[3];
      verts[0]=new Point((int)(x+rad*Math.Cos(ang*Math.PI/90)+.5),
                         (int)(y+rad*Math.Sin(ang*Math.PI/90)+.5));
      verts[1]=new Point((int)(x+rad*Math.Cos((ang-140)*Math.PI/90)+.5),
                         (int)(y+rad*Math.Sin((ang-140)*Math.PI/90)+.5));
      verts[2]=new Point((int)(x+rad*Math.Cos((ang+140)*Math.PI/90)+.5),
                         (int)(y+rad*Math.Sin((ang+140)*Math.PI/90)+.5));
      SolidBrush b=new SolidBrush(Color.FromArgb(255,0,0));
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
