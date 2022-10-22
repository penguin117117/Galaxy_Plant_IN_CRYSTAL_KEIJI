using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    public partial class InformationForm : Form
    {
        public InformationForm()
        {
            InitializeComponent();

            Assembly asm = Assembly.GetExecutingAssembly();
            var projectName = asm.FullName;

            Version? asmVersion = Assembly.GetExecutingAssembly().GetName().Version;
            asmVersion = asmVersion ?? throw new NullReferenceException();


            //label1.Text = asmVersion.ToString();
            label1.Text = $"バージョン{asmVersion.ToString()}\n\r{projectName}";
        }
    }
}
