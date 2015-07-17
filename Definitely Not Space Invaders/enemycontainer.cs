using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_Not_Space_Invaders {
  public abstract class enemycontainer {
    /*
     * This is an abstract class. That means when you want to create a new enemy, do it like so:
     * public class newenemy:enemycontainer{
     * }
     * That way, it'll inherit from this, and the basic enemy logic will be in place.
     * If a method is marked "abstract," you *must* overwrite it with a new definition. Looking here
     * just tells you what is needed.
     * 
     * The render function should be the function that actually draws the enemy. It'll handle
     * creating the polygons and filling them to screen. That's its job.
     * 
     * The AI function should be called at the very top of the render function. Put here how the enemy acts-
     * any change in any of the variables contained in this class, and any shots being fired. Whatever brain the
     * enemy has goes in this.
     * 
     * Remember to create your own constructor for the class.
     * 
     * Any extra variables you need, add them. Just be aware that to initialize the enemy class,
     * the only thing called will be the constructor once, and the only drawing function called is the render
     * function. Furthermore, the main function will contain checks on enemy HP and will handle removing them
     * there - don't worry about it here.
     */
    public List<List<PointF> > verts;
    public List<List<PointF> > origVerts;
    public List<Color> colors;
    public double x,y,ang;//x and y of the enemy, angle the enemy's looking
    //On the angle, let's agree to use Degrees as a standard. 0 is right, 90 is up, and so on.
    public int curHP,maxHP;
    public static Random r=new Random();
    public void render(Graphics g,int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul,ref List<particle> par) {
      //calls AI, then draws enemy
      ai(scrWidth,scrHeight,msPassed,ref bul,ref par);
      verts=new List<List<PointF> >();
      SolidBrush b=new SolidBrush(Color.FromArgb(255,255,255));
      for(int t=0;t<origVerts.Count;t++) {
        verts.Add(new List<PointF>());
        for(int z=0;z<origVerts[t].Count;z++) {
          verts[t].Add(new PointF(
                            (float)(origVerts[t][z].X*Math.Cos(ang*Math.PI/180)-origVerts[t][z].Y*Math.Sin(ang*Math.PI/180)+x),
                            (float)(origVerts[t][z].X*Math.Sin(ang*Math.PI/180)+origVerts[t][z].Y*Math.Cos(ang*Math.PI/180)+y)));
        }
        b.Color=colors[t];
        g.FillPolygon(b,verts[t].ToArray());
      }
    }
    public abstract void deathAnimation(ref List<particle> par);//Gets called when curHP<=0. Just add particles or whatever, and go
    public abstract void ai(int scrWidth,int scrHeight,long msPassed,ref List<bullet> bul,ref List<particle> par);//the brains of the operation
    public enemycontainer() {//Make sure in your constructors to pass in screen size
      //curHP=maxHP;
      //^
      //Whenever initializing, unless your AI has something different (like charging), do this at the end
    }
    public abstract void hit(double hitx,double hity,int num,ref List<particle> par);//Run when something hits the enemy
  }
}
