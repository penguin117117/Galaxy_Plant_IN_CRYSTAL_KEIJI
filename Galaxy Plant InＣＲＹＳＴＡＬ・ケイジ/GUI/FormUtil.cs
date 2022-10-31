using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    internal class FormUtil
    {
        internal static void IconSet(Form form, string resIconName) 
        {
            if (Properties.Resources.ResourceManager.GetObject(resIconName) is Bitmap bmp)
            {
                form.Icon = Icon.FromHandle(bmp.GetHicon());
            }
        }
    }
}
