using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Microsoft.Web.WebView2.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Data;
using MerchantFeeAutomation;
using System.ComponentModel.Design;
using System.Globalization;

namespace InventoryTrackingAutomation
{
    public partial class Form_Inventory_Tracking : Form
    {
        CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions("--disable-web-security");
        CoreWebView2Environment environment;
        List<Tuple<string, string, string>> tupleMarket = new List<Tuple<string, string, string>>();
        List<Tuple<string, string, string>> tupleDeviceQty = new List<Tuple<string, string, string>>();
        List<Tuple<string, string, string>> tupleStoreName = new List<Tuple<string, string, string>>();
        string Market = "";
        string SaveReportFolder = @"C:/";
        int Main_Page_Load_Time = 16;
        int Orders_Detail_Load_Time = 10;
        public Form_Inventory_Tracking()
        {
            InitializeComponent();
            TB_Save_Report_Folder.Text = SaveReportFolder;
            TBar_Main_Page_Load_Time.Value = 8;
            TBar_Order_Detail_Load_Time.Value = 5;
            LBL_Order_Details_Load_Time.Text = "Wait " + Orders_Detail_Load_Time + " Seconds to load order details";
            LBL_Main_Page_Load_Time.Text = "Wait " + Main_Page_Load_Time + " Seconds to load main page";

            ExcelOperations readMarketDate = new ExcelOperations();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\Conf.xlsx");
            tupleMarket = readMarketDate.ExcelToTupleMarket(filePath, "Credentials");
            tupleDeviceQty = readMarketDate.ExcelToTupleQty(filePath, "Devices");
            tupleStoreName = readMarketDate.ExcelToTupleStoreName(filePath, "Market");

            foreach (Tuple<string, string, string> tuple in tupleMarket)
            {
                comboBox1.Items.Add(tuple.Item1);
            }

            for(int i =1;i<=30; i++)
            {
                if (i == 1)
                {
                    CB_Days.Items.Add(i + " Day");
                    CB_Days.SelectedItem = i + " Day";
                }
                else
                    CB_Days.Items.Add(i + " Days");
            }
            LBL_List_Orders.Text = "";
            LBL_Convert_List_to_DT.Text = "";
            LBL_Excel_Writing.Text = "";
            LBL_Reading_Data_From_Page.Text = "";

        }

        private async void Form_Inventory_Tracking_Load(object sender, EventArgs e)
        {
            options.EnableTrackingPrevention = false;
            environment = await CoreWebView2Environment.CreateAsync(null, null, options);
            await WV_DO.EnsureCoreWebView2Async(environment);
            WV_DO.CoreWebView2.CookieManager.DeleteAllCookies();
            await WV_DO.CoreWebView2.Profile.ClearBrowsingDataAsync();

        }
        private async Task LoadTMobileWebsite()
        {
            WV_DO.CoreWebView2.Navigate("https://www.t-mobiledealerordering.com/");
            await Task.Delay(Main_Page_Load_Time * 1000);
            await WV_DO.ExecuteScriptAsync($"document.getElementById('userid').value = '{TB_UserID.Text}';");
            await WV_DO.ExecuteScriptAsync($"document.getElementById('password').value = '{TB_Password.Text}';");
            await WV_DO.ExecuteScriptAsync($"var checkbox = document.getElementsByName('AgreeTerms');");
            await WV_DO.ExecuteScriptAsync($"checkbox[0].checked = true;");
            await Task.Delay(2000);
            await WV_DO.ExecuteScriptAsync($"var BTNLogin = document.getElementsByName('login');");
            await WV_DO.ExecuteScriptAsync($"BTNLogin[0].click()");

            await Task.Delay(40000 + Main_Page_Load_Time * 1000);


            await WV_DO.ExecuteScriptAsync(@"console.log(window.frames[0].frames[2].document);");
            await WV_DO.ExecuteScriptAsync(@"let ddl1 = window.frames[0].frames[2].document.getElementsByName('rc_status_head1')[0].value = 'EALL';");
            await WV_DO.ExecuteScriptAsync(@"console.log(ddl1.length);");
            await WV_DO.ExecuteScriptAsync(@"window.frames[0].frames[2].document.getElementsByName('rc_dateattributes_select')[0].value = 'last_month';");
            await WV_DO.ExecuteScriptAsync(@"window.frames[0].frames[2].document.getElementsByName('rc_object_id')[0].value = 'last_month';");
        }
        private async Task InitWebView_InventoryTracking()
        {
            await LoadTMobileWebsite();



            await WV_DO.ExecuteScriptAsync(@"var tablerows = window.frames[0].frames[4].frames[1].document.getElementsByTagName('table')[0].rows");
            await WV_DO.ExecuteScriptAsync(@"console.log(window.frames[0].frames[2].document);");
           
            int lengthOfTable = Int32.Parse(await WV_DO.ExecuteScriptAsync(@"tablerows.length;"));
            string script = @"
                let dynamicArray = [];
                for (let i = 0; i < tablerows.length; i++) 
                {
                    dynamicArray[i] = [];
                    let row = tablerows[i];
                    if(i == 3)
                    {
                        row.click();
                    }
                    for (let j = 0; j < row.cells.length; j++) 
                    {
                            let cell = row.cells[j];
                            dynamicArray[i][j] = cell.textContent;
                            console.log(dynamicArray[i][j]);
                        if( j == (row.cells.length - 1)) 
                        {
                          const link = row.querySelector(""a"");

                          if (link) 
                            {
                                dynamicArray[i][j+1] = link.href;
                                // Log the href value
                                console.log(dynamicArray[i][j+1]);
                            }
                        }
                    }
                }";

            await WV_DO.ExecuteScriptAsync(script);

            List<OrderHistory> listOrders = new List<OrderHistory>();
            for (int i = 0; i < lengthOfTable; i++)
            {
                if (i != 0)
                {
                    OrderHistory orderHistory = new OrderHistory();
                    orderHistory.orderNo = (await WV_DO.ExecuteScriptAsync($"dynamicArray[{i}][0]")).Replace("\\n", "").Replace("\\t", "").Replace("\"", "").Trim();
                    orderHistory.orderDate = (await WV_DO.ExecuteScriptAsync($"dynamicArray[{i}][1]")).Replace("\\n", "").Replace("\\t", "").Replace("\"", "").Trim();
                    orderHistory.orderStatus = (await WV_DO.ExecuteScriptAsync($"dynamicArray[{i}][2]")).Replace("\\n", "").Replace("\\t", "").Replace("\"", "").Trim();
                    orderHistory.referenceNumber = (await WV_DO.ExecuteScriptAsync($"dynamicArray[{i}][3]")).Replace("\\n", "").Replace("\\t", "").Replace("\"", "").Trim();
                    orderHistory.hrefLink = (await WV_DO.ExecuteScriptAsync($"dynamicArray[{i}][4]")).Replace("\\n", "").Replace("\\t", "").Replace("\"", "").Trim();
                    listOrders.Add(orderHistory);
                    PB_Orders_List.Value = (i + 1) * 100 / lengthOfTable;
                    LBL_List_Orders.Text = (i).ToString() + " orders found..";
                }
            }
            int desiredDays = Int32.Parse(CB_Days.SelectedItem.ToString().Replace(" Days", "").Replace(" Day",""));
            string lastDay = DateTime.Today.AddDays(-1 * desiredDays).ToString();
            List<OrderHistory> listOrdersFiltered = listOrders.Where(x => DateTime.ParseExact(x.orderDate, "MM/dd/yyyy", CultureInfo.InvariantCulture) >= DateTime.Today.AddDays(-1 * desiredDays)).ToList();
            LBL_List_Orders.Text += listOrdersFiltered.Count + " orders selected..";
            await WV_DO.ExecuteScriptAsync(@"console.log(window.frames[0].frames[2].document);");
            await WV_DO.ExecuteScriptAsync(@"let ddl1 = window.frames[0].frames[2].document.getElementsByName('rc_status_head1')[0].value = 'EALL';");
            await WV_DO.ExecuteScriptAsync(@"console.log(ddl1.length);");
            await WV_DO.ExecuteScriptAsync(@"window.frames[0].frames[2].document.getElementsByName('rc_dateattributes_select')[0].value = 'last_month';");
            await WV_DO.ExecuteScriptAsync(@"window.frames[0].frames[2].document.getElementsByName('rc_object_id')[0].value = 'last_month';");
            int index = 0;
            foreach (OrderHistory orderHistory in listOrdersFiltered)
            {
                //if (index < 224 && index > 215)
                {
                    orderHistory.market = Market;
                    await WV_DO.ExecuteScriptAsync($"window.frames[0].frames[2].document.getElementsByName('rc_object_id')[0].value = '{orderHistory.orderNo}';");
                    await WV_DO.ExecuteScriptAsync(@"window.frames[0].frames[2].document.getElementById('gsbuttonstart').click();");
                    await Task.Delay(Orders_Detail_Load_Time * 500);
                    await WV_DO.ExecuteScriptAsync(@"window.frames[0].frames[2].document.getElementsByClassName('showfiguresright')[0].children[0].click();");
                    await Task.Delay(Orders_Detail_Load_Time * 1000);

                    await WV_DO.ExecuteScriptAsync(@"var rows = window.frames[0].frames[4].frames[1].document.getElementsByClassName('orderDetails-table')[0].rows;");
                    await WV_DO.ExecuteScriptAsync(@"console.log(window.frames[0].frames[0].document);");
                    string vendor = await WV_DO.ExecuteScriptAsync(@"window.frames[0].frames[0].document.getElementsByClassName('user-details')[0].innerText;");
                    vendor = vendor.Replace("\"", "");
                    string[] vendors = vendor.Split("\u00A0");
                    vendor = "";
                    int stringCounts = 0;
                    foreach (string s in vendors)
                    {
                        if (stringCounts > 1)
                        {
                            vendor += s;
                        }
                        stringCounts++;
                    }
                    orderHistory.vendor = vendor;
                    orderHistory.shippingCondition = (await WV_DO.ExecuteScriptAsync(@"rows[3].cells[1].innerText;")).Replace("\"", "");
                    //orderHistory.deliveryAddress = (await WV_DO.ExecuteScriptAsync(@"rows[2].cells[1].innerText;")).Replace("\"", "");
                    //orderHistory.referenceNumber.IndexOf("TECH");
                    try
                    {
                        orderHistory.deliveryAddress = tupleStoreName.Where(x => x.Item1 == orderHistory.referenceNumber.Substring(orderHistory.referenceNumber.IndexOf("TECH"))).FirstOrDefault().Item2;
                    }
                    catch
                    {
                        orderHistory.deliveryAddress = orderHistory.referenceNumber.Substring(orderHistory.referenceNumber.IndexOf("TECH")) + " was not found in Conf.xlsx file!!";
                    }
                    
                    await WV_DO.ExecuteScriptAsync(@"var rowsOrderDetails = window.frames[0].frames[4].frames[1].document.getElementsByClassName('orderDetails-table')[1].rows;");
                    orderHistory.overallStatus = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[0].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.deliveryStatus = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[1].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.items = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[2].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.shipping = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[3].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.overpack = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[4].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.insurance = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[5].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.taxes = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[6].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.creditcardSurcharge = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[7].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.orderTotal = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[8].cells[1].innerText;")).Replace("\"", "");
                    orderHistory.termsOfPayment = (await WV_DO.ExecuteScriptAsync(@"rowsOrderDetails[9].cells[1].innerText;")).Replace("\"", "");
                    await WV_DO.ExecuteScriptAsync(@"console.log( rowsOrderDetails[2].cells[1].innerText);");

                    await WV_DO.ExecuteScriptAsync(@"var rowsOrderItems = window.frames[0].frames[4].frames[1].document.getElementsByClassName('orderItems-table')[0].rows;");
                    await WV_DO.ExecuteScriptAsync(@"console.log(rowsOrderItems.length); console.log(rowsOrderItems[1].cells[3].innerText);");
                    if (Int32.TryParse(await WV_DO.ExecuteScriptAsync(@"rowsOrderItems.length;"), out int rowCount))
                    {
                        for (int k = 0; k < rowCount; k++)
                        {
                            if (k % 2 == 1)
                            {
                                try
                                {
                                    OrderDetails orderDetails = new OrderDetails();
                                    orderDetails.item = await WV_DO.ExecuteScriptAsync($"rowsOrderItems[{k}].cells[2].innerText;");
                                    orderDetails.item = orderDetails.item.Replace("\"", "");
                                    orderDetails.product = await WV_DO.ExecuteScriptAsync($"rowsOrderItems[{k}].cells[3].innerText;");
                                    orderDetails.product = orderDetails.product.Replace("\"", "");
                                    orderDetails.quantity = await WV_DO.ExecuteScriptAsync($"rowsOrderItems[{k}].cells[4].innerText;");
                                    orderDetails.quantity = orderDetails.quantity.Replace("\"", "");
                                    orderDetails.description = await WV_DO.ExecuteScriptAsync($"rowsOrderItems[{k}].cells[5].innerText;");
                                    orderDetails.description = orderDetails.description.Replace("\"", "").Replace("\\n", "");
                                    //int quantityPerPack = GetQuantityPerPack(orderDetails.description);
                                    int quantityPerPack = 1;
                                    if (orderDetails.quantity.Contains("EA"))
                                        quantityPerPack = 1;
                                    else if (orderDetails.quantity.Contains("PAC"))
                                        quantityPerPack = GetQuantityPerPack(orderDetails.product);
                                    string[] prices = (await WV_DO.ExecuteScriptAsync($"rowsOrderItems[{k}].cells[6].innerText;")).Split("\\n");
                                    orderDetails.totalPrice = prices[0].Replace("\"", "");// await WV_DO.ExecuteScriptAsync($"rowsOrderItems[{k}].cells[6].innerText;");
                                    orderDetails.unitPrice = prices[1].Replace("\"", "");

                                    string[] totalPacksOrderedString = orderDetails.quantity.Split("\u00A0");

                                    float pricePerDevice = float.Parse(orderDetails.totalPrice.Replace("USD", "").Replace(" ", "").Replace("\u00A0", "")) / (quantityPerPack * float.Parse(totalPacksOrderedString[0]));
                                    orderDetails.unitPricePerDevice = pricePerDevice.ToString();
                                    orderDetails.totalDevices = (quantityPerPack * Int32.Parse(totalPacksOrderedString[0])).ToString();
                                    orderDetails.status = await WV_DO.ExecuteScriptAsync($"rowsOrderItems[{k}].cells[7].innerText;");
                                    orderDetails.status = orderDetails.status.Replace("\"", "");
                                    orderDetails.remainingQuantity = await WV_DO.ExecuteScriptAsync($"rowsOrderItems[{k}].cells[8].innerText;");
                                    orderDetails.remainingQuantity = orderDetails.remainingQuantity.Replace("\"", "");
                                    orderHistory.orderDetails.Add(orderDetails);
                                }
                                catch (Exception e)
                                {
                                    string s = e.Message;
                                    await LoadTMobileWebsite();
                                }
                                
                            }
                        }
                    }
                }
                index++;

                LBL_Reading_Data_From_Page.Text = "Reading data for record " + index.ToString() + " of " + listOrdersFiltered.Count().ToString() + " Records..";
                PB_Reading_Data_From_Page.Value = (index * 100) / listOrdersFiltered.Count();
            }
            DataTable dataTable = new DataTable();
            ListToDT listToDT = new ListToDT();
            dataTable = listToDT.ListToDTConvertor(listOrdersFiltered, PB_Convert_List_to_DT, LBL_Convert_List_to_DT);

            ExcelOperations excelOperations = new ExcelOperations();
            excelOperations.insertDataInExcel(SaveReportFolder + "\\IDO_Report", Market, dataTable, PB_Excel_Writing, LBL_Excel_Writing);
            comboBox1.Enabled = true;
            BTN_Login_and_Run.Enabled = true;
        }

        private async void BTN_Login_and_Run_Click(object sender, EventArgs e)
        {
            Market = comboBox1.SelectedItem.ToString().Replace("/", "");
            comboBox1.Enabled = false;
            BTN_Login_and_Run.Enabled = false;
            LBL_List_Orders.Text = "";
            LBL_Convert_List_to_DT.Text = "";
            LBL_Excel_Writing.Text = "";
            LBL_Reading_Data_From_Page.Text = "";

            PB_Convert_List_to_DT.Value = 0;
            PB_Excel_Writing.Value = 0;
            PB_Orders_List.Value = 0;
            PB_Reading_Data_From_Page.Value = 0;
            await InitWebView_InventoryTracking();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Tuple<string, string, string>> loginInfo = tupleMarket.Where(x => x.Item1 == comboBox1.SelectedItem).ToList();
            foreach (Tuple<string, string, string> tuple in loginInfo)
            {
                TB_UserID.Text = tuple.Item2;
                TB_Password.Text = tuple.Item3;
            }

        }
        private int GetQuantityPerPack(string deviceCode)
        {
            int quantity = 0;
            List<Tuple<string, string, string>> loginInfo = tupleDeviceQty.Where(x => x.Item1 == deviceCode).ToList();
            foreach (Tuple<string, string, string> tuple in loginInfo)
            {
                quantity = Int32.Parse(tuple.Item3);
            }

            return quantity;
        }
        private void TBar_Main_Page_Load_Time_Scroll(object sender, EventArgs e)
        {
            Main_Page_Load_Time = TBar_Main_Page_Load_Time.Value * 2;

            LBL_Main_Page_Load_Time.Text = "Wait " + Main_Page_Load_Time + " Seconds to load main page";

        }

        private void TBar_Order_Detail_Load_Time_Scroll(object sender, EventArgs e)
        {
            Orders_Detail_Load_Time = TBar_Order_Detail_Load_Time.Value * 2;
            LBL_Order_Details_Load_Time.Text = "Wait " + Orders_Detail_Load_Time + " Seconds to load order details";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TB_Save_Report_Folder_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                SaveReportFolder = folderDlg.SelectedPath;
                TB_Save_Report_Folder.Text = SaveReportFolder;
            }
        }
    }
}
