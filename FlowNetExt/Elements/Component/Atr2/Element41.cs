using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element41:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("AA接受孔面积（cm2）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE01计算半径（cm）")]
        [Description("计算半径(即喷嘴中心径向位置)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE02预旋腔出口径向位置（接受孔中心位置（cm")]
        [Description("预旋腔出口径向位置(接受孔中心位置)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE03预旋腔内径（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(4)]
        public override string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE04RPM")]
        [BrowsableAttribute(true)]
        [PropertyOrder(5)]
        public override string GEO4
        {
            get;
            set;
        }


        [Category("输入参数")]
        [DisplayNameAttribute("GE05预旋腔外径（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(6)]
        public override string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE06预旋腔轴向长度（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(7)]
        public override string GEO6
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE07修正系数")]
        [Description("计算盘面摩阻系数用的修正系数(一般取为1.0)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(8)]
        public override string GEO7
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("KG预旋喷嘴元件号")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }
    }
}
