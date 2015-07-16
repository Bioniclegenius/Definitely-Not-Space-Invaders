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
      origVerts=new List<List<PointF> >();
      colors=new List<Color>();
      origVerts.Add(new List<PointF>());
      float rad=45;
      origVerts[0].Add(new PointF(
                             (float)(rad),
                             (float)(0)));
      origVerts[0].Add(new PointF(
                             (float)(rad*Math.Cos(72*Math.PI/180)),
                             (float)(rad*Math.Sin(72*Math.PI/180))));
      origVerts[0].Add(new PointF(
                             (float)(rad*Math.Cos(144*Math.PI/180)),
                             (float)(rad*Math.Sin(144*Math.PI/180))));
      origVerts[0].Add(new PointF(
                             (float)(rad*Math.Cos(216*Math.PI/180)),
                             (float)(rad*Math.Sin(216*Math.PI/180))));
      origVerts[0].Add(new PointF(
                             (float)(rad*Math.Cos(288*Math.PI/180)),
                             (float)(rad*Math.Sin(288*Math.PI/180))));
      colors.Add(Color.FromArgb(190,0,190));
    }
    public override void ai(int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul) {
      double spd=.070;
      if(x>-20)
        x-=spd*msPassed;
      else
        curHP=0;
    }
    public override void deathAnimation(ref List<particle> par) {
      if(x<=-20) {//no animation if it died by just moving offscreen
      }
      else {//animation if it was killed by the player
      }
    }
    public override void hit(double hitx,double hity,int num,ref List<particle> par) {
      curHP--;
    }
  }
}
