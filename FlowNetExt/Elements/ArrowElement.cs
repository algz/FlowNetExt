using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FlowNetExt.Elements
{
    [TypeConverter(typeof(PropertySorter))]
    class ArrowElement:Element
    {
        [Category("计算结果")]
        [DisplayNameAttribute("流量")]
        [ReadOnlyAttribute(true)]
        public string Traffic
        {
            get;
            set;
        }


        #region 输入参数

        [Category("输入参数")]
        //[DisplayNameAttribute("进口面积")]
        //[DefaultValueAttribute("0")]
        //[Description("进口面积.")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("AA"), PropertyOrder(1)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO1"), PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO2"), PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GE03"), PropertyOrder(4)]
        public override string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO4"), PropertyOrder(5)]
        public override string GEO4
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO5"), PropertyOrder(6)]
        public override string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO6"), PropertyOrder(7)]
        public override string GEO6
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GE07"), PropertyOrder(8)]
        public override string GEO7
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO8"), PropertyOrder(9)]
        public override string GEO8
        {
            get;
            set;
        }

        [Category("输入参数")]
        [BrowsableAttribute(false)]
        [DisplayNameAttribute("GE09"), PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }

        #region 开始/结束/连接点输入参数
        [BrowsableAttribute(false)]
        public override string param1
        {
            set;
            get;
        }

        [BrowsableAttribute(false)]
        public override string param2
        {
            set;
            get;
        }
        #endregion
        #endregion

        #region 输出参数

        [Category("输出参数")]
        [DisplayNameAttribute("TTI")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string TTI
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("TTE")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string TTE
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("PSI")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string PSI
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("PSE")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string PSE
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("FH1")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string FH1
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("FH2")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string FH2
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("FH3")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string FH3
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("FH4")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string FH4
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("RME")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string RME
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("RMI")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string RMI
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("DOEL")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string DOEL
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("AKG")]
        [ReadOnlyAttribute(true)]
        [BrowsableAttribute(false)]
        public override string AKG
        {
            get;
            set;
        }

        #endregion

    }
}
