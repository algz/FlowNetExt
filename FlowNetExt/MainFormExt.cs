using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlowNetExt.Elements.Component;
using Microsoft.VisualBasic;
using MindFusion.FlowChartX;
using FlowNetExt.Elements;
using FlowNetExt.Elements.General;
using MyControls2008;
using System.IO;

namespace FlowNetExt
{
    public partial class MainFormExt : Form
    {

        public static List<Box> ComponentElements = new List<Box>(); //普通元件:1开始
        public static List<Box> StartElements = new List<Box>(); //开始元件:1开始
        public static List<Box> EndElements = new List<Box>(); //结束元件:21开始
        public static List<Box> ConnectorElements = new List<Box>(); //连接点元件:201开始
        public static List<List<Box>> FlowBoxList = new List<List<Box>>(); //多流程图

        #region 初始化窗口

        public MainFormExt()
        {
            InitializeComponent();
            this.flowChart1.Tag = new GlobalParam();
        }

        #endregion

        /// <summary>
        /// 拖动过程:显示不同的"拖动效果"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowChart1_DragOver(object sender, DragEventArgs e)
        {
            //修改拖放界面效果:如果"拖放的数据"是树结点,则显示"复制"图标;非则"禁止"图标
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode")||
                e.Data.GetDataPresent("MyControls2008.ToolboxItem"))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void flowChart1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("MyControls2008.ToolboxItem"))
            {
                ToolboxItem toolBoxItem = (ToolboxItem)e.Data.GetData("MyControls2008.ToolboxItem");


                Point p = flowChart1.PointToClient(new Point(e.X, e.Y));
                PointF pt = flowChart1.ClientToDoc(new Point(p.X, p.Y));

                Box box = Common.CreateBox(flowChart1, toolBoxItem, pt.X, pt.Y, null);
                if (toolBoxItem.Showtext == "连接点")
                {
                    //box.Transparent = false;
                    //box.FillColor = Color.Green;
                    box.TextColor = Color.Aqua;
                    
                }
                
                //属性窗口加载Box对象
                BoxConfirmArgs args = new BoxConfirmArgs(box);
                flowChart1_BoxSelecting(null, args);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            propertyGrid1.SelectedObject = null;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (propertyGrid1.SelectedObject is GlobalParam)
            {

                //MindFusion.FlowChartX.Commands.ChangeItemCmd cmd =
                //    new MindFusion.FlowChartX.Commands.ChangeItemCmd((flowChart1, "Property change");

                flowChart1.Tag= (GlobalParam)propertyGrid1.SelectedObject;

                //cmd.Execute();
            }
            else if (propertyGrid1.SelectedObject is Element)
            {
                Box box = flowChart1.Selection.Boxes[0];
                if (box == null)
                {
                    return;
                }


                MindFusion.FlowChartX.Commands.ChangeItemCmd cmd =
                    new MindFusion.FlowChartX.Commands.ChangeItemCmd(box, "Property change");

                BoxPropertiesExt pro = (BoxPropertiesExt)box.Tag;
                pro.property = (Element)propertyGrid1.SelectedObject;

                cmd.Execute();
            }
            
        }

        private void flowChart1_BoxSelecting(object sender, BoxConfirmArgs e)
        {
            BoxPropertiesExt pro = (BoxPropertiesExt)e.Box.Tag;
            switch (pro.model)
            {
                case "0":
                    pro.property.typbeName = "进口";
                    break;
                case "-1":
                    pro.property.typbeName = "出口";
                    break;
                case "-2":
                    pro.property.typbeName ="连接点";
                    break;
                default:
                    pro.property.typbeName = pro.model;
                    break;
            }
            propertyGrid1.SelectedObject = pro.property;
        }

        private void btnZX_Click(object sender, EventArgs e)
        {
            flowChart1.ArrowStyle = EArrowStyle.asPolyline;//1 多面线(直线)
        }

        private void btnZheX_Click(object sender, EventArgs e)
        {
            flowChart1.ArrowStyle = EArrowStyle.asPerpendicular;//2 垂直线(折线)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowChart1.ArrowStyle = EArrowStyle.asBezier;//0 贝赛尔曲线(曲线)
        }

        private void newFileMenu_Click(object sender, EventArgs e)
        {
            MainFormExt.StartElements.Clear();
            MainFormExt.EndElements.Clear();
            MainFormExt.ConnectorElements.Clear();
            MainFormExt.ComponentElements.Clear();
            flowChart1.Tag = new GlobalParam();
            flowChart1.ClearAll();
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDlg = new OpenFileDialog();
            oDlg.Title = "打开文件";
            oDlg.InitialDirectory = Application.StartupPath + "\\flowfile";
            if (!Directory.Exists(oDlg.InitialDirectory))
            {
                Directory.CreateDirectory(oDlg.InitialDirectory);
            }
            oDlg.Filter = "flw files(*.flw)|*.flw";
            if (oDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    flowChart1.LoadFromFile(oDlg.FileName);
                    string file = System.IO.Path.GetFileName(oDlg.FileName).Split('.')[0];
                    string iniFile = System.IO.Path.GetDirectoryName(oDlg.FileName) + System.IO.Path.DirectorySeparatorChar + file + ".ini";
                    Common.loadBoxToINI(this.flowChart1, iniFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void saveFileMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "请输入文件名称";
            dlg.Filter = "flw files(*.flw)|*.flw";
            dlg.InitialDirectory = Application.StartupPath + "\\flowfile";
            if (!Directory.Exists(dlg.InitialDirectory))
            {
                Directory.CreateDirectory(dlg.InitialDirectory);
            }
            dlg.OverwritePrompt = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                flowChart1.SaveToFile(dlg.FileName, true);
                string file=System.IO.Path.GetFileName(dlg.FileName).Split('.')[0];
                string iniFile = System.IO.Path.GetDirectoryName(dlg.FileName) + System.IO.Path.DirectorySeparatorChar+ file + ".ini";
                Common.saveBoxToINI(this.flowChart1, iniFile);
            }
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                saveFileMenuItem_Click(null, null);
            }
            this.Close();
        }

        /// <summary>
        /// 运行按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            List<List<Box>> FlowBoxList = Common.StatisticsFlowBoxList();
            MainFormExt.FlowBoxList = FlowBoxList;
            if (FlowBoxList != null)
            {
                Common.CreateInputFile(flowChart1, FlowBoxList);

                //    this.Hide();
                Common.RunFile(Application.StartupPath + "\\FlownetB-CE.exe", Application.StartupPath);
                Common.ReadOutPutFile(Application.StartupPath + "\\OUTPUT.dat");//用input.dat做下测试
                //    this.Show();
            }

        }

        /// <summary>
        /// 箭头绘画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowChart1_ArrowCreating(object sender, AttachConfirmArgs e)
        {
            Box destBox = (Box)e.Destination;
            Box originBox=(Box)e.Origin;

            //判断连接点的输入元件类型是否相同,相同则不允许连接
            if (MainFormExt.ConnectorElements.Contains(destBox))
            {
                foreach (Arrow arrow in destBox.IncomingArrows)
                {
                    Box box = (Box)arrow.Destination;
                    if (box.Text == destBox.Text)
                    {
                        e.Confirm = false;
                        return;
                    }
                }
                
            }

            if (MainFormExt.ComponentElements.Contains(originBox)&&
                MainFormExt.ComponentElements.Contains(destBox) && 
                (originBox.OutgoingArrows.Count > 0 || destBox.IncomingArrows.Count > 0))
            {
                e.Confirm = false;
                return;
            }
            else if (MainFormExt.StartElements.Contains(originBox) &&
                //originBox.OutgoingArrows.Count<=0&&
                MainFormExt.ComponentElements.Contains(destBox))
            {
                e.Confirm = true;
            }
            else if (MainFormExt.ConnectorElements.Contains(originBox) &&
                MainFormExt.ComponentElements.Contains(destBox))
            {
                e.Confirm = true;
            }
            else if (MainFormExt.ComponentElements.Contains(originBox) &&
                       (MainFormExt.ComponentElements.Contains(destBox) ||
                           (MainFormExt.EndElements.Contains(destBox)
                //&&destBox.IncomingArrows.Count<=0
                           ) ||
                           MainFormExt.ConnectorElements.Contains(destBox)
                       )
                   )
            {
                e.Confirm = true;
            }
            else
            {
                e.Confirm = false;
                return;
            }

            BoxPropertiesExt pro = new BoxPropertiesExt();
            pro.property = (Element)new ArrowElement();
            pro.model = "-3";
            e.Arrow.Tag = pro;
            
            ArrowConfirmArgs args = new ArrowConfirmArgs(e.Arrow);
            flowChart1_ArrowSelecting(this.propertyGrid1, args);
            //this.propertyGrid1.SelectedObject = pro;
        }

        private void flowChart1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject=flowChart1.Tag;
            this._cbZoom.Focus();
        }


        private bool RefreshElement(Box box)
        {

            foreach (Arrow arrow in box.OutgoingArrows)
            {
                return RefreshElement((Box)(arrow.Destination));
            }
            if (MainFormExt.EndElements.Contains(box))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void delRedundancyElement(List<Box> boxList,List<List<Box>> arrList)
        {
            if (arrList==null)
            {
                //if (boxList.Count == 0)
                //{
                //    return;
                //}
                while (boxList.Count != 0)
                {
                    this.flowChart1.DeleteObject(boxList.Last());
                }
                //boxList.Clear();
                return;
            }

            List<Box> list = new List<Box>();
            foreach (Box box in boxList)
            {
                bool isTempBox = true;
                foreach (List<Box> temboxList in arrList)
                {
                    foreach (Box cbox in temboxList)
                    {
                        if (cbox.Text == box.Text)
                        {
                            isTempBox = false;
                            break;
                        }
                    }
                }
                if (isTempBox)
                {
                    list.Add(box);
                }
            }
            foreach (Box box in list)
            {
                boxList.Remove(box);
                this.flowChart1.DeleteObject(box);
            }
        }

        private void updateElementText(string str,List<Box> boxList)
        {
            for (int i = 0; i < boxList.Count; i++)
            {
                Box box = boxList[i];
                if (box.Text != str + (i + 1))
                {
                    box.Text = str + (i + 1);
                }
            }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("重新编号将自动删除独立结点及流程","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                List<List<Box>> arrList = Common.StatisticsFlowBranchList();
                #region 删除冗余节点
                delRedundancyElement(MainFormExt.StartElements, arrList);
                delRedundancyElement(MainFormExt.EndElements, arrList);
                delRedundancyElement(MainFormExt.ConnectorElements, arrList);
                delRedundancyElement(MainFormExt.ComponentElements, arrList);
                #endregion

                updateElementText("S", MainFormExt.StartElements);
                updateElementText("E", MainFormExt.EndElements);
                updateElementText("C", MainFormExt.ConnectorElements);
                updateElementText("", MainFormExt.ComponentElements);

            }
        }

        private void flowChart1_BoxDeleted(object sender, BoxEventArgs e)
        {
            Box box = e.Box;
            if (MainFormExt.StartElements.Contains(box))
            {
                //for (int i = MainFormExt.StartElements.IndexOf(box) + 1; i < MainFormExt.StartElements.Count; i++)
                //{
                //    MainFormExt.StartElements[i].Text ="S"+ (Convert.ToInt32(MainFormExt.StartElements[i].Text.Remove(0,1)) - 1).ToString();
                //}
                MainFormExt.StartElements.Remove(box);
            }
            else if (MainFormExt.EndElements.Contains(box))
            {
                
                //for (int i = MainFormExt.EndElements.IndexOf(box)+1; i < MainFormExt.EndElements.Count; i++)
                //{
                //    MainFormExt.EndElements[i].Text ="E"+ (Convert.ToInt32(MainFormExt.EndElements[i].Text.Remove(0, 1)) - 1).ToString();
                //}
                MainFormExt.EndElements.Remove(box);
            }
            else if(MainFormExt.ConnectorElements.Contains(box))
            {
                //for (int i = MainFormExt.ConnectorElements.IndexOf(box) + 1; i < MainFormExt.ConnectorElements.Count; i++)
                //{
                //    MainFormExt.ConnectorElements[i].Text ="C"+ (Convert.ToInt32(MainFormExt.ConnectorElements[i].Text.Remove(0, 1)) - 1).ToString();
                //}
                MainFormExt.ConnectorElements.Remove(box);
            }
            else if (MainFormExt.ComponentElements.Contains(box))
            {
                //for (int i = MainFormExt.ComponentElements.IndexOf(box) + 1; i < MainFormExt.ComponentElements.Count; i++)
                //{
                //    MainFormExt.ComponentElements[i].Text = (Convert.ToInt32(MainFormExt.ComponentElements[i].Text) - 1).ToString();
                //}
                MainFormExt.ComponentElements.Remove(box);
            }
        }

        /// <summary>
        /// 所有流程节点鼠标单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_MouseDown(object sender, MouseEventArgs e)
        {
            ToolboxItem item = (ToolboxItem)sender;
            item.DoDragDrop(item, DragDropEffects.Copy);
        }

        /// <summary>
        /// 放大缩小ComboBox控件,并关联流程图鼠标滑轮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _cbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbZoom.SelectedIndex == -1)
                return;
            //flowChart1.Size
            //flowChart1.ClientSize=new Size(flowChart1.ClientSize.Width*2,flowChart1.ClientSize.Height*2);
            //flowChart1.Size = new Size(flowChart1.Size.Width * 2, flowChart1.Size.Height * 2);
            flowChart1.ZoomFactor = Convert.ToSingle(_cbZoom.SelectedItem);
        }

        /// <summary>
        /// 键盘单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _cbZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                //del按键
                while(flowChart1.Selection.Boxes.Count!=0)
                {
                    flowChart1.DeleteObject(flowChart1.Selection.Boxes[0]);
                }
                while (flowChart1.Selection.Arrows.Count != 0)
                {
                    flowChart1.DeleteObject(flowChart1.Selection.Arrows[0]);
                }
            }
        }

        private void flowChart1_ArrowSelecting(object sender, ArrowConfirmArgs e)
        {
            BoxPropertiesExt pro = (BoxPropertiesExt)e.Arrow.Tag;
            pro.property.typbeName = "分支";// pro.model;
            propertyGrid1.SelectedObject = pro.property;
        }

        private void flowChart1_ArrowDeleted(object sender, ArrowEventArgs e)
        {
            flowChart1_Click(this.propertyGrid1, new EventArgs());
        }



    }
}
