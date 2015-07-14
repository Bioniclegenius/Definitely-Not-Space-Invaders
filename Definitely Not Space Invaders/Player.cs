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
    public Player(int scrWidth,int scrHeight) {
      x = 20;
      y = scrHeight/2 + 10;
      ang=0;
      maxHP=20;
      curHP=maxHP;
      origVerts=new List<PointF>();
      origVerts.Add(new PointF(8,0));
      origVerts.Add(new PointF(7,1));
      origVerts.Add(new PointF(1,1));
      origVerts.Add(new PointF(-1,3));
      origVerts.Add(new PointF(-6,3));
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
      origVerts.Add(new PointF(-6,-3));
      origVerts.Add(new PointF(-1,-3));
      origVerts.Add(new PointF(1,-1));
      origVerts.Add(new PointF(7,-1));
      origVerts.Add(new PointF(8,0));
    }
    public void ai(int scrWidth,int scrHeight,long msPassed) {
      double spd=0;
      if(x>-20)
        x-=spd*msPassed;
      else
        curHP=0;
    }
    public void render(Graphics g,int scrWidth,int scrHeight,long msPassed) {
      ai(scrWidth,scrHeight,msPassed);
      List<PointF> verts=new List<PointF>();
      for(int z=0;z<origVerts.Count;z++) {
        verts.Add(new PointF(
            (float)(2*origVerts[z].X*Math.Cos(ang*Math.PI/180)-2*origVerts[z].Y*Math.Sin(ang*Math.PI/180)+x),
            (float)(2*origVerts[z].X*Math.Sin(ang*Math.PI/180)+2*origVerts[z].Y*Math.Cos(ang*Math.PI/180)+y)));
      }
      SolidBrush b=new SolidBrush(Color.FromArgb(255,0,0));
      g.FillPolygon(b,verts.ToArray());
    }
    public void deathAnimation() {
      if(x<=-20) {//no animation if it died by just moving offscreen
      }
      else {//animation if it was killed by the player
      }
    }
  }
}
