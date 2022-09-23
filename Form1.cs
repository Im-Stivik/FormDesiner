using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDesiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ItemMennager.Item item = new ItemMennager.Items.Lable(new PropertyMennager.Propertyes.AutoSizeProperty(true),
                new PropertyMennager.Propertyes.LocationProperty(new Point(0,0)), new PropertyMennager.Propertyes.NameProperty("label1"),
                new PropertyMennager.Propertyes.SizeProperty(new Size(35,13)), new PropertyMennager.Propertyes.TabIndexProperty(0),
                new PropertyMennager.Propertyes.TextProperty("label1"));
            
            Console.WriteLine(item.PrintProperties());
        }
    }
}
