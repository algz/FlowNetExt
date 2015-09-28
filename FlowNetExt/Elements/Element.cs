using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements
{
    [TypeConverter(typeof(PropertySorter))]
    class Element
    {

        [Category("常用")]
        [DisplayNameAttribute("类型")]
        [ReadOnlyAttribute(true)]
        public string typbeName
        {
            get;
            set;
        }


        #region 输入参数

        [Category("输入参数")]
        //[DisplayNameAttribute("进口面积")]
        //[DefaultValueAttribute("0")]
        //[Description("进口面积.")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("AA"), PropertyOrder(1)]
        public virtual string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO1"), PropertyOrder(2)]
        public virtual string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO2"), PropertyOrder(3)]
        public virtual string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GE03"), PropertyOrder(4)]
        public virtual string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO4"), PropertyOrder(5)]
        public virtual string GEO4
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO5"), PropertyOrder(6)]
        public virtual string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO6"), PropertyOrder(7)]
        public virtual string GEO6
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GE07"), PropertyOrder(8)]
        public virtual string GEO7
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GEO8"), PropertyOrder(9)]
        public virtual string GEO8
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE09"), PropertyOrder(1000)]
        public virtual string KG
        {
            get;
            set;
        }

        #region 开始/结束/连接点输入参数
        [BrowsableAttribute(false)]
        public virtual string param1
        {
            set;
            get;
        }

        [BrowsableAttribute(false)]
        public virtual string param2
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
        public virtual string TTI
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("TTE")]
        [ReadOnlyAttribute(true)]
        public virtual string TTE
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("PSI")]
        [ReadOnlyAttribute(true)]
        public virtual string PSI
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("PSE")]
        [ReadOnlyAttribute(true)]
        public virtual string PSE
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("FH1")]
        [ReadOnlyAttribute(true)]
        public virtual string FH1
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("FH2")]
        [ReadOnlyAttribute(true)]
        public virtual string FH2
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("FH3")]
        [ReadOnlyAttribute(true)]
        public virtual string FH3
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("FH4")]
        [ReadOnlyAttribute(true)]
        public virtual string FH4
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("RME")]
        [ReadOnlyAttribute(true)]
        public virtual string RME
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("RMI")]
        [ReadOnlyAttribute(true)]
        public virtual string RMI
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("DOEL")]
        [ReadOnlyAttribute(true)]
        public virtual string DOEL
        {
            get;
            set;
        }

        [Category("输出参数")]
        [DisplayNameAttribute("AKG")]
        [ReadOnlyAttribute(true)]
        public virtual string AKG
        {
            get;
            set;
        }

        #endregion


    }
}
