using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders {
  public class bullet {
    public double x,y,vel,ang;
    public int len;
    public int rc,gc,bc;
    public bool done;
    public bullet(double xi,double yi,double angi=180,int leni=30,int rci=196,int gci=0,int bci=0,double veli=1.5) {
      x=xi;
      y=yi;
      vel=veli;
      ang=angi;
      len=leni;
      rc=rci;
      gc=gci;
      bc=bci;
      done=false;
    }
    public void render(Graphics g,int scrWidth,int scrHeight,long msPassed) {
      double spd=vel*msPassed;
      x+=spd*Math.Cos(ang*Math.PI/180);
      y+=spd*Math.Sin(ang*Math.PI/180);
      if(x<-len||y<-len||y>scrHeight+len)
        done=true;
      if(ang>=90&&ang<=270) {
        if(x>scrWidth-20)
          done=true;
      }
      else {
        if(x>scrWidth+len)
          done=true;
      }
      Pen p=new Pen(Color.FromArgb(rc,gc,bc));
      p.Width=2;
      g.DrawLine(p,(int)(x+.5),(int)(y+.5),(int)(x-len*Math.Cos(ang*Math.PI/180)+.5),(int)(y-len*Math.Sin(ang*Math.PI/180)+.5));
    }
    public bool hit(List<Point> poly) {
      List<PointF> poly2=new List<PointF>();
      for(int z=0;z<poly.Count;z++)
        poly2.Add((PointF)(poly[z]));
      return hit(poly2);
    }
    public bool hit(List<PointF> poly) {
      bool collide=false;
      for(int z=0;z<=len;z++) {
        PointF coord=new PointF((float)(x-z*Math.Cos(ang*Math.PI/180)),(float)(y-z*Math.Sin(ang*Math.PI/180)));
        if(pointInPolygon(coord,poly))
          collide=true;
      }
      return collide;
    }
    public bool pointInPolygon(PointF p,List<PointF> poly) {
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
  }
}
