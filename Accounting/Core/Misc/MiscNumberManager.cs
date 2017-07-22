using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;
using System.Data.Common;

namespace Accounting.Core.Misc
{
    public abstract class MiscNumberManager : EntityManager<MiscNumber>
    {
        public MiscNumberManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override MiscNumber _CreateDbEntity()
        {
            return new MiscNumber(true, this);
        }

        protected override MiscNumber _CreateEntity()
        {
            return new MiscNumber(false, this);
        }

        protected override void LoadFromReader(MiscNumber _obj, DbDataReader reader)
        {
            _obj.ID = GetInt32(reader, "ID");
            _obj.type = (MiscNumber.NumberType)GetInt32(reader, "type").Value;
            _obj.signature = GetString(reader, "signature");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(MiscNumber _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ID);
            fields["type"] = DbMgr.CreateIntFieldEntry((int)_obj.type);
            fields["signature"] = DbMgr.CreateStringFieldEntry(_obj.signature);

            return fields;
        }

        public bool Exists(string signature, MiscNumber.NumberType type)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("NumberGenerator")
                .Criteria
                    .IsEqual("NumberGenerator", "signature", signature)
                    .IsEqual("NumberGenerator", "type", (int)type);
            
            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        public override bool Exists(MiscNumber _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.signature, _obj.type);
        }

        public OpResult Store(string signature, MiscNumber.NumberType type)
        {
            if (Exists(signature, type))
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.NotCreatedDue2Exists, null, string.Format("{0} with value {1} is not created as it is already created", type, signature));
            }
            MiscNumber _obj = CreateEntity();
            _obj.signature = signature;
            _obj.type = type;
            return Store(_obj);
        }

        public MiscNumber FindBySignatureAndType(string signature, MiscNumber.NumberType type)
        {
            MiscNumber _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("NumberGenerator")
                .Criteria
                    .IsEqual("NumberGenerator", "signature", signature)
                    .IsEqual("NumberGenerator", "type", (int)type);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        private OpResult Delete(string signature, MiscNumber.NumberType type)
        {
            if (!Exists(signature, type))
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, null, string.Format("{0} with value {1} does not exist", type, signature));
            }
            MiscNumber _obj = FindBySignatureAndType(signature, type);
            return Delete(_obj);
        }

        public OpResult SaveInvoiceNumber(string invoiceNumber)
        {
            return Store(invoiceNumber, MiscNumber.NumberType.InvoiceNumber);
        }

        public OpResult SaveInventoryJournalNumber(string journal_number)
        {
            return Store(journal_number, MiscNumber.NumberType.InventoryJournalNumber);
        }

        public OpResult DeleteInventoryJournalNumber(string journal_number)
        {
            return Delete(journal_number, MiscNumber.NumberType.InventoryJournalNumber);
        }

        public OpResult DeleteInvoiceNumber(string invoiceNumber)
        {
            return Delete(invoiceNumber, MiscNumber.NumberType.InvoiceNumber);
        }

        public OpResult SavePurchaseNumber(string purchaseNumber)
        {
            return Store(purchaseNumber, MiscNumber.NumberType.PurchaseNumber);
        }

        public OpResult DeletePurchaseNumber(string purchaseNumber)
        {
            return Delete(purchaseNumber, MiscNumber.NumberType.PurchaseNumber);
        }

        public string GeneratePurchaseNumber()
        {
            DateTime current_time = DateTime.Now;
            int digits1 = int.Parse(current_time.ToString("yy"));
            int digits2 = int.Parse(current_time.ToString("MM"));
            //int digits3 = int.Parse(current_time.ToString("dd"));
            int digits4 = 1;

            while (digits4 != 1000 && Exists(string.Format("P{0:d2}{1:d2}{2:d3}", digits1, digits2, digits4), MiscNumber.NumberType.PurchaseNumber))
            {
                digits4++;
            }
            if (digits4 != 1000)
            {
                return string.Format("P{0:d2}{1:d2}{2:d3}", digits1, digits2, digits4);
            }
            Random rand = new Random();

            return string.Format("P{0:d2}{1:d2}{2:d3}", digits1, digits2, rand.Next(1, 999));
        }

        public string GenerateInventoryJournalNumber()
        {
            DateTime current_time = DateTime.Now;
            int digits1 = int.Parse(current_time.ToString("yy"));
            int digits2 = int.Parse(current_time.ToString("MM"));
            //int digits3 = int.Parse(current_time.ToString("dd"));
            int digits4 = 1;

            while (digits4 != 1000 && Exists(string.Format("I{0:d2}{1:d2}{2:d3}", digits1, digits2, digits4), MiscNumber.NumberType.InvoiceNumber))
            {
                digits4++;
            }
            if (digits4 != 1000)
            {
                return string.Format("I{0:d2}{1:d2}{2:d3}", digits1, digits2, digits4);
            }
            Random rand = new Random();

            return string.Format("I{0:d2}{1:d2}{2:d3}", digits1, digits2, rand.Next(1, 999));
        }

        
        public string GenerateInvoiceNumber()
        {
            DateTime current_time = DateTime.Now;
            int digits1 = int.Parse(current_time.ToString("yy"));
            int digits2 = int.Parse(current_time.ToString("MM"));
            //int digits3 = int.Parse(current_time.ToString("dd"));
            int digits4 = 1;

            while (digits4 != 1000 && Exists(string.Format("S{0:d2}{1:d2}{2:d3}", digits1, digits2, digits4), MiscNumber.NumberType.InvoiceNumber))
            {
                digits4++;
            }
            if (digits4 != 1000)
            {
                return string.Format("S{0:d2}{1:d2}{2:d3}", digits1, digits2, digits4);
            }
            Random rand = new Random();

            return string.Format("S{0:d2}{1:d2}{2:d3}", digits1, digits2, rand.Next(1, 999));
        }

        protected override IList<MiscNumber>_FindAllCollection()
        {
            List<MiscNumber> _grp = new List<MiscNumber>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("NumberGenerator");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MiscNumber _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}