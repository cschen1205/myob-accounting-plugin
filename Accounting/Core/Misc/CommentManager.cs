using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Misc
{
    public abstract class CommentManager : EntityManager<Comment>
    {
        public CommentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Comment _CreateDbEntity()
        {
            return new Comment(true, this);
        }

        protected override Comment _CreateEntity()
        {
            return new Comment(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Comment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["CommentID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CommentID);
            fields["Comment"] = DbMgr.CreateStringFieldEntry(_obj.Text);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Comments");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCommentID(int CommentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Comments")
                .Criteria.IsEqual("Comments", "CommentID", CommentID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCommentID(int CommentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Comments")
                .Criteria.IsEqual("Comments", "CommentID", CommentID);
            return clause;
        }

        private bool Exists(int? CommentID)
        {
            if (CommentID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCommentID(CommentID.Value)) != 0;
        }

        public override bool Exists(Comment _obj)
        {
            if (_obj.CommentID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCommentID(_obj.CommentID.Value)) != 0;
        }

        protected override void LoadFromReader(Comment _obj, DbDataReader _reader)
        {
            _obj.CommentID =GetInt32(_reader, ("CommentID"));
            _obj.Text =GetString(_reader, ("Comment"));
        }

        protected override IList<Comment>_FindAllCollection()
        {
            List<Comment> comments = new List<Comment>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Comment _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                comments.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return comments;
        }

        protected override Comment _FindByIntId(int? CommentID)
        {
            if (Exists(CommentID))
            {
                Comment _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCommentID(CommentID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }
    }
}
