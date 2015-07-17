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
    public particle(double xi,double yi,double radi,double angi,double veli,double acci,int lifei,int colCode) {
      x=xi;
      y=yi;
      rad=radi;
      ang=angi;
      vel=veli;
      acc=acci;
      maxLife=lifei;
      curLife=maxLife;
      switch(colCode) {
        case 0:
          r=255;
          g=0;
          b=0;
          break;
        case 1:
          r=255;
          g=127;
          b=0;
          break;
        case 2:
          r=255;
          g=255;
          b=0;
          break;
        case 3:
          r=0;
          g=255;
          b=0;
          break;
        case 4:
          r=0;
          g=255;
          b=255;
          break;
        case 5:
          r=0;
          g=0;
          b=255;
          break;
        case 6:
          r=255;
          g=0;
          b=255;
          break;
        default:
          r=255;
          g=255;
          b=255;
          break;
      }
    }
    public void ai(int scrWidth,int scrHeight,long msPassed) {
      if(curLife>0) {
        x+=vel*Math.Cos(ang*Math.PI/180);
        y+=vel*Math.Sin(ang*Math.PI/180);
        vel+=acc*msPassed;
        curLife-=(int)(msPassed);
        if(curLife<0)
          curLife=0;
      }
    }
    public void render(Graphics gr,int scrWidth,int scrHeight,long msPassed) {
      ai(scrWidth,scrHeight,msPassed);
      SolidBrush br=new SolidBrush(Color.FromArgb((int)(255.0*curLife/maxLife),r,g,b));
      gr.FillEllipse(br,(int)(x-rad-.5),(int)(y-rad-.5),(int)(2*rad+1.5),(int)(2*rad+1.5));
    }
  }
}
