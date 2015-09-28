using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements
{
    [TypeConverter(typeof(PropertySorter))]
    class GlobalParam
    {
        public GlobalParam()
        {
            this.top_param1 = "1.4";
            this.top_param2 = "287.04";
            this.top_param8 = "20";
            this.top_param9 = "0";
            this.top_param10 = "0";
            this.top_param11 = "10";

            this.bottom_param1="0.1";
            this.bottom_param2 = "0.1";
            this.bottom_param3 = "0.5";
            this.bottom_param4 = "1.0E-8";
            this.bottom_param5 = "1.0E-7";
            this.bottom_param6 = "1.0E-6";
        }

        #region 顶部输入参数

        [Category("顶部输入参数")]
        [DisplayNameAttribute("绝热指数")]
        [Description("绝热指数")]
        [PropertyOrder(1)]
        public string top_param1
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("气体常数")]
        [Description("气体常数")]
        [PropertyOrder(2)]
        public string top_param2
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("进口节点数")]
        [Description("进口节点数")]
        //[ReadOnlyAttribute(true)]
        [PropertyOrder(3)]
        public string top_param3
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("出口节点数")]
        [Description("出口节点数")]
        //[ReadOnlyAttribute(true)]
        [PropertyOrder(4)]
        public string top_param4
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("分支数")]
        [Description("分支数")]
        //[ReadOnlyAttribute(true)]
        [PropertyOrder(5)]
        public string top_param5
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("元件数")]
        [Description("元件数")]
        //[ReadOnlyAttribute(true)]
        [PropertyOrder(6)]
        public string top_param6
        {
            get;
            set;
        }
        
        [Category("顶部输入参数")]
        [DisplayNameAttribute("腔数")]
        [Description("腔数")]
        //[ReadOnlyAttribute(true)]
        [PropertyOrder(7)]
        public string top_param7
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("打印控制量")]
        [Description("打印控制量")]
        [PropertyOrder(8)]
        public string top_param8
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("滑油控制量")]
        [Description("滑油控制量")]
        [PropertyOrder(9)]
        public string top_param9
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("叶片控制量")]
        [Description("叶片控制量")]
        [PropertyOrder(10)]
        public string top_param10
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("迭代次数")]
        [Description("迭代次数")]
        [PropertyOrder(11)]
        public string top_param11
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("高压转速（rpm）")]
        [Description("高压转速（rpm）")]
        [PropertyOrder(12)]
        public string top_param12
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("低压转速（rpm）")]
        [Description("低压转速（rpm）")]
        [PropertyOrder(13)]
        public string top_param13
        {
            get;
            set;
        }

        [Category("顶部输入参数")]
        [DisplayNameAttribute("W25(kg/s)")]
        [Description("W25(kg/s)")]
        [PropertyOrder(14)]
        public string top_param14
        {
            get;
            set;
        }

        #endregion

        #region 底部输入参数
        
        [Category("底部输入参数")]
        [DisplayNameAttribute("腔压迭代松弛因子1 ")]
        [Description("腔压迭代松弛因子1 ")]
        public string bottom_param1
        {
            get;
            set;
        }

        [Category("底部输入参数")]
        [DisplayNameAttribute("腔压迭代松弛因子2")]
        [Description("腔压迭代松弛因子2")]
        public string bottom_param2
        {
            get;
            set;
        }

        [Category("底部输入参数")]
        [DisplayNameAttribute("腔温迭代松弛因子")]
        [Description("腔温迭代松弛因子")]
        public string bottom_param3
        {
            get;
            set;
        }

        [Category("底部输入参数")]
        [DisplayNameAttribute("腔压迭代允许残差")]
        [Description("腔压迭代允许残差")]
        public string bottom_param4
        {
            get;
            set;
        }

        [Category("底部输入参数")]
        [DisplayNameAttribute("腔温迭代允许残差")]
        [Description("腔温迭代允许残差")]
        public string bottom_param5
        {
            get;
            set;
        }

        [Category("底部输入参数")]
        [DisplayNameAttribute("腔流量平衡允许参数")]
        [Description("腔流量平衡允许参数")]
        public string bottom_param6
        {
            get;
            set;
        }

        #endregion
    }
}
