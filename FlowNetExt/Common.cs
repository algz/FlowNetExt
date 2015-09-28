using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MindFusion.FlowChartX;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using FlowNetExt.Elements.General;
using FlowNetExt.Elements.Component;
using FlowNetExt.Elements;
using MyControls2008;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FlowNetExt
{
    class Common
    {

        /// <summary>
        /// 创建流程节点
        /// </summary>
        /// <param name="flowChart1"></param>
        /// <param name="boxItem"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="imageList1"></param>
        /// <returns></returns>
        public static Box CreateBox(FlowChart flowChart1, ToolboxItem boxItem, float x, float y, ImageList imageList1)
        {
            Box box = flowChart1.CreateBox(x, y, 13, 13);//x坐标,y坐标,宽度,高度
            box.Transparent = true;
            box.MnpHandlesMask = 1 << 8; // 禁止改变大小
            //node.HyperLink = type;
            box.TextFormat.Alignment = StringAlignment.Center;
            box.TextFormat.LineAlignment = StringAlignment.Far;
            box.PicturePos = EImagePos.imgTopCenter;
            box.Picture = boxItem.Image;// imageList1.Images[boxItem.ImageIndex];

            //通过类型反射创建对象
            string typeName = "FlowNetExt.Elements."+boxItem.Parent.Tag+"." + boxItem.Tag.ToString();
            BoxPropertiesExt pro = new BoxPropertiesExt();
            pro.property = (Element)Activator.CreateInstance(Type.GetType(typeName));

            switch (boxItem.Parent.Tag.ToString())
            {
                case "Component":
                    //普通元件
                    MainFormExt.ComponentElements.Add(box);
                    if (MainFormExt.ComponentElements.Count == 1)
                    {
                        box.Text = "1";
                    }
                    else
                    {
                        box.Text = (Convert.ToInt32(MainFormExt.ComponentElements[MainFormExt.ComponentElements.Count - 2].Text) + 1).ToString();
                    }
                   
                    // 取出字符串中的数字  
                    System.Text.RegularExpressions.Match mstr = Regex.Match(boxItem.Showtext, @"(\d+)");  
                    pro.model = mstr.Groups[1].Value.ToString();    
                    //pro.model = boxItem.Showtext;//.Substring(2);
                    break;
                case "General":
                    //通用元件
                    if (boxItem.Tag.ToString() == "StartElement")
                    {
                        MainFormExt.StartElements.Add(box);
                        if (MainFormExt.StartElements.Count == 1)
                        {
                            box.Text = "S1";
                        }
                        else
                        {
                            box.Text = "S" + (Convert.ToInt32(MainFormExt.StartElements[MainFormExt.StartElements.Count - 2].Text.Substring(1)) + 1);
                        }
                        pro.model = "0";
                    }
                    else if (boxItem.Tag.ToString() == "EndElement")
                    {
                        MainFormExt.EndElements.Add(box);
                        if (MainFormExt.EndElements.Count == 1)
                        {
                            box.Text = "E21";
                        }
                        else
                        {
                            box.Text = "E" + (Convert.ToInt32(MainFormExt.EndElements[MainFormExt.EndElements.Count - 2].Text.Substring(1)) + 1);
                        }
                        pro.model = "-1";
                    }
                    else if (boxItem.Tag.ToString() == "ConnectorElement")
                    {
                        MainFormExt.ConnectorElements.Add(box);
                        if (MainFormExt.ConnectorElements.Count == 1)
                        {
                            box.Text = "C201";
                        }
                        else
                        {
                            box.Text = "C" + (Convert.ToInt32(MainFormExt.ConnectorElements[MainFormExt.ConnectorElements.Count - 2].Text.Substring(1)) + 1).ToString();
                        }
                        pro.model = "-2";
                    }
                    break;
            }
            box.Tag = pro;
            return box;
        }


        /// <summary>
        /// 生成输入文件
        /// </summary>
        /// <param name="flowChart1"></param>
        public static void CreateInputFile(FlowChart flowChart1, List<List<Box>> FlowBoxList)
        {
            //Box oBox = null;  //源Box
            //Box sBox = null;//目的Box
            //string sp = "   ";
            //string str = string.Empty;
            try
            {
                using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\input.dat",false))
                {
                    #region 全局参数1
                    sw.WriteLine(" SF-B, INTERNAL AIR SYSTEM HPT1, V1.0");
                    GlobalParam globalParam = (GlobalParam)flowChart1.Tag;
                    StringBuilder paramStr = new StringBuilder();
                    paramStr.Append("  " + (globalParam.top_param1 == "" || globalParam.top_param1 == null ? "0" : globalParam.top_param1));
                    paramStr.Append("  " + (globalParam.top_param2 == "" || globalParam.top_param2 == null ? "0" : globalParam.top_param2));
                    
                    
                    //globalParam.top_param3 = MainFormExt.StartElements.Count.ToString();
                    //globalParam.top_param4 = MainFormExt.EndElements.Count.ToString();
                    //globalParam.top_param5 = MainFormExt.FlowBoxList.Count.ToString();
                    //globalParam.top_param6 = MainFormExt.ComponentElements.Count.ToString();
                    //globalParam.top_param7 = MainFormExt.ConnectorElements.Count.ToString();
                    //起点总数
                    paramStr.Append("  " + (globalParam.top_param3 == "" || globalParam.top_param3 == null ? "0" : globalParam.top_param3));
                   //结束点总数
                    paramStr.Append("  " + (globalParam.top_param4 == "" || globalParam.top_param4 == null ? "0" : globalParam.top_param4));
                    //分支流程总数
                    paramStr.Append("  " + (globalParam.top_param5 == "" || globalParam.top_param5 == null ? "0" : globalParam.top_param5));
                    //元件总数
                    paramStr.Append("  " + (globalParam.top_param6 == "" || globalParam.top_param6 == null ? "0" : globalParam.top_param6));
                    //连接点总数
                    paramStr.Append("  " + (globalParam.top_param7 == "" || globalParam.top_param7 == null ? "0" : globalParam.top_param7));
                    
                    paramStr.Append("  " + (globalParam.top_param8 == "" || globalParam.top_param8 == null ? "0" : globalParam.top_param8));
                    paramStr.Append("  " + (globalParam.top_param9 == "" || globalParam.top_param9 == null ? "0" : globalParam.top_param9));
                    paramStr.Append("  " + (globalParam.top_param10 == "" || globalParam.top_param10 == null ? "0" : globalParam.top_param10));
                    paramStr.Append("  " + (globalParam.top_param11 == "" || globalParam.top_param11 == null ? "0" : globalParam.top_param11));
                    sw.WriteLine(paramStr);
                    paramStr = new StringBuilder();
                    paramStr.Append("  " + (globalParam.top_param12 == "" || globalParam.top_param12 == null ? "0" : globalParam.top_param12));
                    paramStr.Append("  " + (globalParam.top_param13 == "" || globalParam.top_param13 == null ? "0" : globalParam.top_param13));
                    paramStr.Append("  " + (globalParam.top_param14 == "" || globalParam.top_param14 == null ? "0" : globalParam.top_param14));
                    sw.WriteLine(paramStr);
                    #endregion

                    #region 起点节点
                    sw.WriteLine("INLET NODE NUMBER, INLET TOTAL PRESSURE AND TEMPERATURE");
                    for (int i = 0; i < MainFormExt.StartElements.Count;i++ )
                    {
                        Box box=MainFormExt.StartElements[i];
                        BoxPropertiesExt pro=(BoxPropertiesExt)box.Tag;
                        StartElement start = (StartElement)pro.property;

                        sw.WriteLine(" " + (i + 1) + "  " + (start.param1 == "" || start.param1 == null ? "0" : start.param1) + "  " + (start.param2 == "" || start.param2 == null ? "0" : start.param2));
                    }
                    #endregion

                    #region 结束节点
                    sw.WriteLine("OUTLET NODE NUMBER, STATIC PRESSURE AND TEMPERATURE");
                    for (int i = 0; i < MainFormExt.EndElements.Count;i++ )
                    {
                        Box box = MainFormExt.EndElements[i];
                        BoxPropertiesExt pro=(BoxPropertiesExt)box.Tag;
                        EndElement end = (EndElement)pro.property;
                        sw.WriteLine(" " + (21 + i) + "  " + (end.param1 == "" || end.param1 == null ? "0" : end.param1) + "  " + (end.param1 == "" || end.param1 == null ? "0" : end.param2));
                    }
                    #endregion

                    #region 元素输入数据
                    sw.WriteLine(" ELEMENTS INPUT DATA");
                    int point1 = 1;
                    int point2 = 301;
                    
                    for(int i=0,k=1;i<FlowBoxList.Count;i++){
                        if (i != 0)
                        {
                            point2 = point1 + 1;

                            Box originBox = (Box)FlowBoxList[i][0].IncomingArrows[0].Origin;
                            BoxPropertiesExt originPro = (BoxPropertiesExt)originBox.Tag;
                            switch (originPro.model)
                            {
                                case "0":
                                case "-1":
                                case "-2":
                                    point1 = Convert.ToInt32(originBox.Text.Remove(0, 1));
                                    break;
                                default:
                                    point1 = Convert.ToInt32(originBox.Text);
                                    break;
                            }
                            //point1 = Convert.ToInt32(originBox.Text);
                            
                        }                        
                        for (int j = 0; j < FlowBoxList[i].Count; j++,k++)
                        {
                            Box box = FlowBoxList[i][j];

                            BoxPropertiesExt pro = (BoxPropertiesExt)box.Tag;

                            Box inputBox = (Box)box.IncomingArrows[0].Origin;
                            Box outBox = (Box)box.OutgoingArrows[0].Destination;
                            StringBuilder str = new StringBuilder();
                            str.Append(" " + k);
                            str.Append("  " + pro.model);

                            str.Append("  " + point1);
                            if (j == FlowBoxList[i].Count - 1)
                            {
                                Box destBox = (Box)FlowBoxList[i].Last().OutgoingArrows[0].Destination;
                                BoxPropertiesExt destPro = (BoxPropertiesExt)destBox.Tag;
                                switch (destPro.model)
                                {
                                    case "0":
                                    case "-1":
                                    case "-2":
                                        point2 = Convert.ToInt32(destBox.Text.Remove(0,1));
                                        break;
                                    default:
                                        point2 = Convert.ToInt32(destBox.Text);
                                        break;
                                }
                                str.Append("  " + point2);
                            }
                            else
                            {
                                str.Append("  " + point2);
                                point1 = point2;
                                point2 = point1 + 1;
                            }

                            str.Append("  " + (pro.property.AA == "" || pro.property.AA ==null? "0" : pro.property.AA));
                            str.Append("  " + (pro.property.GEO1 == "" || pro.property.GEO1 == null? "0" : pro.property.GEO1));
                            str.Append("  " + (pro.property.GEO2==""||pro.property.GEO2==null?"0":pro.property.GEO2));
                            str.Append("  " + (pro.property.GEO3 == "" || pro.property.GEO3 ==null? "0" : pro.property.GEO3));
                            str.Append("  " + (pro.property.GEO4 == "" || pro.property.GEO4 ==null? "0" : pro.property.GEO4));
                            str.Append("  " + (pro.property.GEO5 == "" || pro.property.GEO5 == null ? "0" : pro.property.GEO5));
                            str.Append("  " + (pro.property.GEO6 == "" || pro.property.GEO6 == null ? "0" : pro.property.GEO6));
                            str.Append("  " + (pro.property.GEO7 == "" || pro.property.GEO7 == null? "0" : pro.property.GEO7));
                            str.Append("  " + (pro.property.GEO8 == "" || pro.property.GEO8 == null? "0" : pro.property.GEO8));
                            str.Append("  " + (pro.property.KG == "" || pro.property.KG == null? "0" : pro.property.KG));

                            //str.Append("  " + (pro.property.param1 == "" || pro.property.param1 == null ? "0" : pro.property.param1));
                            //str.Append("  " + (pro.property.param2 == "" || pro.property.param2 == null ? "0" : pro.property.param2));
                            sw.WriteLine(str);
                        }
                    }

                    #endregion

                    #region 分支流程
                    sw.WriteLine("BRAN 11S INPUT DATA");
                    for (int i = 0; i < FlowBoxList.Count; i++)
                    {
                        List<Box> boxList = FlowBoxList[i];
                        StringBuilder str = new StringBuilder();
                        Box startBox = (Box)boxList.First().IncomingArrows[0].Origin;
                        Box endBox = (Box)boxList.Last().OutgoingArrows[0].Destination;
                        str.Append(" " + (i + 1) + "  " + boxList.Count + "  " + startBox.Text.Remove(0,1) + "  " + endBox.Text.Remove(0,1));
                        foreach (Box box in boxList)
                        {
                            str.Append("  "+box.Text);
                        }
                        sw.WriteLine(str);
                    }
                    #endregion

                    #region 全局参数2
                    sw.WriteLine("RELAXATION FACTORS AND CONVERG8NCE TOLERANCE");
                    paramStr = new StringBuilder();
                    paramStr.Append("  " + (globalParam.top_param1 == "" || globalParam.top_param1 == null? "0" : globalParam.bottom_param1));
                    paramStr.Append("  " + (globalParam.bottom_param2 == "" || globalParam.top_param2 == null? "0" : globalParam.bottom_param2));
                    paramStr.Append("  " + (globalParam.bottom_param3 == "" || globalParam.bottom_param3 == null ? "0" : globalParam.bottom_param3));
                    paramStr.Append("  " + (globalParam.bottom_param4 == "" || globalParam.bottom_param4 == null ? "0" : globalParam.bottom_param4));
                    paramStr.Append("  " + (globalParam.bottom_param5 == "" || globalParam.bottom_param5 == null ? "0" : globalParam.bottom_param5));
                    paramStr.Append("  " + (globalParam.bottom_param6 == "" || globalParam.bottom_param6 == null ? "0" : globalParam.bottom_param6));
                    sw.WriteLine(paramStr);
                    #endregion
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //首先生成算法程序需要的输入文件，然后启动算法程序，同时监测算法程序生成的输出文件，将结果显示在界面上
            //this.Hide();//或者使用301的方式将程序显示在界面上
            //RunFile(Application.StartupPath + "\\a.exe", Application.StartupPath, true);
            //ReadOutPutFile(Application.StartupPath + "\\input.dat");//用input.dat做下测试
            //this.Show();
        }

        public static List<List<Box>> StatisticsFlowBranchList()
        {
            List<List<Box>> FlowBoxList = new List<List<Box>>(); //多流程图
            foreach (Box box in MainFormExt.StartElements)
            {
                List<Box> list = new List<Box>();
                RecusionFlowBranch(box, ref list);
                if (list != null)
                {
                    FlowBoxList.Add(list);
                }
            }
            return FlowBoxList;
        }

        private static void RecusionFlowBranch(Box box, ref List<Box> boxList)
        {
            boxList.Add(box);
            if (box.OutgoingArrows.Count==0&&!MainFormExt.EndElements.Contains(box))
            {
                boxList = null;
                return ;
            }
            foreach (Arrow arrow in box.OutgoingArrows)
            {
                RecusionFlowBranch((Box)arrow.Destination, ref boxList);
            }
        }

        /// <summary>
        /// 统计流程分支
        /// </summary>
        /// <returns></returns>
        public static List<List<Box>> StatisticsFlowBoxList()
        {
            try
            {
                List<List<Box>> FlowBoxList = new List<List<Box>>(); //多流程图
                //统计开始节点-连接节点/结束节点分支
                for (int i = 0; i < MainFormExt.StartElements.Count; i++)
                {
                    List<Box> boxList = new List<Box>();
                    Box box = (Box)MainFormExt.StartElements[i].OutgoingArrows[0].Destination;
                    while (!(((BoxPropertiesExt)box.Tag).property is ConnectorElement) && !(((BoxPropertiesExt)box.Tag).property is EndElement))
                    {
                        boxList.Add(box);
                        box = (Box)box.OutgoingArrows[0].Destination;
                    }
                    FlowBoxList.Add(boxList);
                }

                //统计连接节点-结束节点分支
                for (int i = 0; i < MainFormExt.ConnectorElements.Count; i++)
                {
                    for (int j = 0; j < MainFormExt.ConnectorElements[i].OutgoingArrows.Count; j++)
                    {
                        List<Box> boxList = new List<Box>();
                        Box box = (Box)MainFormExt.ConnectorElements[i].OutgoingArrows[j].Destination;
                        while (!(((BoxPropertiesExt)box.Tag).property is ConnectorElement) && !(((BoxPropertiesExt)box.Tag).property is EndElement))
                        {
                            boxList.Add(box);
                            box = (Box)box.OutgoingArrows[0].Destination;
                        }
                        FlowBoxList.Add(boxList);
                    }
                }
                return FlowBoxList;
            }
            catch
            {
                MessageBox.Show("流程图不完整,统计失败");
                return null;
            }
           
        }

        /// <summary>
        /// 运行文件
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="workDir"></param>
        public static void RunFile(string appName, string workDir)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = appName;
            proc.StartInfo.Arguments = "";
            proc.StartInfo.WorkingDirectory = workDir;

            try
            {
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        /// <summary>
        /// 读取输出文件
        /// </summary>
        /// <param name="strFile"></param>
        public static void ReadOutPutFile(string strFile)
        {
            if (File.Exists(strFile))
            {
                using (StreamReader sr = new StreamReader(strFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string s=sr.ReadLine();
                        if (s.Contains("ELEMENT PARAMETERS"))
                        {
                            sr.ReadLine();
                            s=sr.ReadLine();
                            foreach (Box box in MainFormExt.ComponentElements)
                            {
                                BoxPropertiesExt boxPro = (BoxPropertiesExt)box.Tag;
                                Element e=boxPro.property;
                                string[] data = s.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                e.TTI = data[4];
                                e.TTE = data[5];
                                e.PSI = data[6];
                                e.PSE = data[7];
                                e.FH1 = data[8];
                                e.FH2 = data[9];
                                e.FH3 = data[10];
                                e.FH4 = data[11];
                                e.RME = data[12];
                                e.RMI = data[13];
                                e.DOEL = data[14];
                                e.AKG = data[15];

                                s = sr.ReadLine();
                            }
                        }
                    }
                }
            }
        }

        #region 保存/加载流程图(ini文件读写)
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string mpAppName,
            string mpKeyName,
            string mpDefault,
            string mpFileName);

        /// <summary>
        /// 保存流程节点到INI文件
        /// </summary>
        /// <param name="flowChart1"></param>
        /// <param name="filePath"></param>
        public static void saveBoxToINI(FlowChart flowChart1,string filePath)
        {
            StreamWriter sw=File.CreateText(filePath);
            sw.Close();

            #region 保存全局参数
            GlobalParam globalParam = (GlobalParam)flowChart1.Tag;
            WritePrivateProfileString("GlobalParam", "top_param1", globalParam.top_param1, filePath);
            WritePrivateProfileString("GlobalParam", "top_param2", globalParam.top_param2, filePath);
            WritePrivateProfileString("GlobalParam", "top_param3", globalParam.top_param3, filePath);
            WritePrivateProfileString("GlobalParam", "top_param4", globalParam.top_param4, filePath);
            WritePrivateProfileString("GlobalParam", "top_param5", globalParam.top_param5, filePath);
            WritePrivateProfileString("GlobalParam", "top_param6", globalParam.top_param6, filePath);
            WritePrivateProfileString("GlobalParam", "top_param7", globalParam.top_param7, filePath);
            WritePrivateProfileString("GlobalParam", "top_param8", globalParam.top_param8, filePath);
            WritePrivateProfileString("GlobalParam", "top_param9", globalParam.top_param9, filePath);
            WritePrivateProfileString("GlobalParam", "top_param10", globalParam.top_param10, filePath);
            WritePrivateProfileString("GlobalParam", "top_param11", globalParam.top_param11, filePath);
            WritePrivateProfileString("GlobalParam", "top_param12", globalParam.top_param12, filePath);
            WritePrivateProfileString("GlobalParam", "top_param13", globalParam.top_param13, filePath);
            WritePrivateProfileString("GlobalParam", "top_param14", globalParam.top_param14, filePath);
            WritePrivateProfileString("GlobalParam", "bottom_param1", globalParam.bottom_param1, filePath);
            WritePrivateProfileString("GlobalParam", "bottom_param2", globalParam.bottom_param2, filePath);
            WritePrivateProfileString("GlobalParam", "bottom_param3", globalParam.bottom_param3, filePath);
            WritePrivateProfileString("GlobalParam", "bottom_param4", globalParam.bottom_param4, filePath);
            WritePrivateProfileString("GlobalParam", "bottom_param5", globalParam.bottom_param5, filePath);
            WritePrivateProfileString("GlobalParam", "bottom_param6", globalParam.bottom_param6, filePath);
            #endregion

            //保存所有流程节点相关数据
            foreach (Box box in flowChart1.Boxes)
            {
                BoxPropertiesExt pro = (BoxPropertiesExt)box.Tag;
                Element e = pro.property;
                WritePrivateProfileString(box.Text, "AA", e.AA, filePath);
                WritePrivateProfileString(box.Text, "GEO1", e.GEO1, filePath);
                WritePrivateProfileString(box.Text, "GEO2", e.GEO2, filePath);
                WritePrivateProfileString(box.Text, "GEO3", e.GEO3, filePath);
                WritePrivateProfileString(box.Text, "GEO4", e.GEO4, filePath);
                WritePrivateProfileString(box.Text, "GEO5", e.GEO5, filePath);
                WritePrivateProfileString(box.Text, "GEO6", e.GEO6, filePath);
                WritePrivateProfileString(box.Text, "GEO7", e.GEO7, filePath);
                WritePrivateProfileString(box.Text, "GEO8", e.GEO8, filePath);
                WritePrivateProfileString(box.Text, "KG", e.KG, filePath);
                WritePrivateProfileString(box.Text, "param1", e.param1, filePath);
                WritePrivateProfileString(box.Text, "param2", e.param2, filePath);


                WritePrivateProfileString(box.Text, "TTI", e.TTI, filePath);
                WritePrivateProfileString(box.Text, "TTE", e.TTE, filePath);
                WritePrivateProfileString(box.Text, "PSI", e.PSI, filePath);
                WritePrivateProfileString(box.Text, "PSE", e.PSE, filePath);
                WritePrivateProfileString(box.Text, "FH1", e.FH1, filePath);
                WritePrivateProfileString(box.Text, "FH2", e.FH2, filePath);
                WritePrivateProfileString(box.Text, "FH3", e.FH3, filePath);
                WritePrivateProfileString(box.Text, "FH4", e.FH4, filePath);
                WritePrivateProfileString(box.Text, "RME", e.RME, filePath);
                WritePrivateProfileString(box.Text, "RMI", e.RMI, filePath);
                WritePrivateProfileString(box.Text, "DOEL", e.DOEL, filePath);
                WritePrivateProfileString(box.Text, "AKG", e.AKG, filePath);

                WritePrivateProfileString(box.Text, "model", pro.model, filePath);
            }
        }

        /// <summary>
        /// 从文件中加载流程节点
        /// </summary>
        /// <param name="flowChart1"></param>
        /// <param name="filePath"></param>
        public static void loadBoxToINI(FlowChart flowChart1, string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("流程参数文件没找到.");
                return;
            }
            StringBuilder s = new StringBuilder(1024);

            #region 加载全局参数
            GlobalParam globalParam = new GlobalParam();
            GetPrivateProfileString("GlobalParam", "top_param1", "", s, 1024, filePath);
            globalParam.top_param1 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param2", "", s, 1024, filePath);
            globalParam.top_param2 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param3", "", s, 1024, filePath);
            globalParam.top_param3 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param4", "", s, 1024, filePath);
            globalParam.top_param4 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param5", "", s, 1024, filePath);
            globalParam.top_param5 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param6", "", s, 1024, filePath);
            globalParam.top_param6 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param7", "", s, 1024, filePath);
            globalParam.top_param7 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param8", "", s, 1024, filePath);
            globalParam.top_param8 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param9", "", s, 1024, filePath);
            globalParam.top_param9 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param10", "", s, 1024, filePath);
            globalParam.top_param10 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param11", "", s, 1024, filePath);
            globalParam.top_param11 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param12", "", s, 1024, filePath);
            globalParam.top_param12 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param13", "", s, 1024, filePath);
            globalParam.top_param13 = s.ToString();
            GetPrivateProfileString("GlobalParam", "top_param14", "", s, 1024, filePath);
            globalParam.top_param14 = s.ToString();

            GetPrivateProfileString("GlobalParam", "bottom_param1", "", s, 1024, filePath);
            globalParam.bottom_param1 = s.ToString();
            GetPrivateProfileString("GlobalParam", "bottom_param2", "", s, 1024, filePath);
            globalParam.bottom_param2 = s.ToString();
            GetPrivateProfileString("GlobalParam", "bottom_param3", "", s, 1024, filePath);
            globalParam.bottom_param3 = s.ToString();
            GetPrivateProfileString("GlobalParam", "bottom_param4", "", s, 1024, filePath);
            globalParam.bottom_param4 = s.ToString();
            GetPrivateProfileString("GlobalParam", "bottom_param5", "", s, 1024, filePath);
            globalParam.bottom_param5 = s.ToString();
            GetPrivateProfileString("GlobalParam", "bottom_param6", "", s, 1024, filePath);
            globalParam.bottom_param6 = s.ToString();

            flowChart1.Tag = globalParam;
            #endregion


            //加载所有流程节点的相关数据
            foreach (Box box in flowChart1.Boxes)
            {
                BoxPropertiesExt pro = new BoxPropertiesExt();
                s = new StringBuilder(1024);

                GetPrivateProfileString(box.Text, "model", "", s, 1024, filePath);
                pro.model = s.ToString();
                string typeName = "FlowNetExt.Elements.";
                switch (pro.model)
                {
                    case "0":
                        typeName += "General.StartElement";
                        MainFormExt.StartElements.Add(box);
                        break;
                    case "-1":
                        typeName += "General.EndElement";
                        MainFormExt.EndElements.Add(box);
                        break;
                    case "-2":
                        typeName += "General.ConnectorElement";
                        MainFormExt.ConnectorElements.Add(box);
                        break;
                    default:
                        typeName += "Component.Element" + pro.model;
                        MainFormExt.ComponentElements.Add(box);
                        break;
                }
                Element e = (Element)Activator.CreateInstance(Type.GetType(typeName));
                
                
                GetPrivateProfileString(box.Text, "AA", "",s,1024, filePath);
                e.AA = s.ToString();

                GetPrivateProfileString(box.Text, "GEO1","",s, 1024, filePath);
                e.GEO1 = s.ToString();

                GetPrivateProfileString(box.Text, "GEO2", "",s,1024, filePath);
                e.GEO2 = s.ToString();

                GetPrivateProfileString(box.Text, "GEO3","",s,1024, filePath);
                e.GEO3 = s.ToString();
                
                GetPrivateProfileString(box.Text, "GEO4", "",s,1024, filePath);
                e.GEO4 = s.ToString();

                GetPrivateProfileString(box.Text, "GEO5", "", s, 1024, filePath);
                e.GEO5 = s.ToString();

                GetPrivateProfileString(box.Text, "GEO6", "", s, 1024, filePath);
                e.GEO6 = s.ToString();

                GetPrivateProfileString(box.Text, "GEO7", "", s, 1024, filePath);
                e.GEO7 = s.ToString();

                GetPrivateProfileString(box.Text, "GEO8", "", s, 1024, filePath);
                e.GEO8 = s.ToString();

                GetPrivateProfileString(box.Text, "KG", "", s, 1024, filePath);
                e.KG = s.ToString();

                GetPrivateProfileString(box.Text, "param1", "", s, 1024, filePath);
                e.param1 = s.ToString();

                GetPrivateProfileString(box.Text, "param2", "", s, 1024, filePath);
                e.param2 = s.ToString();

                GetPrivateProfileString(box.Text, "TTI", "", s, 1024, filePath);
                e.TTI = s.ToString();

                GetPrivateProfileString(box.Text, "TTE", "", s, 1024, filePath);
                e.TTE = s.ToString();

                GetPrivateProfileString(box.Text, "PSI", "", s, 1024, filePath);
                e.PSI = s.ToString();

                GetPrivateProfileString(box.Text, "PSE", "", s, 1024, filePath);
                e.PSE = s.ToString();

                GetPrivateProfileString(box.Text, "FH1", "", s, 1024, filePath);
                e.FH1 = s.ToString();

                GetPrivateProfileString(box.Text, "FH2", "", s, 10242, filePath);
                e.FH2 = s.ToString();

                GetPrivateProfileString(box.Text, "FH3", "", s, 1024, filePath);
                e.FH3 = s.ToString();

                GetPrivateProfileString(box.Text, "FH4", "", s, 1024, filePath);
                e.FH4 = s.ToString();

                GetPrivateProfileString(box.Text, "RME", "", s, 1024, filePath);
                e.RME = s.ToString();

                GetPrivateProfileString(box.Text, "RMI", "", s, 1024, filePath);
                e.RMI = s.ToString();

                GetPrivateProfileString(box.Text, "DOEL", "", s, 1024, filePath);
                e.DOEL = s.ToString();

                GetPrivateProfileString(box.Text, "AKG", "", s, 1024, filePath);
                e.AKG = s.ToString();

                pro.property = e;
                box.Tag = pro;
            }
        }
        #endregion
    }

    /// <summary>
    /// 扩展流程节点Box属性
    /// </summary>
    class BoxPropertiesExt
    {
        /// <summary>
        /// 结点类型
        /// </summary>
        public string model
        {
            get;
            set;
        }

        /// <summary>
        /// 结点属性
        /// </summary>
        public Element property
        {
            get;
            set;
        }
    }
}
