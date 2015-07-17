using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders {
  class CannonWingEnemy:enemycontainer {
    public int bulcounter;
    public int parcounter;
    public int slowparcounter;
    public int rad;
    public int rightwinghp;
    public int leftwinghp;
    public List<int> parts;
    public CannonWingEnemy(int scrWidth,int scrHeight) {
      x=scrWidth+r.Next(60,140);
      y=r.Next(40,scrHeight-40);
      ang=180;
      maxHP=100;
      curHP=maxHP;
      rightwinghp=5;
      leftwinghp=rightwinghp;
      bulcounter=0;
      parcounter=0;
      rad=15;
      parts=new List<int>();
      parts.Add(0);//0 = body
      parts.Add(0);
      parts.Add(0);
      parts.Add(1);//1 = right wing
      parts.Add(1);
      parts.Add(2);//2 = left wing
      parts.Add(2);
      origVerts=new List<List<PointF> >();
      colors=new List<Color>();
      origVerts.Add(new List<PointF>());//main body thrusters
      origVerts[origVerts.Count-1].Add(new PointF(-20,12));
      origVerts[origVerts.Count-1].Add(new PointF(-24,10));
      origVerts[origVerts.Count-1].Add(new PointF(-24,7));
      origVerts[origVerts.Count-1].Add(new PointF(-24,4));
      origVerts[origVerts.Count-1].Add(new PointF(-20,2));
      origVerts[origVerts.Count-1].Add(new PointF(-20,-2));
      origVerts[origVerts.Count-1].Add(new PointF(-24,-4));
      origVerts[origVerts.Count-1].Add(new PointF(-24,-7));
      origVerts[origVerts.Count-1].Add(new PointF(-24,-10));
      origVerts[origVerts.Count-1].Add(new PointF(-20,-12));
      colors.Add(Color.FromArgb(127,127,127));
      origVerts.Add(new List<PointF>());//main body cockpit
      origVerts[origVerts.Count-1].Add(new PointF(58,6));
      origVerts[origVerts.Count-1].Add(new PointF(60,5));
      origVerts[origVerts.Count-1].Add(new PointF(61,4));
      origVerts[origVerts.Count-1].Add(new PointF(62,2));
      origVerts[origVerts.Count-1].Add(new PointF((float)(62.5),0));
      origVerts[origVerts.Count-1].Add(new PointF((float)(62.5),0));
      origVerts[origVerts.Count-1].Add(new PointF(62,-2));
      origVerts[origVerts.Count-1].Add(new PointF(61,-4));
      origVerts[origVerts.Count-1].Add(new PointF(60,-5));
      origVerts[origVerts.Count-1].Add(new PointF(58,-6));
      colors.Add(Color.FromArgb(127,127,255));
      origVerts.Add(new List<PointF>());//main body
      origVerts[origVerts.Count-1].Add(new PointF(-20,14));
      origVerts[origVerts.Count-1].Add(new PointF(-16,16));
      origVerts[origVerts.Count-1].Add(new PointF(42,16));
      origVerts[origVerts.Count-1].Add(new PointF(48,14));
      origVerts[origVerts.Count-1].Add(new PointF(52,12));
      origVerts[origVerts.Count-1].Add(new PointF(54,10));
      origVerts[origVerts.Count-1].Add(new PointF(56,6));
      origVerts[origVerts.Count-1].Add(new PointF(58,6));
      origVerts[origVerts.Count-1].Add(new PointF(58,-6));
      origVerts[origVerts.Count-1].Add(new PointF(56,-6));
      origVerts[origVerts.Count-1].Add(new PointF(54,-10));
      origVerts[origVerts.Count-1].Add(new PointF(54,-12));
      origVerts[origVerts.Count-1].Add(new PointF(48,-14));
      origVerts[origVerts.Count-1].Add(new PointF(42,-16));
      origVerts[origVerts.Count-1].Add(new PointF(-16,-16));
      origVerts[origVerts.Count-1].Add(new PointF(-20,-14));
      colors.Add(Color.FromArgb(196,196,196));
      origVerts.Add(new List<PointF>());//right wing cannon and connectors
      origVerts[origVerts.Count-1].Add(new PointF(-5,32));
      origVerts[origVerts.Count-1].Add(new PointF(44,32));
      origVerts[origVerts.Count-1].Add(new PointF(44,31));
      origVerts[origVerts.Count-1].Add(new PointF(44,30));
      origVerts[origVerts.Count-1].Add(new PointF(7,30));
      origVerts[origVerts.Count-1].Add(new PointF(7,16));
      origVerts[origVerts.Count-1].Add(new PointF(2,16));
      origVerts[origVerts.Count-1].Add(new PointF(2,30));
      origVerts[origVerts.Count-1].Add(new PointF(0,30));
      origVerts[origVerts.Count-1].Add(new PointF(0,16));
      origVerts[origVerts.Count-1].Add(new PointF(-5,16));
      origVerts[origVerts.Count-1].Add(new PointF(-5,30));
      origVerts[origVerts.Count-1].Add(new PointF(-20,30));
      origVerts[origVerts.Count-1].Add(new PointF(-20,31));
      origVerts[origVerts.Count-1].Add(new PointF(-20,32));
      colors.Add(Color.FromArgb(127,127,127));
      origVerts.Add(new List<PointF>());//right wing
      origVerts[origVerts.Count-1].Add(new PointF(-10,40));
      origVerts[origVerts.Count-1].Add(new PointF(10,40));
      origVerts[origVerts.Count-1].Add(new PointF(16,38));
      origVerts[origVerts.Count-1].Add(new PointF(20,36));
      origVerts[origVerts.Count-1].Add(new PointF(22,34));
      origVerts[origVerts.Count-1].Add(new PointF(22,28));
      origVerts[origVerts.Count-1].Add(new PointF(20,26));
      origVerts[origVerts.Count-1].Add(new PointF(16,24));
      origVerts[origVerts.Count-1].Add(new PointF(10,22));
      origVerts[origVerts.Count-1].Add(new PointF(-10,22));
      origVerts[origVerts.Count-1].Add(new PointF(-14,24));
      origVerts[origVerts.Count-1].Add(new PointF(-16,26));
      origVerts[origVerts.Count-1].Add(new PointF(-18,30));
      origVerts[origVerts.Count-1].Add(new PointF(-18,32));
      origVerts[origVerts.Count-1].Add(new PointF(-16,36));
      origVerts[origVerts.Count-1].Add(new PointF(-14,38));
      colors.Add(Color.FromArgb(196,196,196));
      origVerts.Add(new List<PointF>());//left wing cannon and connections
      origVerts[origVerts.Count-1].Add(new PointF(-5,-32));
      origVerts[origVerts.Count-1].Add(new PointF(44,-32));
      origVerts[origVerts.Count-1].Add(new PointF(44,-31));
      origVerts[origVerts.Count-1].Add(new PointF(44,-30));
      origVerts[origVerts.Count-1].Add(new PointF(7,-30));
      origVerts[origVerts.Count-1].Add(new PointF(7,-16));
      origVerts[origVerts.Count-1].Add(new PointF(2,-16));
      origVerts[origVerts.Count-1].Add(new PointF(2,-30));
      origVerts[origVerts.Count-1].Add(new PointF(0,-30));
      origVerts[origVerts.Count-1].Add(new PointF(0,-16));
      origVerts[origVerts.Count-1].Add(new PointF(-5,-16));
      origVerts[origVerts.Count-1].Add(new PointF(-5,-30));
      origVerts[origVerts.Count-1].Add(new PointF(-20,-30));
      origVerts[origVerts.Count-1].Add(new PointF(-20,-31));
      origVerts[origVerts.Count-1].Add(new PointF(-20,-32));
      colors.Add(Color.FromArgb(127,127,127));
      origVerts.Add(new List<PointF>());//left wing
      origVerts[origVerts.Count-1].Add(new PointF(-10,-40));
      origVerts[origVerts.Count-1].Add(new PointF(10,-40));
      origVerts[origVerts.Count-1].Add(new PointF(16,-38));
      origVerts[origVerts.Count-1].Add(new PointF(20,-36));
      origVerts[origVerts.Count-1].Add(new PointF(22,-34));
      origVerts[origVerts.Count-1].Add(new PointF(22,-28));
      origVerts[origVerts.Count-1].Add(new PointF(20,-26));
      origVerts[origVerts.Count-1].Add(new PointF(16,-24));
      origVerts[origVerts.Count-1].Add(new PointF(10,-22));
      origVerts[origVerts.Count-1].Add(new PointF(-10,-22));
      origVerts[origVerts.Count-1].Add(new PointF(-14,-24));
      origVerts[origVerts.Count-1].Add(new PointF(-16,-26));
      origVerts[origVerts.Count-1].Add(new PointF(-18,-30));
      origVerts[origVerts.Count-1].Add(new PointF(-18,-32));
      origVerts[origVerts.Count-1].Add(new PointF(-16,-36));
      origVerts[origVerts.Count-1].Add(new PointF(-14,-38));
      colors.Add(Color.FromArgb(196,196,196));
    }
    public override void ai(int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul,ref List<particle> par) {
      if(rightwinghp<=0) {
        for(int z=0;z<parts.Count;z++)
          if(parts[z]==1) {
            double parx=32*Math.Sin(ang*Math.PI/180)+x;
            double pary=32*Math.Cos(ang*Math.PI/180)+y;
            for(int t=0;t<7;t++) {
              double velo=r.Next(500,900);
              velo/=1000;
              par.Add(new particle(parx,pary,2,r.Next(0,360),velo,-velo/2000,500,colors[z].R,colors[z].G,colors[z].B));
            }
            for(int t=0;t<2;t++) {
              double velo=r.Next(750,1250);
              velo/=1000;
              par.Add(new particle(x,y,2,r.Next(0,360),velo,-velo/2000,500,r.Next(0,7)));
            }
            parts.RemoveAt(z);
            origVerts.RemoveAt(z);
            colors.RemoveAt(z);
            z--;
          }
        curHP-=45;
        rightwinghp=1;
      }
      if(leftwinghp<=0) {
        for(int z=0;z<parts.Count;z++)
          if(parts[z]==2) {
            double parx=32*Math.Sin(ang*Math.PI/180)+x;
            double pary=-32*Math.Cos(ang*Math.PI/180)+y;
            for(int t=0;t<7;t++) {
              double velo=r.Next(500,900);
              velo/=1000;
              par.Add(new particle(parx,pary,2,r.Next(0,360),velo,-velo/2000,500,colors[z].R,colors[z].G,colors[z].B));
            }
            for(int t=0;t<2;t++) {
              double velo=r.Next(750,1250);
              velo/=1000;
              par.Add(new particle(x,y,2,r.Next(0,360),velo,-velo/2000,500,r.Next(0,7)));
            }
            parts.RemoveAt(z);
            origVerts.RemoveAt(z);
            colors.RemoveAt(z);
            z--;
          }
        curHP-=45;
        leftwinghp=1;
      }
      double spd=.020;
      if(x>-20)
        x-=spd*msPassed;
      else
        curHP=0;
      bulcounter+=(int)(msPassed);
      parcounter+=(int)(msPassed);
      int bulSpawnTime=1000;
      int parSpawnTime=30;
      while(bulcounter>=bulSpawnTime) {
        if(verts.Count>=5) {
          bul.Add(new bullet(verts[3][2].X,verts[3][2].Y,ang));
          bul.Add(new bullet(verts[3][2].X,verts[3][2].Y,ang));
          bul.Add(new bullet(verts[3][2].X,verts[3][2].Y,ang));
        }
        if(verts.Count>=7) {
          bul.Add(new bullet(verts[5][2].X,verts[5][2].Y,ang));
          bul.Add(new bullet(verts[5][2].X,verts[5][2].Y,ang));
          bul.Add(new bullet(verts[5][2].X,verts[5][2].Y,ang));
        }
        bulcounter-=bulSpawnTime;
      }
      while(parcounter>parSpawnTime) {
        float acc=r.Next(750,1500);
        acc/=1000;
        par.Add(new particle(verts[0][2].X,verts[0][2].Y,2,ang+r.Next(160,201),acc,-acc/600,600,r.Next(0,7)));
        acc=r.Next(750,1500);
        acc/=1000;
        par.Add(new particle(verts[0][7].X,verts[0][7].Y,2,ang+r.Next(160,201),acc,-acc/600,600,r.Next(0,7)));
        slowparcounter++;
        parcounter-=parSpawnTime;
      }
      while(slowparcounter>=4) {
        if(verts.Count>=5) {
          float acc=r.Next(200,400);
          acc/=1000;
          par.Add(new particle(verts[3][13].X,verts[3][13].Y,2,ang+r.Next(160,201),acc,-acc/600,600,r.Next(0,7)));
        }
        if(verts.Count>=7) {
          float acc=r.Next(200,400);
          acc/=1000;
          par.Add(new particle(verts[5][13].X,verts[5][13].Y,2,ang+r.Next(160,201),acc,-acc/600,600,r.Next(0,7)));
        }
        slowparcounter-=4;
      }
    }
    public override void deathAnimation(ref List<particle> par) {
      if(x<=-20) {//no animation if it died by just moving offscreen
      }
      else {//animation if it was killed by the player
        for(int z=0;z<100;z++) {
          double velo=r.Next(300,1500);
          velo/=1000;
          par.Add(new particle(x,y,2,r.Next(0,360),velo,-velo/2000,2000,colors[0].R,colors[0].G,colors[0].B));
        }
        for(int z=0;z<30;z++) {
          double velo=r.Next(30,1500);
          velo/=1000;
          par.Add(new particle(x,y,2,r.Next(0,360),velo,-velo/2000,2000,r.Next(0,7)));
        }
      }
    }
    public override void hit(double hitx,double hity,int num,ref List<particle> par) {
      for(int z=0;z<r.Next(2,6);z++) {
        double velo=r.Next(500,900);
        velo/=1000;
        par.Add(new particle(hitx,hity,2,r.Next(0,360),velo,-velo/2000,500,colors[num].R,colors[num].G,colors[num].B));
      }
      if(parts[num]==1)
        rightwinghp--;
      else if(parts[num]==2)
        leftwinghp--;
      else
        curHP--;
    }
  }
}
