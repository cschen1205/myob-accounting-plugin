using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.ServiceModel;
using Was.AccServiceRef;

namespace Was.Views.Sales
{
    public partial class SalesRegister : Page
    {
        private int mRecordCount = 0;
        public SalesRegister()
        {
            InitializeComponent();

            

            dpEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dpStart.Text = DateTime.Now.AddYears(-3).ToString("dd/MM/yyyy");
            dpPromised.Text = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            dpInvoiced.Text = DateTime.Now.ToString("dd/MM/yyyy");

            SaleDataPager.SelectionChanged += new SelectionChangedEventHandler(SaleDataPager_SelectionChanged);

            LoadCustomers();
            LoadSalespersons();
            LoadInvoiceStatus();
            LoadComments();
            LoadTerms();
            LoadReferralSources();
            LoadInvoiceDeliveries();
            LoadShippingMethods();
            LoadTaxCodes();
            LoadCurrency();
            LoadInvoiceTypes();

            DoSearch();
        }

        private void LoadInvoiceTypes()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListInvoiceTypesCompleted += new EventHandler<ListInvoiceTypesCompletedEventArgs>(client_ListInvoiceTypesCompleted);
            
            client.ListInvoiceTypesAsync();
        }

        void client_ListInvoiceTypesCompleted(object sender, ListInvoiceTypesCompletedEventArgs e)
        {
            CboSaleLayout.ItemsSource = e.Result;
            if (CboSaleLayout.Items.Count > 0)
            {
                CboSaleLayout.SelectedIndex = 0;
            }
        }

        private void LoadCurrency()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListCurrencyCompleted += new EventHandler<ListCurrencyCompletedEventArgs>(client_ListCurrencyCompleted);
            client.ListCurrencyAsync();
        }

        void client_ListCurrencyCompleted(object sender, ListCurrencyCompletedEventArgs e)
        {
            CboCurrency.ItemsSource = e.Result;
            if (CboCurrency.Items.Count > 0)
            {
                CboCurrency.SelectedIndex = 0;
            }
        }

        private void LoadTaxCodes()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListTaxCodesCompleted += new EventHandler<ListTaxCodesCompletedEventArgs>(client_ListTaxCodesCompleted);
            client.ListTaxCodesAsync();
        }

        void client_ListTaxCodesCompleted(object sender, ListTaxCodesCompletedEventArgs e)
        {
            CboFreightTaxCode.ItemsSource = e.Result;
            if (CboFreightTaxCode.Items.Count > 0)
            {
                CboFreightTaxCode.SelectedIndex = 0;
            }
        }

        private void LoadShippingMethods()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListShippingMethodsCompleted += new EventHandler<ListShippingMethodsCompletedEventArgs>(client_ListShippingMethodsCompleted);
            client.ListShippingMethodsAsync();
        }

        void client_ListShippingMethodsCompleted(object sender, ListShippingMethodsCompletedEventArgs e)
        {
            CboShippingMethod.ItemsSource = e.Result;
            if (CboShippingMethod.Items.Count > 0)
            {
                CboShippingMethod.SelectedIndex = 0;
            }
        }

        private void LoadInvoiceDeliveries()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListInvoiceDeliveriesCompleted += new EventHandler<ListInvoiceDeliveriesCompletedEventArgs>(client_ListInvoiceDeliveriesCompleted);
            client.ListInvoiceDeliveriesAsync();
        }

        void client_ListInvoiceDeliveriesCompleted(object sender, ListInvoiceDeliveriesCompletedEventArgs e)
        {
            CboInvoiceDelivery.ItemsSource = e.Result;
            if (CboInvoiceDelivery.Items.Count > 0)
            {
                CboInvoiceDelivery.SelectedIndex = 0;
            }
        }

        private void LoadReferralSources()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListReferralSourcesCompleted += new EventHandler<ListReferralSourcesCompletedEventArgs>(client_ListReferralSourcesCompleted);
            client.ListReferralSourcesAsync();
        }

        void client_ListReferralSourcesCompleted(object sender, ListReferralSourcesCompletedEventArgs e)
        {
            CboReferralSource.ItemsSource = e.Result;
            if (CboReferralSource.Items.Count > 0)
            {
                CboReferralSource.SelectedIndex = 0;
            }
        }

        private void LoadTerms()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListTermsCompleted += new EventHandler<ListTermsCompletedEventArgs>(client_ListTermsCompleted);
            client.ListTermsAsync();
        }

        void client_ListTermsCompleted(object sender, ListTermsCompletedEventArgs e)
        {
            CboTerms.ItemsSource = e.Result;
            if (CboTerms.Items.Count > 0)
            {
                CboTerms.SelectedIndex = 0;
            }
        }

        private void LoadComments()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListCommentsCompleted += new EventHandler<ListCommentsCompletedEventArgs>(client_ListCommentsCompleted);
            client.ListCommentsAsync();
        }

        private void  client_ListCommentsCompleted(object sender, ListCommentsCompletedEventArgs e)
        {
            CboComment.ItemsSource = e.Result;
            if (CboComment.Items.Count > 0)
            {
                CboComment.SelectedIndex = 0;
            }
        } 

        void LoadCustomers()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListCustomersCompleted += new EventHandler<ListCustomersCompletedEventArgs>(client_ListCustomersCompleted);
            client.ListCustomersAsync();
        }

        private void LoadSalespersons()
        {
            SaleServiceClient client=new SaleServiceClient();
            client.ListSalespersonsCompleted += new EventHandler<ListSalespersonsCompletedEventArgs>(client_ListSalespersonsCompleted);
            client.ListSalespersonsAsync();
        }

        void client_ListSalespersonsCompleted(object sender, ListSalespersonsCompletedEventArgs e)
        {
            CboSalesperson.ItemsSource = e.Result;
            if (CboSalesperson.Items.Count > 0)
            {
                CboSalesperson.SelectedIndex = 0;
            }
        }

        private void LoadInvoiceStatus()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.ListInvoiceStatusCompleted += new EventHandler<ListInvoiceStatusCompletedEventArgs>(client_ListInvoiceStatusCompleted);
            client.ListInvoiceStatusAsync();
        }

        void client_ListCustomersCompleted(object sender, ListCustomersCompletedEventArgs e)
        {
            CboCustomer.ItemsSource = e.Result;
            CboIndividualSaleCustomer.ItemsSource = e.Result;
            if (CboCustomer.Items.Count > 0)
            {
                CboCustomer.SelectedIndex = 0;
                CboIndividualSaleCustomer.SelectedIndex = 0;
            }
        }

        void client_ListInvoiceStatusCompleted(object sender, ListInvoiceStatusCompletedEventArgs e)
        {
            CboInvoiceStatus.ItemsSource = e.Result;
            if (CboInvoiceStatus.Items.Count > 0)
            {
                CboInvoiceStatus.SelectedIndex = 0;
            }
        }

        void client_GetSalesCountCompleted(object sender, GetSalesCountCompletedEventArgs e)
        {
            SaleDataPager.Items.Clear();
            int count=e.Result;
            mRecordCount = count;
            if (mRecordCount == 0)
            {
                SaleGrid.ItemsSource = null;
                SaleDataPageInfo.Text = "No records found";
                return;
            }
            int pageCount=count / 10;
            if (count % 10 != 0) pageCount++;
            for (int i = 0; i < pageCount; ++i)
            {
                SaleDataPager.Items.Add(i.ToString());
            }
            if (SaleDataPager.Items.Count > 0)
            {
                SaleDataPager.SelectedIndex = 0;
            }
           
        }

        void SaleDataPager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DoPagination();           
        }

        private void DoSearch()
        {
            SaleServiceClient client = new SaleServiceClient();
            client.GetSalesCountCompleted += new EventHandler<GetSalesCountCompletedEventArgs>(client_GetSalesCountCompleted);
            DateTime start = DateTime.Parse(dpStart.Text);
            DateTime end = DateTime.Parse(dpEnd.Text);

            int? CustomerID = null;
            if (ChkAllCustomers.IsChecked == false)
            {
                LightCustomer customer = (LightCustomer)CboCustomer.SelectedItem;
                if (customer != null)
                {
                    CustomerID = int.Parse(customer.CustomerID);
                }
            }
            string InvoiceStatusID = null;
            if (ChkAllStatus.IsChecked == false)
            {
                LightStatus invoiceStatus = (LightStatus)CboInvoiceStatus.SelectedItem;
                if (invoiceStatus != null)
                {
                    InvoiceStatusID = invoiceStatus.StatusID;
                }
            }

            client.GetSalesCountAsync(start, end, CustomerID, InvoiceStatusID, 10);
        }

        private void DoPagination()
        {
            
            if (SaleDataPager.Items.Count == 0) return;
            int pageNum = int.Parse(SaleDataPager.SelectedItem.ToString());

            int lastIndex = (pageNum + 1) * 10;
            if (lastIndex > mRecordCount) lastIndex = mRecordCount;
            SaleDataPageInfo.Text = string.Format("Current displaying records: {0}-{1} (total: {2})", pageNum * 10 + 1, lastIndex, mRecordCount);

            SaleServiceClient client = new SaleServiceClient();
            client.ListSalesWithPagingCompleted += new EventHandler<ListSalesWithPagingCompletedEventArgs>(client_ListSalesWithPagingCompleted);

            DateTime start = DateTime.Parse(dpStart.Text);
            DateTime end = DateTime.Parse(dpEnd.Text);

            int? CustomerID = null;
            if (ChkAllCustomers.IsChecked == false)
            {
                LightCustomer customer = (LightCustomer)CboCustomer.SelectedItem;
                if (customer != null)
                {
                    CustomerID = int.Parse(customer.CustomerID);
                }
            }

            string InvoiceStatusID = null;
            if (ChkAllStatus.IsChecked == false)
            {
                LightStatus invoiceStatus = (LightStatus)CboInvoiceStatus.SelectedItem;
                if (invoiceStatus != null)
                {
                    InvoiceStatusID = invoiceStatus.StatusID;
                }
            }

            client.ListSalesWithPagingAsync(start, end, CustomerID, InvoiceStatusID, pageNum * 10 + 1, 10);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        void client_ListSalesWithPagingCompleted(object sender, ListSalesWithPagingCompletedEventArgs e)
        {
                 
            SaleGrid.ItemsSource = e.Result;
            
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            DoSearch();
        }

        private void SaleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SaleGrid.SelectedItems.Count == 0) return;
            LightSale _sale=(LightSale)SaleGrid.SelectedItem;
            if (_sale == null) return;

            int? SaleID = null;
            if (_sale.SaleID != null)
            {
                SaleID = int.Parse(_sale.SaleID);
            }
            SaleServiceClient client = new SaleServiceClient();
            client.RetrieveSaleCompleted += new EventHandler<RetrieveSaleCompletedEventArgs>(client_RetrieveSaleCompleted);
            client.RetrieveSaleAsync(SaleID);
        }

        void client_RetrieveSaleCompleted(object sender, RetrieveSaleCompletedEventArgs e)
        {
            LightSale2 _sale2 = e.Result;
            if (_sale2 == null) return;

            TxtInvoiceNumber.Text = _sale2.InvoiceNumber;
            TxtAddressLine1.Text = _sale2.ShipToAddressLine1;
            TxtAddressLine2.Text = _sale2.ShipToAddressLine2;
            TxtAddressLine3.Text = _sale2.ShipToAddressLine3;
            TxtAddressLine4.Text = _sale2.ShipToAddressLine4;
            TxtMemo.Text = _sale2.Memo;
            TxtPONumber.Text = _sale2.CustomerPONumber;
            dpInvoiced.Text = _sale2.InvoiceDate;
            dpPromised.Text = _sale2.PromisedDate;
            
            ChkIsTaxInclusive.IsChecked = _sale2.IsTaxInclusive.Equals("Y");

            
            CboIndividualSaleCustomer.SelectedItem = _sale2.Customer;
            CboTerms.SelectedItem = _sale2.Terms;
            CboShippingMethod.SelectedItem = _sale2.ShippingMethod;
            //CboIndividualSaleCustomer.
            
        }

        
       

    }
}
