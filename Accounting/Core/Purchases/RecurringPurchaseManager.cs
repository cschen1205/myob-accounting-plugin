using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class RecurringPurchaseManager : RecurringEntityManager<RecurringPurchase>
    {
        public RecurringPurchaseManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region +(Factory Methods)
        protected override RecurringPurchase _CreateDbEntity()
        {
            return new RecurringPurchase(true, this);
        }

        protected override RecurringPurchase _CreateEntity()
        {
            RecurringPurchase _obj = new RecurringPurchase(false, this);
            _obj.PurchaseType = RepositoryMgr.InvoiceTypeMgr.DefaultInvoiceType;
            return _obj;
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringPurchase _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetRecurringEntityFields(_obj);

            fields["RecurringPurchaseID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringPurchaseID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["Comment"] = DbMgr.CreateStringFieldEntry(_obj.Comment);
            fields["ShipToAddress"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddress);
            fields["ShipToAddressLine1"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine1);
            fields["ShipToAddressLine2"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine2);
            fields["ShipToAddressLine3"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine3);
            fields["ShipToAddressLine4"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine4);
            fields["PurchaseStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PurchaseStatusID);
            fields["TermsID"] = DbMgr.CreateIntFieldEntry(_obj.TermsID);
            fields["InvoiceDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceDeliveryID);
            fields["ShippingMethodID"] = DbMgr.CreateIntFieldEntry(_obj.ShippingMethodID);
            fields["TaxExclusiveFreight"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveFreight);
            fields["TaxInclusiveFreight"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveFreight);
            fields["FreightTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.FreightTaxCodeID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            //fields["CostCentreID"] = new IntFieldEntry(_obj.CostCentreID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["PurchaseTypeID"] = DbMgr.CreateStringFieldEntry(_obj.PurchaseTypeID);

            return fields;
        }
   
        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringPurchases");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringPurchaseID(int RecurringPurchaseID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringPurchases")
                .Criteria
                    .IsEqual("RecurringPurchases", "RecurringPurchaseID", RecurringPurchaseID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringPurchaseID(int RecurringPurchaseID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringPurchases")
                .Criteria
                    .IsEqual("RecurringPurchases", "RecurringPurchaseID", RecurringPurchaseID);

            return clause;
        }

        private bool Exists(int? RecurringPurchaseID)
        {
            if (RecurringPurchaseID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringPurchaseID(RecurringPurchaseID.Value)) != 0;
        }

        public override bool Exists(RecurringPurchase _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.RecurringPurchaseID);
        }

        protected override RecurringPurchase _FindByIntId(int? RecurringPurchaseID)
        {
            if (Exists(RecurringPurchaseID))
            {
                RecurringPurchase _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringPurchaseID(RecurringPurchaseID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringPurchase _obj, DbDataReader _reader)
        {
            LoadRecurringEntityFromReader(_obj, _reader);
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.Memo =GetString(_reader, ("Memo"));
            _obj.Comment =GetString(_reader, ("Comment"));
         
            _obj.ShipToAddress =GetString(_reader, ("ShipToAddress"));
            _obj.ShipToAddressLine1 =GetString(_reader, ("ShipToAddressLine1"));
            _obj.ShipToAddressLine2 =GetString(_reader, ("ShipToAddressLine2"));
            _obj.ShipToAddressLine3 =GetString(_reader, ("ShipToAddressLine3"));
            _obj.ShipToAddressLine4 =GetString(_reader, ("ShipToAddressLine4"));
            _obj.PurchaseStatusID =GetString(_reader, ("PurchaseStatusID"));
            _obj.TermsID =GetInt32(_reader, ("TermsID"));
         
            _obj.InvoiceDeliveryID =GetString(_reader, ("InvoiceDeliveryID"));
            _obj.ShippingMethodID =GetInt32(_reader, ("ShippingMethodID"));
            
            _obj.TaxExclusiveFreight = GetDouble(_reader, ("TaxExclusiveFreight"));
            _obj.TaxInclusiveFreight = GetDouble(_reader, ("TaxInclusiveFreight"));
            _obj.FreightTaxCodeID =GetInt32(_reader, ("FreightTaxCodeID"));
           
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.IsTaxInclusive =GetString(_reader, ("IsTaxInclusive"));
            _obj.CostCentreID =GetInt32(_reader, ("CostCentreID"));
            _obj.PurchaseTypeID =GetString(_reader, ("PurchaseTypeID"));
        }

        protected override object GetDbProperty(RecurringPurchase _obj, string property_name)
        {
            object returned_obj = GetRecurringEntityDbProperty(_obj, property_name);
            if (returned_obj != null) return returned_obj;

            if (property_name == "PurchaseType")
            {
                return RepositoryMgr.InvoiceTypeMgr.FindById(_obj.PurchaseTypeID);
            }
            else if (property_name == "PurchaseStatus")
            {
                return RepositoryMgr.StatusMgr.FindById(_obj.PurchaseStatusID);
            }
            else if (property_name == "Terms")
            {
                return RepositoryMgr.TermsMgr.FindById(_obj.TermsID);
            }
            else if (property_name == "Supplier")
            {
                return RepositoryMgr.SupplierMgr.FindById(_obj.CardRecordID);
            }
            else if (property_name == "InvoiceDelivery")
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.InvoiceDeliveryID);
            }
            else if (property_name == "ShippingMethod")
            {
                return RepositoryMgr.ShippingMethodMgr.FindById(_obj.ShippingMethodID);
            }
            else if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name == "FreightTaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.FreightTaxCodeID);
            }
            
            return null;
        }

        public List<Definitions.Status> ListPurchaseStatus()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                    .SelectDistinct()
                    .SelectColumn("RecurringPurchases", "PurchaseStatusID")
                    .From("RecurringPurchases");

            

            DbCriteria criteria = DbMgr.CreateCriteria();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                criteria.IsEqual("Status", "StatusID",  GetString(_reader, ("PurchaseStatusID")), DbCriteria.ConcatMode.OR); 
            }
            _reader.Close();
            _cmd.Dispose();

            return RepositoryMgr.StatusMgr.List(criteria);
        }

        protected override IList<RecurringPurchase>_FindAllCollection()
        {
            List<RecurringPurchase> _purchases = new List<RecurringPurchase>();

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringPurchase _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _purchases.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _purchases;
        }

        public DataTable Table(DbCriteria criteria)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("RecurringPurchases", "RecurringPurchaseID", "ID")
                .SelectColumn("Suppliers", "Name", "SupplierName")
                .SelectColumn("RecurringPurchases", "PurchaseDate", "PurchaseDate")
                .From("RecurringPurchases")
                .From("Suppliers")
                .Join("RecurringPurchases", "CardRecordID", "Suppliers", "SupplierID")
                .Criteria.And(criteria);
            

            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Supplier ID");
            table.Columns.Add("Purchase Date");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                DataRow row=table.NewRow();
                row["ID"] = GetInt32(_reader, "ID");
                row["Supplier ID"] = GetString(_reader, "SupplierName");

                DateTime? purchase_date=GetDateTime(_reader, "PurchaseDate");
                if(purchase_date.HasValue)
                {
                    row["Purchase Date"] = purchase_date.Value.ToString("yyyy-MM-dd");
                }
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }
    }
}
