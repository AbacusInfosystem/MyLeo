using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;
using System.Data;

namespace MyLeoRetailerHelper
{
    public static class PageHelper
    {
        public static string NumericPagerForAtlant(int totalRecords, int currentPage, int pagesize, int pageLimit, int startPage, int endPage, bool isFirst, bool isPrevious, bool isNext, bool isLast, bool pageAndRecordLabel, string grid_div,string callback)
        {
            StringBuilder pagerStr = new StringBuilder();

            if (isFirst || (startPage == 0 && endPage == 0))
            {
                pagerStr = OnFirstClick(totalRecords, currentPage, pagesize, pageLimit, startPage, endPage, pageAndRecordLabel,grid_div,callback);
            }

            if (isPrevious)
            {
				pagerStr = OnPreviousClick(totalRecords, currentPage, pagesize, pageLimit, startPage, endPage, pageAndRecordLabel, grid_div, callback);
            }

            if (isNext)
            {
				pagerStr = OnNextClick(totalRecords, currentPage, pagesize, pageLimit, startPage, endPage, pageAndRecordLabel, grid_div, callback);
            }

            if (isLast)
            {
				pagerStr = OnLastClick(totalRecords, currentPage, pagesize, pageLimit, startPage, endPage, pageAndRecordLabel, grid_div, callback);
            }

            if ((!isFirst && !isPrevious && !isNext && !isLast ) && (startPage != 0 && endPage != 0))
            {
				pagerStr = OnButtonClick(totalRecords, currentPage, pagesize, pageLimit, startPage, endPage, pageAndRecordLabel, grid_div, callback);
            }

            return pagerStr.ToString();
        }

		private static StringBuilder OnFirstClick(int totalRecords, int currentPage, int pagesize, int pageLimit, int startPage, int endPage, bool pageAndRecordLabel, string grid_div, string callback)
        {
            StringBuilder pagerStr = new StringBuilder();

            // Set currentPage as 1.

            currentPage = 1;

            int pages = Compute_Pages(totalRecords, pagesize);

            #region Total Record Message

            string position_Message = Set_Position_Message(pageAndRecordLabel, currentPage, pagesize, totalRecords);

            pagerStr.Append(position_Message);

            #endregion

            pagerStr.Append("<div class='dataTables_paginate paging_simple_numbers'>");

            #region First Button

            // Do not bind First button.

            #endregion

            #region Previous Button

            // Do not bind Previous Button.

            #endregion

            #region Page Button

            bool flagNextBatchExists = false;

			string compute_Button = Compute_Buttons(ref flagNextBatchExists, pages, pageLimit, totalRecords, pagesize, ref currentPage, ref startPage, ref endPage, grid_div, callback);

            pagerStr.Append(compute_Button);

            #endregion

            #region Next Button

            if (flagNextBatchExists)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Next','"+grid_div+"',"+callback+");\" class='paginate_button next' tabindex='0'>Next</a>");
            }

            #endregion

            #region Last Button

            if (flagNextBatchExists)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Last','"+grid_div+"',"+callback+");\"  class='paginate_button next' tabindex='0'>Last</a>");
            }

            #endregion

            pagerStr.Append("</div>");

            string hidden_Fields = Set_Hidden_Fields(startPage, endPage);

            pagerStr.Append(hidden_Fields);

            return pagerStr;
        }

		private static StringBuilder OnPreviousClick(int totalRecords, int currentPage, int pagesize, int pageLimit, int startPage, int endPage, bool pageAndRecordLabel, string grid_div, string callback)
        {
            StringBuilder pagerStr = new StringBuilder();

            int pages = Compute_Pages(totalRecords, pagesize);

            #region Set Current Page

            //int diff = (endPage - startPage);

            int tempEnd = startPage - 1;

            //int tempStart = tempEnd - diff;

            int tempStart = tempEnd - pageLimit;

            if (tempEnd == pageLimit) // Incase when tempEnd is 5 and Page Limit is also 5. Then tempStart would be zero. So make it 1.
            {
                tempStart += 1;
            }

            startPage = tempStart;

            endPage = tempEnd;

            currentPage = endPage;  // You can also set it to startPage.

            #endregion

            #region Total Record Message

            string position_Message = Set_Position_Message(pageAndRecordLabel, currentPage, pagesize, totalRecords);

            pagerStr.Append(position_Message);

            #endregion

            pagerStr.Append("<div class='dataTables_paginate paging_simple_numbers'>");

            #region First Button

            if (startPage > 1)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('First','"+grid_div+"',"+callback+");\" class='paginate_button previous' tabindex='0'>First</a>");
            }

            #endregion

            #region Previous Button

            if (startPage > 1)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Previoust','"+grid_div+"',"+callback+");\" class='paginate_button previous' tabindex='0'>Previous</a>");
            }

            #endregion

            #region Page Button

            bool flagNextBatchExists = false;

			string compute_Button = Compute_Buttons(ref flagNextBatchExists, pages, pageLimit, totalRecords, pagesize, ref currentPage, ref startPage, ref endPage, grid_div, callback);

            pagerStr.Append(compute_Button);

            #endregion

            #region Next Button

            if (flagNextBatchExists)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Next','"+grid_div+"',"+callback+");\" class='paginate_button next' tabindex='0'>Next</a>");
            }

            #endregion

            #region Last Button

            if (flagNextBatchExists)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Last','"+grid_div+"',"+callback+");\" class='paginate_button next' tabindex='0'>Last</a>");
            }

            #endregion

            pagerStr.Append("</div>");

            string hidden_Fields = Set_Hidden_Fields(startPage, endPage);

            pagerStr.Append(hidden_Fields);

            return pagerStr;
        }

		private static StringBuilder OnNextClick(int totalRecords, int currentPage, int pagesize, int pageLimit, int startPage, int endPage, bool pageAndRecordLabel, string grid_div, string callback)
        {
            StringBuilder pagerStr = new StringBuilder();

            int pages = Compute_Pages(totalRecords, pagesize);

            #region Set Current Page

            int diff = (endPage - startPage);

            int tempStart = endPage + 1;

            int tempEnd = tempStart + diff;

            startPage = tempStart;

            endPage = tempEnd;

            currentPage = startPage;

            #endregion

            #region Total Record Message

            string position_Message = Set_Position_Message(pageAndRecordLabel, currentPage, pagesize, totalRecords);

            pagerStr.Append(position_Message);

            #endregion

            pagerStr.Append("<div class='dataTables_paginate paging_simple_numbers'>");

            #region First Button

            if (startPage > 1)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('First','"+grid_div+"',"+callback+");\" class='paginate_button previous' tabindex='0'>First</a>");
            }

            #endregion

            #region Previous Button

            if (startPage > 1)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Previoust','"+grid_div+"',"+callback+");\" class='paginate_button previous' tabindex='0'>Previous</a>");
            }

            #endregion

            #region Page Button

            bool flagNextBatchExists = false;

			string compute_Button = Compute_Buttons(ref flagNextBatchExists, pages, pageLimit, totalRecords, pagesize, ref currentPage, ref startPage, ref endPage, grid_div, callback);

            pagerStr.Append(compute_Button);

            #endregion

            #region Next Button

            if (flagNextBatchExists)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Next','"+grid_div+"',"+callback+");\" class='paginate_button next' tabindex='0'>Next</a>");
            }

            #endregion

            #region Last Button

            if (flagNextBatchExists)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Last','"+grid_div+"',"+callback+");\" class='paginate_button next' tabindex='0'>Last</a>");
            }

            #endregion

            pagerStr.Append("</div>");

            string hidden_Fields = Set_Hidden_Fields(startPage, endPage);

            pagerStr.Append(hidden_Fields);

            return pagerStr;
        }

		private static StringBuilder OnLastClick(int totalRecords, int currentPage, int pagesize, int pageLimit, int startPage, int endPage, bool pageAndRecordLabel, string grid_div, string callback)
        {
            StringBuilder pagerStr = new StringBuilder();

            int pages = Compute_Pages(totalRecords, pagesize);

            #region Set Current Page

            int diff = (endPage - startPage);

            int tempEnd = pages;

            int tempStart = tempEnd - diff;

            startPage = tempStart;

            endPage = tempEnd;

            currentPage = tempEnd;

            #endregion

            #region Total Record Message

            string position_Message = Set_Position_Message(pageAndRecordLabel, currentPage, pagesize, totalRecords);

            pagerStr.Append(position_Message);

            #endregion

            pagerStr.Append("<div class='dataTables_paginate paging_simple_numbers'>");

            #region First Button

            if (startPage > 1)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('First','"+grid_div+"',"+callback+");\" class='paginate_button previous' tabindex='0'>First</a>");
            }

            #endregion

            #region Previous Button

            if (startPage > 1)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Previoust','"+grid_div+"',"+callback+");\" class='paginate_button previous' tabindex='0'>Previous</a>");
            }

            #endregion

            #region Page Button

            bool flagNextBatchExists = false;

			string compute_Button = Compute_Buttons(ref flagNextBatchExists, pages, pageLimit, totalRecords, pagesize, ref currentPage, ref startPage, ref endPage, grid_div, callback);

            pagerStr.Append(compute_Button);

            #endregion

            #region Next Button

            // Do not bind Next button.

            #endregion

            #region Last Button

            // Do not bind Last button.

            #endregion

            pagerStr.Append("</div>");

            string hidden_Fields = Set_Hidden_Fields(startPage, endPage);

            pagerStr.Append(hidden_Fields);

            return pagerStr;
        }

		private static StringBuilder OnButtonClick(int totalRecords, int currentPage, int pagesize, int pageLimit, int startPage, int endPage, bool pageAndRecordLabel, string grid_div, string callback)
        {
            StringBuilder pagerStr = new StringBuilder();

            int pages = Compute_Pages(totalRecords, pagesize);

            #region Total Record Message

            string position_Message = Set_Position_Message(pageAndRecordLabel, currentPage, pagesize, totalRecords);

            pagerStr.Append(position_Message);

            #endregion

            pagerStr.Append("<div class='dataTables_paginate paging_simple_numbers'>");

            #region First Button

            if (startPage > 1)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('First','"+grid_div+"',"+callback+");\" class='paginate_button previous' tabindex='0'>First</a>");
            }

            #endregion

            #region Previous Button

            if (startPage > 1)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Previoust','"+grid_div+"',"+callback+");\" class='paginate_button previous' tabindex='0'>Previous</a>");
            }

            #endregion

            #region Page Button

            bool flagNextBatchExists = false;

			string compute_Button = Compute_Buttons(ref flagNextBatchExists, pages, pageLimit, totalRecords, pagesize, ref currentPage, ref startPage, ref endPage, grid_div, callback);

            pagerStr.Append(compute_Button);

            #endregion

            #region Next Button

            if (flagNextBatchExists)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Next','"+grid_div+"',"+callback+");\" class='paginate_button next' tabindex='0'>Next</a>");
            }

            #endregion

            #region Last Button

            if (flagNextBatchExists)
            {
                pagerStr.Append("<a href=\"javascript: MoveQuick('Last','"+grid_div+"',"+callback+");\" class='paginate_button next' tabindex='0'>Last</a>");
            }

            #endregion

            pagerStr.Append("</div>");

            string hidden_Fields = Set_Hidden_Fields(startPage, endPage);

            pagerStr.Append(hidden_Fields);

            return pagerStr;
        }

        private static int Compute_Pages(int totalRecords, int pagesize)
        {
            int reminder = totalRecords % pagesize;

            int pages = 0;

            if (reminder > 0)
            {
                pages = (totalRecords / pagesize) + 1;
            }
            else
            {
                pages = totalRecords / pagesize;
            }

            return pages;
        }

        private static string Set_Position_Message(bool pageAndRecordLabel, int currentPage, int pagesize, int totalRecords)
        {
            StringBuilder pagerStr = new StringBuilder();

            int from = 0;

            int to = 0;

            if (pageAndRecordLabel)
            {
                from = ((currentPage * pagesize) - (pagesize)) + 1;

                to = from + (pagesize - 1);

                //pagerStr.Append("<div class='dataTables_info'>Showing " + from + " to " + to + " of " + totalRecords + " entries</div>");

                if (totalRecords >= from && totalRecords <= to)
                {
                    if (totalRecords == from)
                    {
                        pagerStr.Append("<div class='dataTables_info'>Showing " + from + " of " + totalRecords + " entries</div>");
                    }
                    else
                    {
                        pagerStr.Append("<div class='dataTables_info'>Showing " + from + " to " + totalRecords + " of " + totalRecords + " entries</div>");
                    }
                }
                else
                {
                    pagerStr.Append("<div class='dataTables_info'>Showing " + from + " to " + to + " of " + totalRecords + " entries</div>");
                }
            }

            return pagerStr.ToString();
        }

		private static string Compute_Buttons(ref bool flagNextBatchExists, int pages, int pageLimit, int totalRecords, int pagesize, ref int currentPage, ref int startPage, ref int endPage, string grid_div, string callback)
        {
            StringBuilder pagerStr = new StringBuilder();

            int tempPage = 0;

            int batchStart = 0;

            int batchEnd = 0;

            int numberOfBatches = 0;

            flagNextBatchExists = false;

            if (pages <= pageLimit)
            {
                numberOfBatches = 1;
            }
            else
            {
                //reminder = totalRecords % pagesize;

                //if (reminder > 0)
                //{
                //    numberOfBatches = ((totalRecords / pagesize) / pageLimit) + 1;
                //}
                //else
                //{
                //    numberOfBatches = pages;
                //}

                int r1, r2;

                int value1, value2;

                r1 = totalRecords % pagesize;

                if (r1 > 0)
                {
                    value1 = (totalRecords / pagesize) + 1;

                    r2 = value1 % pageLimit;

                    if (r2 > 0)
                    {
                        value2 = (value1 / pageLimit) + 1;
                    }
                    else
                    {
                        value2 = (value1 / pageLimit);
                    }
                }
                else
                {
                    value1 = (totalRecords / pagesize);

                    r2 = value1 % pageLimit;

                    if (r2 > 0)
                    {
                        value2 = (value1 / pageLimit) + 1;
                    }
                    else
                    {
                        value2 = (value1 / pageLimit);
                    }
                }

                numberOfBatches = value2;
            }

            for (int batch = 1; batch <= numberOfBatches; batch++)
            {
                flagNextBatchExists = true;

                tempPage += 1;

                batchStart = tempPage;

                if (pages <= pageLimit)
                {
                    pageLimit = pages;
                }

                batchEnd = batchStart + (pageLimit - 1);

                if (pages >= batchStart && pages <= batchEnd)
                {
                    batchEnd = pages;
                }

                for (int page = tempPage; page < totalRecords; page++)
                {
                    tempPage = page;

                    if (currentPage >= batchStart && currentPage <= batchEnd)
                    {
                        startPage = batchStart;

                        endPage = batchEnd;

                        if (currentPage == page)
                        {
                            pagerStr.Append("<a href=\"javascript: Page(" + page + ",'"+grid_div+"',"+callback+");\"  class='paginate_button current' tabindex='0'>" + page + "</a>");
                        }
                        else
                        {
                            pagerStr.Append("<a href=\"javascript: Page(" + page + ",'"+grid_div+"',"+callback+");\"  class='paginate_button' tabindex='0'>" + page + "</a>");
                        }

                        flagNextBatchExists = false;
                    }

                    if (page >= batchEnd)
                    {
                        break;
                    }
                }
            }

            return pagerStr.ToString();
        }

        private static string Set_Hidden_Fields(int startPage, int endPage)
        {
            StringBuilder pagerStr = new StringBuilder();

            pagerStr.Append("<input type='hidden' class='current-page' value='' name='Grid_Detail.Pager.CurrentPage' /> ");

            pagerStr.Append("<input type='hidden' class='quick-page' value=''> ");

            pagerStr.Append("<input type='hidden' class='start-page' value='" + startPage + "' name='Grid_Detail.Pager.StartPage'> ");

            pagerStr.Append("<input type='hidden' class='end-page' value='" + endPage + "' name='Grid_Detail.Pager.EndPage'>");

            return pagerStr.ToString();
        }

        public static DataTable Skip_Take_Records(DataTable dt, int currentPage, int pageSize)
        {
            if (currentPage > 1)
            {
                return dt.AsEnumerable().Skip((currentPage - 1) * pageSize).Take(pageSize).CopyToDataTable<DataRow>();
            }
            else
            {
                return dt.AsEnumerable().Take(pageSize).CopyToDataTable<DataRow>();
            }
        }

    }
}



































    //public static string NumericPagerForAtlant(int totalRecords, int currentPage, int pagesize, int pageLimit, int startPage, int endPage, bool isFirst, bool isPrevious, bool isNext, bool isLast, bool pageAndRecordLabel)
    //        {
    //            StringBuilder pagerStr = new StringBuilder();

    //            int reminder = totalRecords % pagesize;

    //            int pages = 0;

    //            if (reminder > 0)
    //            {
    //                pages = (totalRecords / pagesize) + 1;
    //            }
    //            else
    //            {
    //                pages = totalRecords / pagesize;
    //            }

    //            #region Set Current Page

    //            if (isFirst)
    //            {
    //                currentPage = 1;
    //            }

    //            if (isPrevious)
    //            {
    //                if (currentPage >= startPage && currentPage <= endPage)
    //                {
    //                    currentPage = (startPage - 1) - (endPage - startPage);
    //                }
    //            }

    //            if (isNext)
    //            {
    //                if (currentPage >= startPage && currentPage <= endPage)
    //                {
    //                    currentPage = endPage + 1;
    //                }
    //            }

    //            if (isLast)
    //            {
    //                currentPage = pages;
    //            }

    //            #endregion

    //            #region Total Record Message

    //            int from = 0;

    //            int to = 0;

    //            if (pageAndRecordLabel)
    //            {
    //                from = ((currentPage * pagesize) - (pagesize)) + 1;

    //                to = from + (pagesize - 1);

    //                pagerStr.Append("<div class='dataTables_info'>Showing " + from + " to " + to + " of " + totalRecords + " entries</div>");
    //            }

    //            #endregion

    //            pagerStr.Append("<div class='dataTables_paginate paging_simple_numbers'>");

    //            #region First Button

    //            if (isFirst || currentPage == 1)
    //            {
    //                //pagerStr.Append("<a href='javascript:MoveQuick(\"First\")' class='paginate_button previous' tabindex='0'>First</a>");
    //            }
    //            else
    //            {
    //                pagerStr.Append("<a class='paginate_button previous' tabindex='0'>First</a>");
    //            }

    //            #endregion

    //            #region Previous Button

    //            if (isPrevious || currentPage == 1)
    //            {
    //                pagerStr.Append("<a class='paginate_button previous' style='text-decoration:none;' tabindex='0'>Previous</a>");
    //            }
    //            else
    //            {
    //                pagerStr.Append("<a class='paginate_button previous' tabindex='0'>Previous</a>");
    //            }

    //            #endregion

    //            #region Page Button

    //            int tempPage = 0;

    //            int batchStart = 0;

    //            int batchEnd = 0;

    //            int numberOfBatches = 0;

    //            if (pages <= pageLimit)
    //            {
    //                numberOfBatches = 1;
    //            }
    //            else
    //            {
    //                reminder = pages % pageLimit;

    //                if (reminder > 0)
    //                {
    //                    numberOfBatches = (pages / pageLimit) + 1;
    //                }
    //                else
    //                {
    //                    numberOfBatches = pages;
    //                }
    //            }

    //            for (int batch = 1; batch <= numberOfBatches; batch++)
    //            {
    //                tempPage += 1;

    //                batchStart = tempPage; 

    //                if (pages <= pageLimit)
    //                {
    //                    pageLimit = pages;
    //                }

    //                batchEnd = batchStart + (pageLimit - 1);

    //                if (pages >= batchStart && pages <= batchEnd)
    //                {
    //                    batchEnd = pages;
    //                }

    //                for (int page = tempPage; page < totalRecords; page++)
    //                {
    //                    tempPage = page;

    //                    if (currentPage >= batchStart && currentPage <= batchEnd)
    //                    {
    //                        startPage = batchStart;

    //                        endPage = batchEnd;

    //                        if (currentPage == page)
    //                        {
    //                            pagerStr.Append("<a class='paginate_button current' tabindex='0'>" + page + "</a>");
    //                        }
    //                        else
    //                        {
    //                            pagerStr.Append("<a class='paginate_button' tabindex='0'>" + page + "</a>");
    //                        }
    //                    }

    //                    if (page >= batchEnd)
    //                    {
    //                        break;
    //                    }
    //                }
    //            }

                

    //            #endregion

    //            #region Next Button

    //            if (isLast || currentPage == pages)
    //            {
    //                pagerStr.Append("<a class='paginate_button next' style='text-decoration:none; cursor:default;' tabindex='0'>Next</a>");
    //            }
    //            else
    //            {
    //                pagerStr.Append("<a class='paginate_button next' tabindex='0'>Next</a>");
    //            }

    //            #endregion

    //            #region Last Button

    //            if (isLast || currentPage == pages)
    //            {
    //                //pagerStr.Append("<a class='paginate_button next' style='text-decoration:none; cursor:default;' tabindex='0'>Last</a>");
    //            }
    //            else
    //            {
    //                pagerStr.Append("<a class='paginate_button next' tabindex='0'>Last</a>");
    //            }

    //            #endregion

    //            pagerStr.Append("</div>");

    //            pagerStr.Append("<input type='hidden' class='current-page' value='' /> ");

    //            pagerStr.Append("<input type='hidden' class='quick-page' value=''> ");

    //            pagerStr.Append("<input type='hidden' class='start-page' value='" + startPage + "'> ");

    //            pagerStr.Append("<input type='hidden' class='end-page' value='" + endPage + "'>");

    //            return pagerStr.ToString();
    //        }