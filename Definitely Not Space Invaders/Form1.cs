using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Definitely_Not_Space_Invaders {
  public partial class Form1:Form {
    public drawingpanel p;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender,EventArgs e) {
      int scrWidth=800;
      int scrHeight=500;
      this.ClientSize=new Size(scrWidth,scrHeight);
      p=new drawingpanel(scrWidth,scrHeight);
      this.Controls.Add(p);
    }
  }
}
