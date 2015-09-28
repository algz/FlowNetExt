using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FlowNetExt.Elements.Component;

namespace FlowNetExt.Elements.Component
{
    class Element10:Element1
    {
        [Category("输入参数")]
        [DisplayNameAttribute("KG")]
        [Description("滑油种类编号.")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }

    }
}
