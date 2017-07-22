using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;
using System.Data.Common;
using System.Data;

namespace Accounting.Core.Cards
{
    public class ContactLogManager : EntityManager<ContactLog>
    {
        public ContactLogManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Method)
        protected override ContactLog _CreateEntity()
        {
            return new ContactLog(false, this);
        }

        protected override ContactLog _CreateDbEntity()
        {
            return new ContactLog(true, this);
        }
        #endregion

        protected override object GetDbProperty(ContactLog _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ContactLog");
        }

        protected override IList<ContactLog>_FindAllCollection()
        {
            List<ContactLog> contactLogs = new List<ContactLog>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ContactLog _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                contactLogs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return contactLogs;
        }

        public object Table(Card card, DateTime start_time, DateTime end_time)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("ContactLog", "Date")
                .SelectColumn("ContactLog", "ElapsedTime")
                .SelectColumn("ContactLog", "RecontactDate")
                .SelectColumn("ContactLog", "Notes")
                .From("ContactLog");
            

            DataTable table = new DataTable();
            table.Columns.Add("Date");
            table.Columns.Add("Time");
            table.Columns.Add("Recontact");
            table.Columns.Add("Notes");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["Date"] = GetInt32(_reader, "Date");
                row["Time"] = GetString(_reader, "ElapsedTime");
                row["Recontact"] = GetString(_reader, "RecontactDate");
                row["Notes"] = GetString(_reader, "Notes");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }


        protected override void LoadFromReader(ContactLog _obj, DbDataReader reader)
        {
            _obj.ContactLogID = GetInt32(reader, "ContactLogID");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.Contact = GetString(reader, "Contact");
            _obj.Date = GetDateTime(reader, "Date");
            _obj.ElapsedTime = GetString(reader, "ElapsedTime");
            _obj.LogDate = GetDateTime(reader, "LogDate");
            _obj.Notes = GetString(reader, "Notes");
            _obj.RecontactDate = GetDateTime(reader, "RecontactDate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ContactLog _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ContactLogID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ContactLogID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["Contact"] = DbMgr.CreateStringFieldEntry(_obj.Contact);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["ElapsedTime"] = DbMgr.CreateStringFieldEntry(_obj.ElapsedTime);
            fields["LogDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LogDate);
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Notes);
            fields["RecontactDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.RecontactDate);
            return fields;
        }
    }
}
