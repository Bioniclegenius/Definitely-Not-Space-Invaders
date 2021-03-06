﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Definitely_Not_Space_Invaders {
  public class drawingpanel:Panel {
    public List<star> stars;
    public System.Diagnostics.Stopwatch st=new System.Diagnostics.Stopwatch();
    public long lasttime;
    public List<enemycontainer> enemies;
    public List<bullet> bullets;
    public List<bullet> playerbullets;
    public List<particle> particles;
    public Player player;
    public bool mouseheld=false;
    public drawingpanel(int dimx=100,int dimy=100) {
      this.Size=new Size(dimx,dimy);
      this.Location=new Point(0,0);
      this.DoubleBuffered=true;
      this.Paint+=new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
      this.MouseMove+=new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
      this.MouseDown+=new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
      this.MouseUp+=new System.Windows.Forms.MouseEventHandler(this.MouseUpEvent);
      stars=new List<star>();
      enemies=new List<enemycontainer>();
      enemies.Add(new CannonWingEnemy(this.Width,this.Height));
      bullets=new List<bullet>();
      playerbullets=new List<bullet>();
      particles=new List<particle>();
      player = new Player(dimx, dimy);
      for(int x=0;x<50.0*Math.Sqrt(dimx*dimy)/100;x++)
        stars.Add(new star(dimx,dimy));
      st.Start();
      lasttime=st.ElapsedMilliseconds;
      Invalidate();
    }
    public void PaintEvent(object sender,PaintEventArgs e) {
      SolidBrush b=new SolidBrush(Color.FromArgb(0,0,0));
      Graphics g=e.Graphics;
      long time=st.ElapsedMilliseconds-lasttime;
      lasttime+=time;
      if(time!=0) {

        g.FillRectangle(b,0,0,this.Width,this.Height);//the background

        for(int x=0;x<stars.Count;x++)//render the stars
          stars[x].paint(g,this.Width,this.Height,time);

        for(int x=0;x<particles.Count;x++) {//render the enemy particles
          particles[x].render(g,this.Width,this.Height,time);
          if(particles[x].curLife<=0) {
            particles.RemoveAt(x);
            x--;
          }
        }

        for(int x=0;x<bullets.Count;x++) {//all enemy bullets
          bullets[x].render(g,this.Width,this.Height,time);
          for(int y=0;y<player.verts.Count;y++) {
            if(bullets[x].hit(player.verts[y])&&!bullets[x].done) {
              bullets[x].done=true;
              player.hit(bullets[x].x,bullets[x].y,y,ref particles);
            }
          }
          if(bullets[x].done) {
            bullets.RemoveAt(x);
            x--;
          }
        }

        for(int x=0;x<playerbullets.Count;x++) {//the player's bullets
          playerbullets[x].render(g,this.Width,this.Height,time);
          for(int y=0;y<enemies.Count;y++) {
            if(enemies[y].verts!=null) {
              for(int t=0;t<enemies[y].verts.Count;t++) {
                if(playerbullets[x].hit(enemies[y].verts[t])&&!playerbullets[x].done&&enemies[y].curHP>0) {
                  playerbullets[x].done=true;
                  enemies[y].hit(playerbullets[x].x,playerbullets[x].y,t,ref particles);
                }
              }
            }
          }
          if(playerbullets[x].done) {
            playerbullets.RemoveAt(x);
            x--;
          }
        }

        for(int x=0;x<enemies.Count;x++) {//render the enemies
          if(enemies[x].curHP<=0) {
            enemies[x].deathAnimation(ref particles);
            enemies.RemoveAt(x);
            x--;
          }
          else
            enemies[x].render(g,this.Width,this.Height,time,ref bullets,ref particles);
        }

        player.render(g,this.Width,this.Height,time,ref playerbullets,mouseheld);//render the player

        if(player.curHP<=0) {//player, is u ded yet bro?
          player.deathAnimation();
        }

        if(lasttime%7000<time)//spawning various enemies, I guess
          enemies.Add(new BasicTriangleEnemy(this.Width,this.Height));
        if(lasttime%30000<time)
          enemies.Add(new CannonWingEnemy(this.Width,this.Height));
      }
      Invalidate();
    }
    public void MouseMoveEvent(object sender,MouseEventArgs m) {
      int mouseX=m.X;
      int mouseY=m.Y;
      player.mousemove(mouseX,mouseY);
      //do whatever you so wish with this information, the mouse X and Y coordinates
    }
    public void MouseDownEvent(object sender,MouseEventArgs m) {//if the user is pressing the mouse button
      mouseheld=true;
    }
    public void MouseUpEvent(object sender,MouseEventArgs m) {//if the user has released the mouse button
      mouseheld=false;
    }
  }
}
