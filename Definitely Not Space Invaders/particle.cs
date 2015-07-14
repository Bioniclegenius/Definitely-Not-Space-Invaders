using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders {
  public class particle {
    public double x,y,ang,vel,acc,rad;
    public int r,g,b,curLife,maxLife;
    public particle(double xi,double yi,double radi,double angi,double veli,double acci,int lifei,int ri,int gi,int bi) {
      x=xi;
      y=yi;
      rad=radi;
      ang=angi;
      vel=veli;
      acc=acci;
      maxLife=lifei;
      curLife=maxLife;
      r=ri;
      g=gi;
      b=bi;
    }
    public void ai(int scrWidth,int scrHeight,long msPassed) {
      if(curLife>0) {
        x+=vel*Math.Cos(ang*Math.PI/180);
        y+=vel*Math.Sin(ang*Math.PI/180);
        vel+=acc;
        curLife--;
      }
    }
    public void render(Graphics gr,int scrWidth,int scrHeight,long msPassed) {
      ai(scrWidth,scrHeight,msPassed);
      SolidBrush br=new SolidBrush(Color.FromArgb((int)(r*(1.0*curLife/maxLife)),(int)(g*(1.0*curLife/maxLife)),(int)(b*(1.0*curLife/maxLife))));
      gr.FillEllipse(br,(int)(x-rad+.5),(int)(y-rad+.5),(int)(2*rad+1.5),(int)(2*rad+1.5));
    }
  }
}
