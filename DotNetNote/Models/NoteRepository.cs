using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace DotNetNote.DotNetNote.Models
{
    public class NoteRepository
    {
        private OracleConnection conn = null;
        public NoteRepository()
        {
            conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
        }

        ~NoteRepository()
        {
            conn.Close();
        }

        public List<Note> GetAll(int page)
        {
            List<Note> resultList = new List<Note>();

            OracleCommand cmd = new OracleCommand("SP_ListNotes", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("IN_PAGE", OracleDbType.Int32, page, ParameterDirection.Input);
            cmd.Parameters.Add("OUT_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Note note = new Note();

                note.Name = dr["NAME"].ToString();
                note.Email = dr["Email"].ToString();
                note.Title = dr["Title"].ToString();
                note.PostDate = (DateTime)dr["PostDate"];
                note.ReadCount = Convert.ToInt32(dr["ReadCount"].ToString());
                note.Ref = Convert.ToInt32(dr["Ref"].ToString());
                note.Step = Convert.ToInt32(dr["Step"].ToString());
                note.RefOrder = Convert.ToInt32(dr["RefOrder"].ToString());
                note.AnswerNum = Convert.ToInt32(dr["AnswerNum"].ToString());
                note.ParentNum = Convert.ToInt32(dr["ParentNum"].ToString());
                note.CommentCount = Convert.ToInt32(dr["CommentCount"].ToString());
                note.FileName = dr["FileName"].ToString();
                note.FileSize = Convert.ToInt32(dr["FileSize"].ToString());
                note.DownCount = Convert.ToInt32(dr["DownCount"].ToString());
                note.RowNumber = Convert.ToInt32(dr["RowNumber"].ToString());
                note.boardId = Convert.ToInt32(dr["BOARDID"].ToString());

                resultList.Add(note);
            }
            dr.Close();

            return resultList;
        }

        public int GetCount()
        {
            OracleCommand cmd = new OracleCommand("SP_GetCountNotes", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("out_cnt", OracleDbType.Int32, ParameterDirection.Input);
            
            cmd.ExecuteReader();
            int count = Convert.ToInt32(cmd.Parameters["out_cnt"].Value.ToString());
            cmd.Dispose();

            return count;
        }
    }
}