namespace InventoryTrackingAutomation
{
    partial class Form_Inventory_Tracking
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label3 = new Label();
            comboBox1 = new ComboBox();
            TB_Password = new TextBox();
            TB_UserID = new TextBox();
            label2 = new Label();
            label1 = new Label();
            BTN_Login_and_Run = new Button();
            tabPage2 = new TabPage();
            LBL_Excel_Writing = new Label();
            LBL_Convert_List_to_DT = new Label();
            LBL_Reading_Data_From_Page = new Label();
            LBL_List_Orders = new Label();
            PB_Excel_Writing = new ProgressBar();
            PB_Convert_List_to_DT = new ProgressBar();
            PB_Reading_Data_From_Page = new ProgressBar();
            PB_Orders_List = new ProgressBar();
            tabPage3 = new TabPage();
            label4 = new Label();
            TB_Save_Report_Folder = new TextBox();
            LBL_Order_Details_Load_Time = new Label();
            TBar_Main_Page_Load_Time = new TrackBar();
            LBL_Main_Page_Load_Time = new Label();
            LBL_Order_Detail_Load_Time = new Label();
            TBar_Order_Detail_Load_Time = new TrackBar();
            WV_DO = new Microsoft.Web.WebView2.WinForms.WebView2();
            CB_Days = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TBar_Main_Page_Load_Time).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TBar_Order_Detail_Load_Time).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WV_DO).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(WV_DO);
            splitContainer1.Size = new Size(1464, 896);
            splitContainer1.SplitterDistance = 199;
            splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1464, 199);
            tabControl1.TabIndex = 0;
            tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(TB_Password);
            tabPage1.Controls.Add(TB_UserID);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(BTN_Login_and_Run);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1456, 171);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Run Bot";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(243, 14);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 6;
            label3.Text = "Market";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(350, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(148, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // TB_Password
            // 
            TB_Password.Location = new Point(350, 86);
            TB_Password.Name = "TB_Password";
            TB_Password.PasswordChar = '*';
            TB_Password.Size = new Size(148, 23);
            TB_Password.TabIndex = 4;
            // 
            // TB_UserID
            // 
            TB_UserID.Location = new Point(350, 47);
            TB_UserID.Name = "TB_UserID";
            TB_UserID.Size = new Size(148, 23);
            TB_UserID.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(243, 94);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(243, 55);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "User ID";
            // 
            // BTN_Login_and_Run
            // 
            BTN_Login_and_Run.Location = new Point(392, 126);
            BTN_Login_and_Run.Name = "BTN_Login_and_Run";
            BTN_Login_and_Run.Size = new Size(106, 23);
            BTN_Login_and_Run.TabIndex = 0;
            BTN_Login_and_Run.Text = "Login and Run";
            BTN_Login_and_Run.UseVisualStyleBackColor = true;
            BTN_Login_and_Run.Click += BTN_Login_and_Run_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(LBL_Excel_Writing);
            tabPage2.Controls.Add(LBL_Convert_List_to_DT);
            tabPage2.Controls.Add(LBL_Reading_Data_From_Page);
            tabPage2.Controls.Add(LBL_List_Orders);
            tabPage2.Controls.Add(PB_Excel_Writing);
            tabPage2.Controls.Add(PB_Convert_List_to_DT);
            tabPage2.Controls.Add(PB_Reading_Data_From_Page);
            tabPage2.Controls.Add(PB_Orders_List);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1456, 171);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Show Progress";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // LBL_Excel_Writing
            // 
            LBL_Excel_Writing.AutoSize = true;
            LBL_Excel_Writing.Location = new Point(334, 135);
            LBL_Excel_Writing.Name = "LBL_Excel_Writing";
            LBL_Excel_Writing.Size = new Size(38, 15);
            LBL_Excel_Writing.TabIndex = 7;
            LBL_Excel_Writing.Text = "label5";
            // 
            // LBL_Convert_List_to_DT
            // 
            LBL_Convert_List_to_DT.AutoSize = true;
            LBL_Convert_List_to_DT.Location = new Point(334, 100);
            LBL_Convert_List_to_DT.Name = "LBL_Convert_List_to_DT";
            LBL_Convert_List_to_DT.Size = new Size(38, 15);
            LBL_Convert_List_to_DT.TabIndex = 6;
            LBL_Convert_List_to_DT.Text = "label4";
            // 
            // LBL_Reading_Data_From_Page
            // 
            LBL_Reading_Data_From_Page.AutoSize = true;
            LBL_Reading_Data_From_Page.Location = new Point(334, 64);
            LBL_Reading_Data_From_Page.Name = "LBL_Reading_Data_From_Page";
            LBL_Reading_Data_From_Page.Size = new Size(38, 15);
            LBL_Reading_Data_From_Page.TabIndex = 5;
            LBL_Reading_Data_From_Page.Text = "label3";
            // 
            // LBL_List_Orders
            // 
            LBL_List_Orders.AutoSize = true;
            LBL_List_Orders.Location = new Point(334, 28);
            LBL_List_Orders.Name = "LBL_List_Orders";
            LBL_List_Orders.Size = new Size(17, 15);
            LBL_List_Orders.TabIndex = 4;
            LBL_List_Orders.Text = "xx";
            // 
            // PB_Excel_Writing
            // 
            PB_Excel_Writing.Location = new Point(322, 135);
            PB_Excel_Writing.Name = "PB_Excel_Writing";
            PB_Excel_Writing.Size = new Size(418, 19);
            PB_Excel_Writing.TabIndex = 3;
            // 
            // PB_Convert_List_to_DT
            // 
            PB_Convert_List_to_DT.Location = new Point(322, 100);
            PB_Convert_List_to_DT.Name = "PB_Convert_List_to_DT";
            PB_Convert_List_to_DT.Size = new Size(418, 19);
            PB_Convert_List_to_DT.TabIndex = 2;
            // 
            // PB_Reading_Data_From_Page
            // 
            PB_Reading_Data_From_Page.Location = new Point(322, 64);
            PB_Reading_Data_From_Page.Name = "PB_Reading_Data_From_Page";
            PB_Reading_Data_From_Page.Size = new Size(418, 19);
            PB_Reading_Data_From_Page.TabIndex = 1;
            // 
            // PB_Orders_List
            // 
            PB_Orders_List.Location = new Point(322, 28);
            PB_Orders_List.Name = "PB_Orders_List";
            PB_Orders_List.Size = new Size(418, 19);
            PB_Orders_List.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(CB_Days);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(TB_Save_Report_Folder);
            tabPage3.Controls.Add(LBL_Order_Details_Load_Time);
            tabPage3.Controls.Add(TBar_Main_Page_Load_Time);
            tabPage3.Controls.Add(LBL_Main_Page_Load_Time);
            tabPage3.Controls.Add(LBL_Order_Detail_Load_Time);
            tabPage3.Controls.Add(TBar_Order_Detail_Load_Time);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1456, 171);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Configurations";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(883, 14);
            label4.Name = "label4";
            label4.Size = new Size(141, 15);
            label4.TabIndex = 7;
            label4.Text = "Save Report to this Folder";
            // 
            // TB_Save_Report_Folder
            // 
            TB_Save_Report_Folder.Location = new Point(910, 32);
            TB_Save_Report_Folder.Name = "TB_Save_Report_Folder";
            TB_Save_Report_Folder.Size = new Size(216, 23);
            TB_Save_Report_Folder.TabIndex = 6;
            TB_Save_Report_Folder.TextChanged += textBox1_TextChanged;
            TB_Save_Report_Folder.DoubleClick += TB_Save_Report_Folder_DoubleClick;
            // 
            // LBL_Order_Details_Load_Time
            // 
            LBL_Order_Details_Load_Time.AutoSize = true;
            LBL_Order_Details_Load_Time.Location = new Point(334, 90);
            LBL_Order_Details_Load_Time.Name = "LBL_Order_Details_Load_Time";
            LBL_Order_Details_Load_Time.Size = new Size(189, 15);
            LBL_Order_Details_Load_Time.TabIndex = 5;
            LBL_Order_Details_Load_Time.Text = "Wait Seconds to load Order Details";
            // 
            // TBar_Main_Page_Load_Time
            // 
            TBar_Main_Page_Load_Time.Cursor = Cursors.Hand;
            TBar_Main_Page_Load_Time.LargeChange = 1;
            TBar_Main_Page_Load_Time.Location = new Point(109, 32);
            TBar_Main_Page_Load_Time.Name = "TBar_Main_Page_Load_Time";
            TBar_Main_Page_Load_Time.Size = new Size(647, 45);
            TBar_Main_Page_Load_Time.TabIndex = 3;
            TBar_Main_Page_Load_Time.TabStop = false;
            TBar_Main_Page_Load_Time.Value = 5;
            TBar_Main_Page_Load_Time.Scroll += TBar_Main_Page_Load_Time_Scroll;
            // 
            // LBL_Main_Page_Load_Time
            // 
            LBL_Main_Page_Load_Time.AutoSize = true;
            LBL_Main_Page_Load_Time.Location = new Point(334, 8);
            LBL_Main_Page_Load_Time.Name = "LBL_Main_Page_Load_Time";
            LBL_Main_Page_Load_Time.Size = new Size(177, 15);
            LBL_Main_Page_Load_Time.TabIndex = 2;
            LBL_Main_Page_Load_Time.Text = "Wait Seconds to load main page";
            // 
            // LBL_Order_Detail_Load_Time
            // 
            LBL_Order_Detail_Load_Time.Location = new Point(0, 0);
            LBL_Order_Detail_Load_Time.Name = "LBL_Order_Detail_Load_Time";
            LBL_Order_Detail_Load_Time.Size = new Size(100, 23);
            LBL_Order_Detail_Load_Time.TabIndex = 4;
            // 
            // TBar_Order_Detail_Load_Time
            // 
            TBar_Order_Detail_Load_Time.Cursor = Cursors.Hand;
            TBar_Order_Detail_Load_Time.LargeChange = 1;
            TBar_Order_Detail_Load_Time.Location = new Point(109, 108);
            TBar_Order_Detail_Load_Time.Name = "TBar_Order_Detail_Load_Time";
            TBar_Order_Detail_Load_Time.Size = new Size(647, 45);
            TBar_Order_Detail_Load_Time.TabIndex = 0;
            TBar_Order_Detail_Load_Time.TabStop = false;
            TBar_Order_Detail_Load_Time.Value = 2;
            TBar_Order_Detail_Load_Time.Scroll += TBar_Order_Detail_Load_Time_Scroll;
            // 
            // WV_DO
            // 
            WV_DO.AllowExternalDrop = true;
            WV_DO.CreationProperties = null;
            WV_DO.DefaultBackgroundColor = Color.White;
            WV_DO.Dock = DockStyle.Fill;
            WV_DO.Location = new Point(0, 0);
            WV_DO.Name = "WV_DO";
            WV_DO.Size = new Size(1464, 693);
            WV_DO.TabIndex = 0;
            WV_DO.ZoomFactor = 1D;
            // 
            // CB_Days
            // 
            CB_Days.FormattingEnabled = true;
            CB_Days.Location = new Point(959, 72);
            CB_Days.Name = "CB_Days";
            CB_Days.Size = new Size(167, 23);
            CB_Days.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(883, 75);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 9;
            label6.Text = "Run for Last";
            // 
            // Form_Inventory_Tracking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1464, 896);
            Controls.Add(splitContainer1);
            Name = "Form_Inventory_Tracking";
            Text = "Inventory Tracking";
            Load += Form_Inventory_Tracking_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TBar_Main_Page_Load_Time).EndInit();
            ((System.ComponentModel.ISupportInitialize)TBar_Order_Detail_Load_Time).EndInit();
            ((System.ComponentModel.ISupportInitialize)WV_DO).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Microsoft.Web.WebView2.WinForms.WebView2 WV_DO;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label2;
        private Label label1;
        private Button BTN_Login_and_Run;
        private TabPage tabPage3;
        private TextBox TB_Password;
        private TextBox TB_UserID;
        private ProgressBar PB_Excel_Writing;
        private ProgressBar PB_Convert_List_to_DT;
        private ProgressBar PB_Reading_Data_From_Page;
        private ProgressBar PB_Orders_List;
        private Label LBL_List_Orders;
        private Label LBL_Excel_Writing;
        private Label LBL_Convert_List_to_DT;
        private Label LBL_Reading_Data_From_Page;
        private Label label3;
        private ComboBox comboBox1;
        private TrackBar TBar_Order_Detail_Load_Time;
        private Label LBL_Order_Detail_Load_Time;
        private Label LBL_Main_Page_Load_Time;
        private TrackBar TBar_Main_Page_Load_Time;
        private Label label5;
        private Label LBL_Order_Details_Load_Time;
        private TextBox TB_Save_Report_Folder;
        private Label label4;
        private Label label6;
        private ComboBox CB_Days;
        //private Label LBL_Order_Detail_Load_Time;
    }
}
