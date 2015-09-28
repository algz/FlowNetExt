using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element16:Element13
    {
        [Category("输入参数")]
        [DisplayNameAttribute("GE02损失系数")]
        [PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("KG")]
        [Description("滑油种类编号.")]
        [PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }
    }
}
