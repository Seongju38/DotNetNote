using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.DotNetNote
{
    public partial class BoardList : System.Web.UI.Page
    {
        int pageIndex = 0;
        public int TotalRecord = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Total Record: 11
            Models.NoteRepository noteRepository = new Models.NoteRepository();
            lblTotalRecord.Text = noteRepository.GetCount().ToString();

            TotalRecord = noteRepository.GetCount();

            string page = Request["page"];
            if (page == null)
            {
                pageIndex = 0;
            }
            else
            {
                pageIndex = Convert.ToInt32(page);
            }
            ctlBoardList.DataSource = noteRepository.GetAll(pageIndex);
            ctlBoardList.DataBind();
        }

        public string getStepHTML(object step)
        {
            string result = "";
            int intStep = Convert.ToInt32(step.ToString());
            if (intStep != 0)
            {
                result = String.Format("<img src='./images/dnn/blank.gif' style='height;0px;width:{0}px'/><img src='./images/dnn/re.gif'/>", intStep * 15);
            }
            return result;
        }

        public string ShowTime(object date)
        {
            string result = "";
            DateTime dateTime = (DateTime)date;
            DateTime now = DateTime.Now;

            if (dateTime.DayOfYear - now.DayOfYear == 0)
            {
                // 당일이면 시간출력 
                result = dateTime.ToShortTimeString();
            }
            else
            {
                // 이전날이면 날짜출력 
                result = dateTime.ToShortDateString();
            }

            return result;
        }

        public string NewImg(object date)
        {
            string result = "";
            DateTime dateTime = (DateTime)date;
            DateTime now = DateTime.Now;

            if (dateTime.DayOfYear - now.DayOfYear == 0)
            {
                // 당일이면 신규 이미지 출력
                result = "<img src='./images/dnn/new.gif' />";
            }

            return result;
        }

    }
}