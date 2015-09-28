using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element53:Element52
    {
        [Category("输入参数")]
        [DisplayNameAttribute("GE08左侧壁温（K)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(9)]
        public override string GEO8
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE09右侧壁温（K)"), PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }
    }
}
