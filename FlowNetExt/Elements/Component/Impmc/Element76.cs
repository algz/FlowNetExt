using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element76:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("射流孔面积")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("射流孔直径")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }


        [Category("输入参数")]
        [DisplayNameAttribute("靶面高度与射流孔直径比(Z/d)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("弦向孔间距/孔径")]
        [BrowsableAttribute(true)]
        [PropertyOrder(4)]
        public override string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("径向孔间距/孔径")]
        [BrowsableAttribute(true)]
        [PropertyOrder(5)]
        public override string GEO4
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("流向元件长度")]
        [BrowsableAttribute(true)]
        [PropertyOrder(6)]
        public override string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("径向元件长度")]
        [BrowsableAttribute(true)]
        [PropertyOrder(7)]
        public override string GEO6
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("相关管元件面积")]
        [BrowsableAttribute(true)]
        [PropertyOrder(8)]
        public override string GEO7
        {
            get;
            set;
        }
    }
}
