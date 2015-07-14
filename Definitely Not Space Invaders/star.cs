using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders {
  public class star {
    public double x,y;
    public int size;
    public static Random r=new Random();
    public star(int scrWidth,int scrHeight) {
      x=r.Next(0,2*scrWidth);
      y=r.Next(0,scrHeight);
      size=r.Next(1,51);
    }
    public void paint(Graphics g,int scrWidth,int scrHeight,long mspassed=0) {
      SolidBrush b;
      double basespeed=.020;
      double speedfactor=.0005;
      double curspeed=basespeed+(size-1)*speedfactor;
      x-=curspeed*mspassed;
      if(x<-5) {
        x=r.Next(scrWidth,scrWidth*2);
        y=r.Next(0,scrHeight);
        size=r.Next(1,51);
      }
      if(x<scrWidth+5) {
        for(int z=0;z<(int)(size/10.0+.5);z++) {
          b=new SolidBrush(Color.FromArgb(196-32*z,196-32*z,196-32*z));
          g.FillRectangle(b,(int)(x-z+.5),(int)(y+.5),1,1);
          g.FillRectangle(b,(int)(x+z+.5),(int)(y+.5),1,1);
          g.FillRectangle(b,(int)(x+.5),(int)(y-z+.5),1,1);
          g.FillRectangle(b,(int)(x+.5),(int)(y+z+.5),1,1);
        }
      }
    }
  }
}
