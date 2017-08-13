using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace ParishSystem
{
    class treasurerBackend :DataHandler
    {
        
        public treasurerBackend()
        {
                    }
        public DataTable getAllItemTypesOfBook(int b)
        {
            string q = $"select * from itemtype where booktype = {b}";
            return runQuery(q);
        }
        public DataTable searchByOR(int OR, int BookType)
        {
            string q = $@"select ORnum, sourceName,primaryIncomeDateTime,remarks,primaryincome.primaryIncomeID,bookType, sum(price) as price ,sum(amount) as amount
                        from primaryincome left outer join item on item.primaryIncomeID= primaryincome.primaryIncomeID left outer join payment on payment.primaryIncomeID= primaryincome.primaryIncomeID
                        where
                        bookType = 1 and ORnum like '%{OR}%'
                        group by  ORnum
                        order by ORnum desc";
            return runQuery(q);
        }

        public DataTable getTransactions(int BookType)
        {
            string q = $@"select ORnum, sourceName,primaryIncomeDateTime,remarks,primaryincome.primaryIncomeID,bookType, sum(price) as price ,sum(amount) as amount
                        from primaryincome left outer join item on item.primaryIncomeID= primaryincome.primaryIncomeID left outer join payment on payment.primaryIncomeID= primaryincome.primaryIncomeID
                        where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                        and bookType = {BookType}
                        group by  ORnum
                        order by ORnum desc";
            return runQuery(q);
        }
        public DataTable getTransactionSummary(int BookType)
        {
            string q = $@"select itemtype.itemType, sum(price) from primaryincome inner join item on item.primaryIncomeID = primaryincome.primaryincomeid inner join itemtype on item.itemTypeID = itemtype.itemTypeID
                        where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                        and primaryincome.bookType = {BookType}
                        group by itemtype.itemtypeid
                        order by itemtype.itemType asc; ";
            return runQuery(q);
        }
        public DataTable getTransactionsOnDay( int bookType, int day, int month, int year)
        {
            string q = $@"SELECT * FROM primaryincome left outer join item on item.primaryIncomeID = primaryincome.primaryIncomeID 
                        left outer join payment on payment.primaryIncomeID=primaryincome.primaryincomeid 
                        where  DAY(primaryIncomeDateTime) = {day} and MONTH(primaryIncomeDateTime) = {month} and YEAR(primaryIncomeDateTime) = {year} and bookType = {bookType}";
            return runQuery(q);
        }
        public DataTable getTransactionsOnMonth( int bookType, int month, int year )
        {
            string q = $@"SELECT * FROM primaryincome left outer join item on item.primaryIncomeID = primaryincome.primaryIncomeID 
                        left outer join payment on payment.primaryIncomeID=primaryincome.primaryincomeid 
                        where  YEAR(primaryIncomeDateTime) = {year} AND MONTH(primaryIncomeDateTime) = {month} and bookType = {bookType}";
            return runQuery(q);
        }

        
        
        public DataTable getTransactionsOnYear( int bookType , int year)
        {
            string q = $@"SELECT * FROM primaryincome left outer join item on item.primaryIncomeID = primaryincome.primaryIncomeID 
                         left outer join payment on payment.primaryIncomeID=primaryincome.primaryincomeid 
                        where  YEAR(primaryIncomeDateTime) = {year} and bookType = {bookType}";
            return runQuery(q);
        }
        public DataTable getTransactionsInBetweenDates(int bookType, DateTime from, DateTime to)
        {
            string q = $@"select ORnum, sourceName,primaryIncomeDateTime,remarks,primaryincome.primaryIncomeID,bookType, sum(price) as price ,sum(amount) as amount
                        from primaryincome left outer join item on item.primaryIncomeID= primaryincome.primaryIncomeID left outer join payment on payment.primaryIncomeID= primaryincome.primaryIncomeID
                        where(primaryIncomeDateTime between '{ from.ToString("yyyy-MM-dd hh:mm:ss")}' and '{to.ToString("yyyy-MM-dd hh:mm:ss")}')
                        and bookType = {bookType}
                        group by  ORnum
                        order by ORnum desc";
            return runQuery(q);
        }


        public DataTable getTransactionsByAccountingBookFormatByBook(int BookType)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where primaryincome.booktype = {BookType} and 
                            primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where primaryincome.booktype = {BookType} and 
                            primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByDay(int BookType ,int Day, int Month ,int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where DAY(primaryIncomeDateTime) = {Day} and MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where DAY(primaryIncomeDateTime) = {Day} and MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByMonth(int BookType, int Month, int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByYear(int BookType, int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatBetweenDates(int BookType, DateTime from, DateTime to)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where(primaryIncomeDateTime between '{ from.ToString("yyyy-MM-dd hh:mm:ss")}' and '{to.ToString("yyyy-MM-dd hh:mm:ss")}')
                            and primaryIncome.bookType = { BookType }
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where(primaryIncomeDateTime between '{ from.ToString("yyyy-MM-dd hh:mm:ss")}' and '{to.ToString("yyyy-MM-dd hh:mm:ss")}')
                            and primaryIncome.bookType = { BookType }
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatRecent(int BookType)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                            and primaryIncome.bookType = {BookType}
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                             where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                             and primaryIncome.bookType = {BookType}
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getSummaryOfTransactions(DataTable transactions,int bookType)//summary tab
        {
            DataTable allitems = getAllItemTypesOfBook(bookType);
            Dictionary<string, float> itemtypes = new Dictionary<string, float>();

            foreach (DataRow dr in allitems.Rows)
            {
                itemtypes.Add(dr["itemType"].ToString(),0);
            }

            foreach (DataRow dr in transactions.Rows)
            {
                if (itemtypes.ContainsKey(dr["itemType"].ToString()))
                {
                    itemtypes[dr["itemtype"].ToString()] = itemtypes[dr["itemtype"].ToString()] + float.Parse(dr["itemtype"].ToString());
                }
            }
            DataTable output = new DataTable();
            foreach (KeyValuePair<string, float> entry in itemtypes)
            {
                if (entry.Value != 0)
                {
                    output.Rows.Add(entry.Key,entry.Value);
                }
            }
            return output;
        }
        
        public DataTable getTotalSummaryOfTransactions(DataTable transactions)//shows per OR with total
        {
            DataTable output = new DataTable();
            int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
            DataRow row = output.NewRow();

            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Amount", typeof(float));
            output.Columns.Add("Name", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in transactions.Rows)
            {
                if (currentOR != int.Parse(dr["ORnum"].ToString()))
                {
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentOR = int.Parse(dr["ORnum"].ToString());
                }
                row["OR Number"] = dr["ORnum"].ToString();
                row["Name"] = dr["SourceName"].ToString();
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy, hh-mm");
                try { row["Amount"] = float.Parse(row["Amount"].ToString()) + float.Parse(dr["price"].ToString()); } catch { row["Amount"]= float.Parse(dr["price"].ToString()); };
            }
            output.Rows.Add(row);
            return output;
        }

        public DataTable getTotalSummaryOfTransactionsOnOrRange(DataTable transactions)//shows per OR with total
        {
            DataTable output = new DataTable();
            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Amount", typeof(float));
            output.Columns.Add("Date Paid", typeof(string));
            DataRow row = output.NewRow();
            DateTime currentDate = toDateTime(transactions.Rows[0]["primaryIncomeDateTime"].ToString(), false);
            int minOR = int.MaxValue;
            int maxOR = 0;
           
            foreach (DataRow dr in transactions.Rows)
            {
                if (!currentDate.Equals(toDateTime(dr["primaryIncomeDateTime"].ToString(), false)))
                {
                    row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentDate = toDateTime(dr["primaryIncomeDateTime"].ToString(), false);
                    minOR = int.MaxValue;
                    maxOR = 0;
                }
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy");
                if (minOR > int.Parse(dr["ORnum"].ToString()))
                {
                    minOR = int.Parse(dr["ORnum"].ToString());
                }

                if (maxOR < int.Parse(dr["ORnum"].ToString()))
                {
                    maxOR = int.Parse(dr["ORnum"].ToString());
                }
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy");
                try { row["Amount"] = float.Parse(row["Amount"].ToString()) + float.Parse(dr["price"].ToString()); } catch { row["Amount"] = float.Parse(dr["price"].ToString()); };
            }
            row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
            output.Rows.Add(row);
            return output;
        }

        public DataTable getBreakdownSummaryOfTransactions(DataTable transactions, int bookType)//breakdown option //<<----item table must be passed here, separated ang per item, not in 1 OR
        {
            DataTable output = new DataTable();
            DataTable itemTypes = getAllItemTypesOfBook(bookType);

            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Name", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in itemTypes.Rows)
            {
                output.Columns.Add(dr["itemType"].ToString(),typeof(float)); //add columns 
                output.Columns[dr["itemType"].ToString()].DefaultValue = 0;
               
            }

            int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
            DataRow row = output.NewRow();
            foreach (DataRow dr in transactions.Rows)
            {
                if (currentOR != int.Parse(dr["ORnum"].ToString()))
                {

                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentOR = int.Parse(dr["ORnum"].ToString());
                }
                row["OR Number"] = dr["ORnum"].ToString();
                row["Name"] = dr["SourceName"].ToString();
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(),true).ToString("MMMM dd yyyy, hh-mm");
                row[dr["itemType"].ToString()] =(row[dr["itemType"].ToString()]==null ? 0:float.Parse(row[dr["itemType"].ToString()].ToString())) + float.Parse(dr["price"].ToString());
            }
            output.Rows.Add(row);

            return output;
        }
        public DataTable getDayRangeSummaryOfTransactions(DataTable transactions) //sum of tranasctions per or range
        {
            DataTable output = new DataTable();
            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Amount", typeof(float));
            output.Columns.Add("Date Paid", typeof(string));
            DataRow row = output.NewRow();
            DateTime currentDate = toDateTime(transactions.Rows[0]["primaryIncomeDateTime"].ToString(),false);
            int minOR = int.MaxValue;
            int maxOR = 0;
            float amount = 0;   
            foreach (DataRow dr in transactions.Rows)
            {
                if (!currentDate.Equals(toDateTime(dr["primaryIncomeDateTime"].ToString(), false)))
                {
                    row["OR Number"] = minOR.ToString()+"-"+ maxOR.ToString();
                    row["Amount"] = amount;
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentDate = toDateTime(dr["primaryIncomeDateTime"].ToString(), false);
                    minOR = int.MaxValue;
                    maxOR = 0;
                    amount = 0;
                }
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy");
                if (minOR > int.Parse(dr["ORnum"].ToString()))
                {
                    minOR = int.Parse(dr["ORnum"].ToString());
                }

                if (maxOR < int.Parse(dr["ORnum"].ToString()))
                {
                    maxOR = int.Parse(dr["ORnum"].ToString());
                }
                amount += ((dr["price"].ToString() != "") ? float.Parse(dr["price"].ToString()) : float.Parse(dr["amount"].ToString()));
            }
            row["Date Paid"] = currentDate.ToString("MMMM dd yyyy");
            row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
            row["Amount"] = amount;
            output.Rows.Add(row);
            return output;
        }

        public DataTable getDayRangeSummaryOfTransactionsOnORrange(DataTable transactions,int bookType) //grouped by or per day + sum of transactions
        {
            DateTime currentDate = toDateTime(transactions.Rows[0]["primaryIncomeDateTime"].ToString(), false);
            int minOR = int.MaxValue;
            int maxOR = 0;
        
            DataTable output = new DataTable();
            DataTable itemTypes = getAllItemTypesOfBook(bookType);

            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in itemTypes.Rows)
            {
                output.Columns.Add(dr["itemType"].ToString(), typeof(float)); //add columns 
                output.Columns[dr["itemType"].ToString()].DefaultValue = 0;
            }
            int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
            DataRow row = output.NewRow();
            foreach (DataRow dr in transactions.Rows)
            {
                if (!currentDate.Equals(toDateTime(dr["primaryIncomeDateTime"].ToString(), false)))
                {
                    row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentDate = toDateTime(dr["primaryIncomeDateTime"].ToString(), false);
                    minOR = int.MaxValue;
                    maxOR = 0;
                }
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy");
                if (minOR > int.Parse(dr["ORnum"].ToString()))
                {
                    minOR = int.Parse(dr["ORnum"].ToString());
                }

                if (maxOR < int.Parse(dr["ORnum"].ToString()))
                {
                    maxOR = int.Parse(dr["ORnum"].ToString());
                }
                //per itemtype code starts here
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy, hh-mm");
                row[dr["itemType"].ToString()] = (row[dr["itemType"].ToString()] == null ? 0 : float.Parse(row[dr["itemType"].ToString()].ToString())) + float.Parse(dr["price"].ToString());
                //per item type code ends here
            }
            row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
            output.Rows.Add(row);

            return output;
        }

    }
}
