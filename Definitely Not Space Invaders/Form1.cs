﻿using System;
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
      this.ClientSize=new Size(500,500);
      p=new drawingpanel(this.Width,this.Height);
      this.Controls.Add(p);
    }
  }
}